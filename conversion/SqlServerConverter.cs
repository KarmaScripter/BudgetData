// <copyright file = "SqlServerConverter.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using log4net;

    /// <summary>
    /// This class is resposible to take a single SQL Server database and convert it to an SQLite
    /// database file.
    /// </summary>
    /// <remarks>
    /// The class knows how to convert table and index structures only.
    /// </remarks>
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "ConvertSwitchStatementToSwitchExpression" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    public class SqlServerConverter
    {
        // *************************************************************************************************************************
        // ****************************************************     FIELDS    ******************************************************
        // *************************************************************************************************************************

        /// <summary>
        /// The cancelled
        /// </summary>
        private bool Cancelled;

        /// <summary>
        /// The keyrx
        /// </summary>
        private readonly Regex Keyrx = new Regex( @"(([a-zA-ZäöüÄÖÜß0-9\.]|(\s+))+)(\(\-\))?" );

        /// <summary>
        /// The defaultvaluerx
        /// </summary>
        private readonly Regex Defaultvaluerx = new Regex( @"\(N(\'.*\')\)" );

        /// <summary>
        /// The log
        /// </summary>
        private readonly ILog Log = LogManager.GetLogger( typeof( SqlServerConverter ) );

        // **************************************************************************************************************************
        // *******************************************************   CONSTRUCTORS ***************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SqlServerConverter" />
        /// class.
        /// </summary>
        public SqlServerConverter()
        {
        }

        // **************************************************************************************************************************
        // ******************************************************   PROPERTIES   ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is active; otherwise,
        /// <c> false </c>
        /// .
        /// </value>
        private bool IsActive { get; set; }

        // **************************************************************************************************************************
        // ****************************************************  METHODS   **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Writes the trigger schema.
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <returns></returns>
        private string WriteTriggerSchema( TriggerSchema ts )
        {
            return @"CREATE TRIGGER ["
                + ts.Name
                + "] "
                + ts.Type
                + " "
                + ts.Event
                + " ON ["
                + ts.Table
                + "] "
                + "BEGIN "
                + ts.Body
                + " END;";
        }

        /// <summary>
        /// Cancels the conversion.
        /// </summary>
        public void CancelConversion()
        {
            Cancelled = true;
        }

        /// <summary>
        /// Converts the SQL server to sq lite database.
        /// </summary>
        /// <param name="sqlserverconnstring">The sqlserverconnstring.</param>
        /// <param name="path">The path.</param>
        /// <param name="password">The password.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="selectionhandler">The selectionhandler.</param>
        /// <param name="viewfailurehandler">The viewfailurehandler.</param>
        /// <param name="createtriggers">if set to
        /// <c> true </c>
        /// [createtriggers].</param>
        /// <param name="createviews">if set to
        /// <c> true </c>
        /// [createviews].</param>
        public void ConvertSqlServerToSQLiteDatabase( string sqlserverconnstring, string path,
            string password, SqlConversionHandler handler, SqlTableSelectionHandler selectionhandler,
            FailedViewDefinitionHandler viewfailurehandler, bool createtriggers, bool createviews )
        {
            // Clear cancelled flag
            Cancelled = false;

            ThreadPool.QueueUserWorkItem( delegate
            {
                try
                {
                    IsActive = true;

                    ConvertToSQLite( sqlserverconnstring, path, password, handler,
                        selectionhandler, viewfailurehandler, createtriggers, createviews );

                    IsActive = false;
                    handler( true, true, 100, "Finished converting database" );
                }
                catch( Exception ex )
                {
                    Log.Error( "Failed to convert SQL Server database to SQLite database", ex );
                    IsActive = false;
                    handler( true, false, 100, ex.Message );
                }// catch
            } );
        }

        /// <summary>
        /// Converts to sq lite.
        /// </summary>
        /// <param name="sqlconnstring">The sqlconnstring.</param>
        /// <param name="path">The path.</param>
        /// <param name="password">The password.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="selectionhandler">The selectionhandler.</param>
        /// <param name="viewfailurehandler">The viewfailurehandler.</param>
        /// <param name="createtriggers">if set to
        /// <c> true </c>
        /// [createtriggers].</param>
        /// <param name="createviews">if set to
        /// <c> true </c>
        /// [createviews].</param>
        private void ConvertToSQLite( string sqlconnstring, string path, string password,
            SqlConversionHandler handler, SqlTableSelectionHandler selectionhandler,
            FailedViewDefinitionHandler viewfailurehandler, bool createtriggers, bool createviews )
        {
            // Delete the target file if it exists already.
            if( File.Exists( path ) )
            {
                File.Delete( path );
            }

            // Read the schema of the SQL Server database into a memory structure
            var ds = ReadSqlServerSchema( sqlconnstring, handler, selectionhandler );

            // Create the SQLite database and apply the schema
            CreateSQLiteDatabase( path, ds, password, handler,
                viewfailurehandler, createviews );

            // Copy all rows from SQL Server tables to the newly created SQLite database
            CopyDataRows( sqlconnstring, path, ds.Tables, password,
                handler );

            // Add triggers based on foreign key constraints
            if( createtriggers )
            {
                AddTriggersForForeignKeys( path, ds.Tables, password );
            }
        }

        /// <summary>
        /// Copies the data rows.
        /// </summary>
        /// <param name="sqlconnstring">The sqlconnstring.</param>
        /// <param name="path">The path.</param>
        /// <param name="schema">The schema.</param>
        /// <param name="password">The password.</param>
        /// <param name="handler">The handler.</param>
        private void CopyDataRows( string sqlconnstring, string path, IReadOnlyList<TableSchema> schema,
            string password, SqlConversionHandler handler )
        {
            CheckCancelled();
            handler( false, true, 0, "Preparing to insert tables..." );
            Log.Debug( "preparing to insert tables ..." );

            // Connect to the SQL Server database
            using var ssconn = new SqlConnection( sqlconnstring );
            ssconn.Open();

            // Connect to the SQLite database next
            var sqliteconnstring = CreateSQLiteConnectionString( path, password );
            using var sqconn = new SQLiteConnection( sqliteconnstring );
            sqconn.Open();

            // Go over all tables in the schema and copy their rows
            for( var i = 0; i < schema.Count; i++ )
            {
                var tx = sqconn.BeginTransaction();

                try
                {
                    var tablequery = BuildSqlServerTableQuery( schema[ i ] );

                    using( var query = new SqlCommand( tablequery, ssconn ) )
                    {
                        using var reader = query.ExecuteReader();
                        using var insert = BuildSQLiteInsert( schema[ i ] );
                        var counter = 0;

                        while( reader.Read() )
                        {
                            insert.Connection = sqconn;
                            insert.Transaction = tx;
                            var pnames = new List<string>();

                            for( var j = 0; j < schema[ i ].Columns.Count; j++ )
                            {
                                var pname = "@"
                                    + GetNormalizedName( schema[ i ].Columns[ j ].ColumnName, pnames );

                                insert.Parameters[ pname ].Value =
                                    CastValueForColumn( reader[ j ], schema[ i ].Columns[ j ] );

                                pnames.Add( pname );
                            }

                            insert.ExecuteNonQuery();
                            counter++;

                            if( counter % 1000 == 0 )
                            {
                                CheckCancelled();
                                tx.Commit();

                                handler( false, true, (int)( 100.0 * i / schema.Count ),
                                    "Added "
                                    + counter
                                    + " rows to table "
                                    + schema[ i ].TableName
                                    + " so far" );

                                tx = sqconn.BeginTransaction();
                            }
                        }// while
                    }

                    CheckCancelled();
                    tx.Commit();

                    handler( false, true, (int)( 100.0 * i / schema.Count ),
                        "Finished inserting rows for table " + schema[ i ].TableName );

                    Log.Debug( "finished inserting all rows for table [" + schema[ i ].TableName + "]" );
                }
                catch( Exception ex )
                {
                    Log.Error( "unexpected exception", ex );
                    tx.Rollback();
                    throw;
                }// catch
            }
        }

        /// <summary>
        /// Casts the value for column.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="columnschema">The columnschema.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Illegal database type [" + Enum.GetName(typeof(DbType), dt)
        /// + "]</exception>
        private object CastValueForColumn( object val, ColumnSchema columnschema )
        {
            if( val is DBNull )
            {
                return null;
            }

            var dt = GetDbTypeOfColumn( columnschema );

            switch( dt )
            {
                case DbType.Int32:
                {
                    switch( val )
                    {
                        case short s:
                        {
                            return (int)s;
                        }

                        case byte b:
                        {
                            return (int)b;
                        }

                        case long l:
                        {
                            return (int)l;
                        }

                        case decimal val1:
                        {
                            return (int)val1;
                        }
                    }

                    break;
                }

                case DbType.Int16:
                {
                    switch( val )
                    {
                        case int i:
                        {
                            return (short)i;
                        }

                        case byte b:
                        {
                            return (short)b;
                        }

                        case long l:
                        {
                            return (short)l;
                        }

                        case decimal val1:
                        {
                            return (short)val1;
                        }
                    }

                    break;
                }

                case DbType.Int64:
                {
                    switch( val )
                    {
                        case int i:
                            return (long)i;

                        case short s:
                            return (long)s;

                        case byte b:
                            return (long)b;

                        case decimal val1:
                            return (long)val1;
                    }

                    break;
                }

                case DbType.Single:
                {
                    switch( val )
                    {
                        case double d:
                            return (float)d;

                        case decimal val1:
                            return (float)val1;
                    }

                    break;
                }

                case DbType.Double:
                {
                    switch( val )
                    {
                        case float f:
                            return (double)f;

                        case double d:
                            return d;

                        case decimal val1:
                            return (double)val1;
                    }

                    break;
                }

                case DbType.String:
                {
                    if( val is Guid guid )
                    {
                        return guid.ToString();
                    }

                    break;
                }

                case DbType.Guid:
                {
                    switch( val )
                    {
                        case string s:
                            return ParseStringAsGuid( s );

                        case byte[] bytes:
                            return ParseBlobAsGuid( bytes );
                    }

                    break;
                }

                case DbType.Binary:
                case DbType.Boolean:
                case DbType.DateTime:
                    break;

                default:
                {
                    Log.Error( "argument exception - illegal database type" );

                    throw new ArgumentException( "Illegal database type ["
                        + Enum.GetName( typeof( DbType ), dt )
                        + "]" );
                }
            }// switch

            return val;
        }

        /// <summary>
        /// Parses the BLOB as unique identifier.
        /// </summary>
        /// <param name="blob">The BLOB.</param>
        /// <returns></returns>
        private Guid ParseBlobAsGuid( IEnumerable<byte> blob )
        {
            var data = blob.ToArray();

            if( blob.Count() > 16 )
            {
                data = new byte[ 16 ];

                for( var i = 0; i < 16; i++ )
                {
                    data[ i ] = blob.ToArray()[ i ];
                }
            }
            else if( blob.Count() < 16 )
            {
                data = new byte[ 16 ];

                for( var i = 0; i < blob.Count(); i++ )
                {
                    data[ i ] = blob.ToArray()[ i ];
                }
            }

            return new Guid( data );
        }

        /// <summary>
        /// Parses the string as unique identifier.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        private Guid ParseStringAsGuid( string str )
        {
            try
            {
                return new Guid( str );
            }
            catch( Exception )
            {
                return Guid.Empty;
            }// catch
        }

        /// <summary>
        /// Builds the sq lite insert.
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <returns></returns>
        private SQLiteCommand BuildSQLiteInsert( TableSchema ts )
        {
            var res = new SQLiteCommand();
            var sb = new StringBuilder();
            sb.Append( "INSERT INTO [" + ts.TableName + "] (" );

            for( var i = 0; i < ts.Columns.Count; i++ )
            {
                sb.Append( "[" + ts.Columns[ i ].ColumnName + "]" );

                if( i < ts.Columns.Count - 1 )
                {
                    sb.Append( ", " );
                }
            }// for

            sb.Append( ") VALUES (" );
            var pnames = new List<string>();

            for( var i = 0; i < ts.Columns.Count; i++ )
            {
                var pname = "@" + GetNormalizedName( ts.Columns[ i ].ColumnName, pnames );
                sb.Append( pname );

                if( i < ts.Columns.Count - 1 )
                {
                    sb.Append( ", " );
                }

                var dbtype = GetDbTypeOfColumn( ts.Columns[ i ] );
                var prm = new SQLiteParameter( pname, dbtype, ts.Columns[ i ].ColumnName );
                res.Parameters.Add( prm );

                // Remember the dicteter name in order to avoid duplicates
                pnames.Add( pname );
            }// for

            sb.Append( ")" );
            res.CommandText = sb.ToString();
            res.CommandType = CommandType.Text;
            return res;
        }

        /// <summary>
        /// Gets the name of the normalized.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="names">The names.</param>
        /// <returns></returns>
        private string GetNormalizedName( string str, ICollection<string> names )
        {
            var sb = new StringBuilder();

            for( var i = 0; i < str.Length; i++ )
            {
                if( char.IsLetterOrDigit( str[ i ] ) )
                {
                    sb.Append( str[ i ] );
                }
                else
                {
                    sb.Append( "" );
                }
            }// for

            // Avoid returning duplicate name
            return names.Contains( sb.ToString() )
                ? GetNormalizedName( sb + "", names )
                : sb.ToString();
        }

        /// <summary>
        /// Gets the database type of column.
        /// </summary>
        /// <param name="cs">The cs.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Illegal DB type found (" + cs.ColumnType + ")</exception>
        private DbType GetDbTypeOfColumn( ColumnSchema cs )
        {
            switch( cs.ColumnType )
            {
                case "tinyint":
                    return DbType.Byte;

                case "int":
                    return DbType.Int32;

                case "smallint":
                    return DbType.Int16;

                case "bigint":
                    return DbType.Int64;

                case "bit":
                    return DbType.Boolean;

                case "nvarchar":
                case "varchar":
                case "text":
                case "ntext":
                    return DbType.String;

                case "float":
                    return DbType.Double;

                case "real":
                    return DbType.Single;

                case "blob":
                    return DbType.Binary;

                case "numeric":
                    return DbType.Double;

                case "timestamp":
                case "datetime":
                case "datetime2":
                case "date":
                case "time":
                    return DbType.DateTime;

                case "nchar":
                case "char":
                    return DbType.String;

                case "uniqueidentifier":
                case "guid":
                    return DbType.Guid;

                case "xml":
                    return DbType.String;

                case "sqlvariant":
                    return DbType.Object;

                case "integer":
                    return DbType.Int64;

                default:
                    Log.Error( "illegal db type found" );
                    throw new ApplicationException( "Illegal DB type found (" + cs.ColumnType + ")" );
            }
        }

        /// <summary>
        /// Builds the SQL server table query.
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <returns></returns>
        private string BuildSqlServerTableQuery( TableSchema ts )
        {
            var sb = new StringBuilder();
            sb.Append( "SELECT " );

            for( var i = 0; i < ts.Columns.Count; i++ )
            {
                sb.Append( "[" + ts.Columns[ i ].ColumnName + "]" );

                if( i < ts.Columns.Count - 1 )
                {
                    sb.Append( ", " );
                }
            }// for

            sb.Append( " FROM " + ts.TableSchemaName + "." + "[" + ts.TableName + "]" );
            return sb.ToString();
        }

        /// <summary>
        /// Creates the sq lite database.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="schema">The schema.</param>
        /// <param name="password">The password.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="viewfailurehandler">The viewfailurehandler.</param>
        /// <param name="createviews">if set to
        /// <c> true </c>
        /// [createviews].</param>
        private void CreateSQLiteDatabase( string path, DatabaseSchema schema, string password,
            SqlConversionHandler handler, FailedViewDefinitionHandler viewfailurehandler, bool createviews )
        {
            Log.Debug( "Creating SQLite database..." );

            // Create the SQLite database file
            SQLiteConnection.CreateFile( path );
            Log.Debug( "SQLite file was created successfully at [" + path + "]" );

            // Connect to the newly created database
            var sqliteconnstring = CreateSQLiteConnectionString( path, password );

            using( var conn = new SQLiteConnection( sqliteconnstring ) )
            {
                conn.Open();

                // Create all tables in the new database
                var count = 0;

                foreach( var dt in schema.Tables )
                {
                    try
                    {
                        AddSQLiteTable( conn, dt );
                    }
                    catch( Exception ex )
                    {
                        Log.Error( "AddSQLiteTable failed", ex );
                        throw;
                    }

                    count++;
                    CheckCancelled();

                    handler( false, true, (int)( count * 50.0 / schema.Tables.Count ),
                        "Added table " + dt.TableName + " to the SQLite database" );

                    Log.Debug( "added schema for SQLite table [" + dt.TableName + "]" );
                }// foreach

                // Create all views in the new database
                count = 0;

                if( createviews )
                {
                    foreach( var vs in schema.Views )
                    {
                        try
                        {
                            AddSQLiteView( conn, vs, viewfailurehandler );
                        }
                        catch( Exception ex )
                        {
                            Log.Error( "AddSQLiteView failed", ex );
                            throw;
                        }// catch

                        count++;
                        CheckCancelled();

                        handler( false, true, 50 + (int)( count * 50.0 / schema.Views.Count ),
                            "Added view " + vs.ViewName + " to the SQLite database" );

                        Log.Debug( "added schema for SQLite view [" + vs.ViewName + "]" );
                    }// foreach
                }    // if
            }        // using

            Log.Debug( "finished adding all table/view schemas for SQLite database" );
        }

        /// <summary>
        /// Adds the sq lite view.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="vs">The vs.</param>
        /// <param name="handler">The handler.</param>
        private void AddSQLiteView( SQLiteConnection conn, ViewSchema vs,
            FailedViewDefinitionHandler handler )
        {
            // Prepare a CREATE VIEW DDL statement
            var stmt = vs.ViewSQL;
            Log.Info( "\n\n" + stmt + "\n\n" );

            // Execute the query in order to actually create the view.
            var tx = conn.BeginTransaction();

            try
            {
                using( var cmd = new SQLiteCommand( stmt, conn, tx ) )
                {
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch( SQLiteException )
            {
                tx.Rollback();

                if( handler != null )
                {
                    var updated = new ViewSchema
                    {
                        ViewName = vs.ViewName,
                        ViewSQL = vs.ViewSQL
                    };

                    // Ask the user to supply the new view definition SQL statement
                    var sql = handler( updated );

                    if( sql == null )
                    {
                    }
                    else
                    {
                        // Try to re-create the view with the user-supplied view definition SQL
                        updated.ViewSQL = sql;
                        AddSQLiteView( conn, updated, handler );
                    }
                }
                else
                {
                    throw;
                }
            }// catch
        }

        /// <summary>
        /// Adds the sq lite table.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="dt">The dt.</param>
        private void AddSQLiteTable( SQLiteConnection conn, TableSchema dt )
        {
            // Prepare a CREATE TABLE DDL statement
            var stmt = BuildCreateTableQuery( dt );
            Log.Info( "\n\n" + stmt + "\n\n" );

            // Execute the query in order to actually create the table.
            using var cmd = new SQLiteCommand( stmt, conn );
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Builds the create table query.
        /// </summary>
        /// <param name="schema">The ts.</param>
        /// <returns></returns>
        private string BuildCreateTableQuery( TableSchema schema )
        {
            var builder = new StringBuilder();
            builder.Append( "CREATE TABLE [" + schema.TableName + "] (\n" );
            var key = false;

            for( var i = 0; i < schema.Columns.Count; i++ )
            {
                var col = schema.Columns[ i ];
                var cline = BuildColumnStatement( col, schema, ref key );
                builder.Append( cline );

                if( i < schema.Columns.Count - 1 )
                {
                    builder.Append( ",\n" );
                }
            }

            // add primary keys...
            if( schema.PrimaryKey != null
                && schema.PrimaryKey.Count > 0 & !key )
            {
                builder.Append( ",\n" );
                builder.Append( "    PRIMARY KEY (" );

                for( var i = 0; i < schema.PrimaryKey.Count; i++ )
                {
                    builder.Append( "[" + schema.PrimaryKey[ i ] + "]" );

                    if( i < schema.PrimaryKey.Count - 1 )
                    {
                        builder.Append( ", " );
                    }
                }// for

                builder.Append( ")\n" );
            }
            else
            {
                builder.Append( "\n" );
            }

            // add foreign keys...
            if( schema.ForeignKeys.Count > 0 )
            {
                builder.Append( ",\n" );

                for( var i = 0; i < schema.ForeignKeys.Count; i++ )
                {
                    var foreignkey = schema.ForeignKeys[ i ];

                    var stmt =
                        $"    FOREIGN KEY ([{foreignkey.ColumnName}])\n        REFERENCES [{foreignkey.ForeignTableName}]([{foreignkey.ForeignColumnName}])";

                    builder.Append( stmt );

                    if( i < schema.ForeignKeys.Count - 1 )
                    {
                        builder.Append( ",\n" );
                    }
                }// for
            }

            builder.Append( "\n" );
            builder.Append( ");\n" );

            // Create any relevant indexes
            if( schema.Indexes != null )
            {
                for( var i = 0; i < schema.Indexes.Count; i++ )
                {
                    var stmt = BuildCreateIndex( schema.TableName, schema.Indexes[ i ] );
                    builder.Append( stmt + ";\n" );
                }// for
            }    // if

            var query = builder.ToString();
            return query;
        }

        /// <summary>
        /// Builds the index of the create.
        /// </summary>
        /// <param name="tablename">The tablename.</param>
        /// <param name="schema">The schema.</param>
        /// <returns></returns>
        private string BuildCreateIndex( string tablename, IndexSchema schema )
        {
            var sb = new StringBuilder();
            sb.Append( "CREATE " );

            if( schema.IsUnique )
            {
                sb.Append( "UNIQUE " );
            }

            sb.Append( "INDEX [" + tablename + "" + schema.IndexName + "]\n" );
            sb.Append( "ON [" + tablename + "]\n" );
            sb.Append( "(" );

            for( var i = 0; i < schema.Columns.Count; i++ )
            {
                sb.Append( "[" + schema.Columns[ i ] + "]" );

                if( schema.Columns[ i ] != null )
                {
                    sb.Append( " DESC" );
                }

                if( i < schema.Columns.Count - 1 )
                {
                    sb.Append( ", " );
                }
            }// for

            sb.Append( ")" );
            return sb.ToString();
        }

        /// <summary>
        /// Builds the column statement.
        /// </summary>
        /// <param name="col">The col.</param>
        /// <param name="ts">The ts.</param>
        /// <param name="pkey">if set to
        /// <c> true </c>
        /// [pkey].</param>
        /// <returns></returns>
        private string BuildColumnStatement( ColumnSchema col, TableSchema ts, ref bool pkey )
        {
            var sb = new StringBuilder();
            sb.Append( "\t[" + col.ColumnName + "]\t" );

            // Special treatment for IDENTITY columns
            if( col.IsIdentity )
            {
                if( ts.PrimaryKey.Count == 1
                    && ( col.ColumnType == "tinyint"
                        || col.ColumnType == "int"
                        || col.ColumnType == "smallint"
                        || col.ColumnType == "bigint"
                        || col.ColumnType == "integer" ) )
                {
                    sb.Append( "integer PRIMARY KEY AUTOINCREMENT" );
                    pkey = true;
                }
                else
                {
                    sb.Append( "integer" );
                }
            }
            else
            {
                switch( col.ColumnType )
                {
                    case "int":
                        sb.Append( "integer" );
                        break;

                    default:
                        sb.Append( col.ColumnType );
                        break;
                }

                if( col.Length > 0 )
                {
                    sb.Append( "(" + col.Length + ")" );
                }
            }

            if( !col.IsNullable )
            {
                sb.Append( " NOT NULL" );
            }

            if( col.IsCaseSensitivite == false )
            {
                sb.Append( " COLLATE NOCASE" );
            }

            var defval = StripParens( col.DefaultValue );
            defval = DiscardNational( defval );
            Log.Debug( "DEFAULT VALUE BEFORE [" + col.DefaultValue + "] AFTER [" + defval + "]" );

            if( Verify.Input( defval )
                && defval.ToUpper().Contains( "GETDATE" ) )
            {
                Log.Debug( "converted SQL Server GETDATE() to CURRENTTIMESTAMP for column ["
                    + col.ColumnName
                    + "]" );

                sb.Append( " DEFAULT (CURRENTTIMESTAMP)" );
            }
            else if( Verify.Input( defval )
                && IsValidDefaultValue( defval ) )
            {
                sb.Append( " DEFAULT " + defval );
            }

            return sb.ToString();
        }

        /// <summary>
        /// Discards the national.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private string DiscardNational( string value )
        {
            var rx = new Regex( @"N\'([^\']*)\'" );
            var m = rx.Match( value );

            return m.Success
                ? m.Groups[ 1 ].Value
                : value;
        }

        /// <summary>
        /// Determines whether [is valid default value] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is valid default value] [the specified value]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        private bool IsValidDefaultValue( string value )
        {
            return IsSingleQuoted( value ) || double.TryParse( value, out _ );
        }

        /// <summary>
        /// Determines whether [is single quoted] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is single quoted] [the specified value]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        private bool IsSingleQuoted( string value )
        {
            value = value.Trim();
            return value.StartsWith( "'" ) && value.EndsWith( "'" );
        }

        /// <summary>
        /// Strips the parens.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private string StripParens( string value )
        {
            var rx = new Regex( @"\(([^\)]*)\)" );
            var m = rx.Match( value );

            return !m.Success
                ? value
                : StripParens( m.Groups[ 1 ].Value );
        }

        /// <summary>
        /// Reads the SQL server schema.
        /// </summary>
        /// <param name="connstring">The connstring.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="selectionhandler">The selectionhandler.</param>
        /// <returns></returns>
        private DatabaseSchema ReadSqlServerSchema( string connstring, SqlConversionHandler handler,
            SqlTableSelectionHandler selectionhandler )
        {
            // First step is to read the names of all tables in the database
            var tables = new List<TableSchema>();

            using( var conn = new SqlConnection( connstring ) )
            {
                conn.Open();
                var tablenames = new List<string>();
                var tblschema = new List<string>();

                // This command will read the names of all tables in the database
                using( var cmd =
                    new SqlCommand( @"select * from INFORMATIONSCHEMA.TABLES  where TABLETYPE = 'BASE TABLE'",
                        conn ) )
                {
                    using var reader = cmd.ExecuteReader();

                    while( reader.Read() )
                    {
                        if( reader[ "TABLENAME" ] == DBNull.Value )
                        {
                            continue;
                        }

                        if( reader[ "TABLESCHEMA" ] == DBNull.Value )
                        {
                            continue;
                        }

                        tablenames.Add( (string)reader[ "TABLENAME" ] );
                        tblschema.Add( (string)reader[ "TABLESCHEMA" ] );
                    }// while
                }

                // Next step is to use ADO APIs to query the schema of each table.
                var count = 0;

                for( var i = 0; i < tablenames.Count; i++ )
                {
                    var tname = tablenames[ i ];
                    var tschma = tblschema[ i ];
                    var ts = CreateTableSchema( conn, tname, tschma );
                    CreateForeignKeySchema( conn, ts );
                    tables.Add( ts );
                    count++;
                    CheckCancelled();
                    handler( false, true, (int)( count * 50.0 / tablenames.Count ), "Parsed table " + tname );
                    Log.Debug( "parsed table schema for [" + tname + "]" );
                }// foreach
            }    // using

            Log.Debug( "finished parsing all tables in SQL Server schema" );

            // Allow the user a chance to select which tables to convert
            var updated = selectionhandler?.Invoke( tables );

            if( updated != null )
            {
                tables = updated;
            }

            var removedbo = new Regex( @"dbo\.", RegexOptions.Compiled | RegexOptions.IgnoreCase );

            // Continue and read all of the views in the database
            var views = new List<ViewSchema>();

            using( var conn = new SqlConnection( connstring ) )
            {
                conn.Open();

                using var cmd =
                    new SqlCommand( @"SELECT TABLENAME, VIEWDEFINITION  from INFORMATIONSCHEMA.VIEWS", conn );

                using var reader = cmd.ExecuteReader();
                var count = 0;

                while( reader.Read() )
                {
                    var vs = new ViewSchema();

                    if( reader[ "TABLENAME" ] == DBNull.Value )
                    {
                        continue;
                    }

                    if( reader[ "VIEWDEFINITION" ] == DBNull.Value )
                    {
                        continue;
                    }

                    vs.ViewName = (string)reader[ "TABLENAME" ];
                    vs.ViewSQL = (string)reader[ "VIEWDEFINITION" ];

                    // Remove all ".dbo" strings from the view definition
                    vs.ViewSQL = removedbo.Replace( vs.ViewSQL, string.Empty );
                    views.Add( vs );
                    count++;
                    CheckCancelled();

                    handler( false, true, 50 + (int)( count * 50.0 / views.Count ),
                        "Parsed view " + vs.ViewName );

                    Log.Debug( "parsed view schema for [" + vs.ViewName + "]" );
                }// while
            }    // using

            var ds = new DatabaseSchema
            {
                Tables = tables,
                Views = views
            };

            return ds;
        }

        /// <summary>
        /// Checks the cancelled.
        /// </summary>
        /// <exception cref="ApplicationException">User cancelled the conversion</exception>
        private void CheckCancelled()
        {
            if( Cancelled )
            {
                throw new ApplicationException( "User cancelled the conversion" );
            }
        }

        /// <summary>
        /// Creates the table schema.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="tablename">The tablename.</param>
        /// <param name="tschma">The tschma.</param>
        /// <returns></returns>
        [ SuppressMessage( "ReSharper", "BadParensLineBreaks" ) ]
        private TableSchema CreateTableSchema( SqlConnection conn, string tablename, string tschma )
        {
            var res = new TableSchema
            {
                TableName = tablename,
                TableSchemaName = tschma,
                Columns = new List<ColumnSchema>()
            };

            using( var cmd = new SqlCommand(
                @"SELECT COLUMNNAME, COLUMNDEFAULT, ISNULLABLE,DATATYPE,  (columnproperty(objectid(TABLENAME), COLUMNNAME, 'IsIdentity')) A[IDENT], "
                + @"CHARACTERMAXIMUMLENGTH AS CSIZE FROM INFORMATIONSCHEMA.COLUMNS WHERE TABLENAME = '{tablename}' ORDER BY ORDINALPOSITION ASC",
                conn ) )
            {
                using var reader = cmd.ExecuteReader();

                while( reader.Read() )
                {
                    var tmp = reader[ "COLUMNNAME" ];

                    if( tmp is DBNull )
                    {
                        continue;
                    }

                    var colname = (string)reader[ "COLUMNNAME" ];
                    tmp = reader[ "COLUMNDEFAULT" ];

                    var coldefault = true & tmp is DBNull
                        ? string.Empty
                        : (string)tmp;

                    tmp = reader[ "ISNULLABLE" ];
                    var isnullable = (string)tmp == "YES";
                    var datatype = (string)reader[ "DATATYPE" ];
                    var isidentity = false;

                    if( reader[ "IDENT" ] != DBNull.Value )
                    {
                        if( (int)reader[ "IDENT" ] == 1 )
                        {
                            isidentity = true;
                        }
                    }

                    var length = reader[ "CSIZE" ] != DBNull.Value
                        ? Convert.ToInt32( reader[ "CSIZE" ] )
                        : 0;

                    ValidateDataType( datatype );

                    switch( datatype )
                    {
                        // Note that not all data type names need to be converted because
                        // SQLite establishes type affinity by searching certain strings
                        // in the type name. For example - everything containing the string
                        // 'int' in its type name will be assigned an INTEGER affinity
                        case "timestamp":
                        {
                            datatype = "blob";
                            break;
                        }

                        case "datetime":
                        case "smalldatetime":
                        case "date":
                        case "datetime2":
                        case "time":
                        {
                            datatype = "datetime";
                            break;
                        }

                        case "decimal":
                        case "money":
                        case "smallmoney":
                        {
                            datatype = "numeric";
                            break;
                        }

                        case "binary":
                        case "varbinary":
                        case "image":
                        {
                            datatype = "blob";
                            break;
                        }

                        case "tinyint":
                        {
                            datatype = "smallint";
                            break;
                        }

                        case "bigint":
                        {
                            datatype = "integer";
                            break;
                        }

                        case "sqlvariant":
                        {
                            datatype = "blob";
                            break;
                        }

                        case "xml":
                        {
                            datatype = "varchar";
                            break;
                        }

                        case "uniqueidentifier":
                        {
                            datatype = "guid";
                            break;
                        }

                        case "ntext":
                        {
                            datatype = "text";
                            break;
                        }

                        case "nchar":
                        {
                            datatype = "char";
                            break;
                        }
                    }

                    if( datatype == "bit"
                        || datatype == "int" )
                    {
                        coldefault = coldefault switch
                        {
                            "('False')" => "(0)",
                            "('True')" => "(1)",
                            _ => coldefault
                        };
                    }

                    coldefault = FixDefaultValueString( coldefault );

                    var col = new ColumnSchema
                    {
                        ColumnName = colname,
                        ColumnType = datatype,
                        Length = length,
                        IsNullable = isnullable,
                        IsIdentity = isidentity,
                        DefaultValue = AdjustDefaultValue( coldefault )
                    };

                    res.Columns.Add( col );
                }// while
            }

            // Find PRIMARY KEY information
            using( var cmd2 = new SqlCommand( $"EXEC sppkeys '{tablename}'", conn ) )
            {
                using var reader = cmd2.ExecuteReader();
                res.PrimaryKey = new List<string>();

                while( reader.Read() )
                {
                    var colname = (string)reader[ "COLUMNNAME" ];
                    res.PrimaryKey.Add( colname );
                }// while
            }

            // Find COLLATE information for all columns in the table
            using( var cmd4 = new SqlCommand( @"EXEC sptablecollations '" + tschma + "." + tablename + "'",
                conn ) )
            {
                using var reader = cmd4.ExecuteReader();

                while( reader.Read() )
                {
                    bool? iscasesensitive = null;
                    var colname = (string)reader[ "name" ];

                    if( reader[ "tdscollation" ] != DBNull.Value )
                    {
                        var mask = (byte[])reader[ "tdscollation" ];
                        iscasesensitive = ( mask[ 2 ] & 0x10 ) == 0;
                    }// if

                    if( iscasesensitive.HasValue )
                    {
                        // Update the corresponding column schema.
                        foreach( var csc in res.Columns )
                        {
                            if( csc.ColumnName == colname )
                            {
                                csc.IsCaseSensitivite = iscasesensitive;
                                break;
                            }
                        }// foreach
                    }    // if
                }        // while
            }

            try
            {
                // Find index information
                using var cmd3 =
                    new SqlCommand( @"exec sphelpindex '" + tschma + "." + tablename + "'", conn );

                using var reader = cmd3.ExecuteReader();
                res.Indexes = new List<IndexSchema>();

                while( reader.Read() )
                {
                    var indexname = (string)reader[ "indexname" ];
                    var desc = (string)reader[ "indexdescription" ];
                    var keys = (string)reader[ "indexkeys" ];

                    // Don't add the index if it is actually a primary key index
                    if( desc.Contains( "primary key" ) )
                    {
                        continue;
                    }

                    var index = BuildIndexSchema( indexname, desc, keys );
                    res.Indexes.Add( index );
                }// while
            }
            catch( Exception )
            {
                Log.Warn( "failed to read index information for table [" + tablename + "]" );
            }// catch

            return res;
        }

        /// <summary>
        /// Validates the type of the data.
        /// </summary>
        /// <param name="datatype">The datatype.</param>
        /// <exception cref="ApplicationException">Validation failed for data type [" + datatype + "]</exception>
        private void ValidateDataType( string datatype )
        {
            if( datatype == "int"
                || datatype == "smallint"
                || datatype == "bit"
                || datatype == "float"
                || datatype == "real"
                || datatype == "nvarchar"
                || datatype == "varchar"
                || datatype == "timestamp"
                || datatype == "varbinary"
                || datatype == "image"
                || datatype == "text"
                || datatype == "ntext"
                || datatype == "bigint"
                || datatype == "char"
                || datatype == "numeric"
                || datatype == "binary"
                || datatype == "smalldatetime"
                || datatype == "smallmoney"
                || datatype == "money"
                || datatype == "tinyint"
                || datatype == "uniqueidentifier"
                || datatype == "xml"
                || datatype == "sqlvariant"
                || datatype == "datetime2"
                || datatype == "date"
                || datatype == "time"
                || datatype == "decimal"
                || datatype == "nchar"
                || datatype == "datetime" )
            {
                return;
            }

            throw new ApplicationException( "Validation failed for data type [" + datatype + "]" );
        }

        /// <summary>
        /// Fixes the default value string.
        /// </summary>
        /// <param name="coldefault">The coldefault.</param>
        /// <returns></returns>
        private string FixDefaultValueString( string coldefault )
        {
            var replaced = false;
            var res = coldefault.Trim();

            // Find first/last indexes in which to search
            var first = -1;
            var last = -1;

            for( var i = 0; i < res.Length; i++ )
            {
                if( res[ i ] == '\''
                    && first == -1 )
                {
                    first = i;
                }

                if( res[ i ] == '\''
                    && first != -1
                    && i > last )
                {
                    last = i;
                }
            }// for

            if( first != -1
                && last > first )
            {
                return res.Substring( first, last - first + 1 );
            }

            var sb = new StringBuilder();

            for( var i = 0; i < res.Length; i++ )
            {
                if( res[ i ] != '('
                    && res[ i ] != ')' )
                {
                    sb.Append( res[ i ] );
                    replaced = true;
                }
            }

            return replaced
                ? "(" + sb + ")"
                : sb.ToString();
        }

        /// <summary>
        /// Creates the foreign key schema.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="ts">The ts.</param>
        [ SuppressMessage( "ReSharper", "BadParensLineBreaks" ) ]
        private void CreateForeignKeySchema( SqlConnection conn, TableSchema ts )
        {
            ts.ForeignKeys = new List<ForeignKeySchema>();

            using var cmd = new SqlCommand(
                $@"SELECT   ColumnName = CU.COLUMNNAME,   ForeignTableName  = PK.TABLENAME,   ForeignColumnName = PT.COLUMNNAME,   DeleteRule = C.DELETERULE,   IsNullable = COL.ISNULLABLE FROM INFORMATIONSCHEMA.REFERENTIALCONSTRAINTS C INNER JOIN INFORMATIONSCHEMA.TABLECONSTRAINTS FK ON C.CONSTRAINTNAME = FK.CONSTRAINTNAME INNER JOIN INFORMATIONSCHEMA.TABLECONSTRAINTS PK ON C.UNIQUECONSTRAINTNAME = PK.CONSTRAINTNAME INNER JOIN INFORMATIONSCHEMA.KEYCOLUMNUSAGE CU ON C.CONSTRAINTNAME = CU.CONSTRAINTNAME INNER JOIN   (     SELECT i1.TABLENAME, i2.COLUMNNAME     FROM  INFORMATIONSCHEMA.TABLECONSTRAINTS i1     INNER JOIN INFORMATIONSCHEMA.KEYCOLUMNUSAGE i2 ON i1.CONSTRAINTNAME = i2.CONSTRAINTNAME     WHERE i1.CONSTRAINTTYPE = 'PRIMARY KEY'   ) PT ON PT.TABLENAME = PK.TABLENAME INNER JOIN INFORMATIONSCHEMA.COLUMNS AS COL ON CU.COLUMNNAME = COL.COLUMNNAME AND FK.TABLENAME = COL.TABLENAME WHERE FK.TableNAME='{ts.TableName}'",
                conn );

            using var reader = cmd.ExecuteReader();

            while( reader.Read() )
            {
                var fkc = new ForeignKeySchema
                {
                    ColumnName = (string)reader[ "ColumnName" ],
                    ForeignTableName = (string)reader[ "ForeignTableName" ],
                    ForeignColumnName = (string)reader[ "ForeignColumnName" ],
                    CascadeOnDelete = (string)reader[ "DeleteRule" ] == "CASCADE",
                    IsNullable = (string)reader[ "IsNullable" ] == "YES",
                    TableName = ts.TableName
                };

                ts.ForeignKeys.Add( fkc );
            }
        }

        /// <summary>
        /// Builds the index schema.
        /// </summary>
        /// <param name="indexname">The indexname.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Illegal key name [" + p + "] in index [" + indexname +
        /// "]</exception>
        private IndexSchema BuildIndexSchema( string indexname, string desc, string keys )
        {
            var res = new IndexSchema
            {
                IndexName = indexname
            };

            // Determine if this is a unique index or not.
            var descparts = desc.Split( ',' );

            for( var i = 0; i < descparts.Length; i++ )
            {
                var p = descparts[ i ];

                if( p.Trim().Contains( "unique" ) )
                {
                    res.IsUnique = true;
                    break;
                }
            }

            // Get all key names and check if they are ASCENDING or DESCENDING
            res.Columns = new List<IndexColumn>();
            var keysparts = keys.Split( ',' );

            foreach( var p in keysparts )
            {
                var m = Keyrx.Match( p.Trim() );

                if( !m.Success )
                {
                    throw new ApplicationException( "Illegal key name ["
                        + p
                        + "] in index ["
                        + indexname
                        + "]" );
                }

                var ic = new IndexColumn();
                res.Columns.Add( ic );
            }// foreach

            return res;
        }

        /// <summary>
        /// Adjusts the default value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns></returns>
        private string AdjustDefaultValue( string val )
        {
            if( string.IsNullOrEmpty( val ) )
            {
                return val;
            }

            var m = Defaultvaluerx.Match( val );

            return m.Success
                ? m.Groups[ 1 ].Value
                : val;
        }

        /// <summary>
        /// Creates the sq lite connection string.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private string CreateSQLiteConnectionString( string path, string password )
        {
            var builder = new SQLiteConnectionStringBuilder
            {
                DataSource = path
            };

            if( password != null )
            {
                builder.Password = password;
            }

            builder.PageSize = 4096;
            builder.UseUTF16Encoding = true;
            var connstring = builder.ConnectionString;
            return connstring;
        }

        /// <summary>
        /// Adds the triggers for foreign keys.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="schema">The schema.</param>
        /// <param name="password">The password.</param>
        private void AddTriggersForForeignKeys( string path, IEnumerable<TableSchema> schema,
            string password )
        {
            // Connect to the newly created database
            var sqliteconnstring = CreateSQLiteConnectionString( path, password );

            using( var conn = new SQLiteConnection( sqliteconnstring ) )
            {
                conn.Open();

                // foreach
                foreach( var dt in schema )
                {
                    try
                    {
                        AddTableTriggers( conn, dt );
                    }
                    catch( Exception ex )
                    {
                        Log.Error( "AddTableTriggers failed", ex );
                        throw;
                    }
                }
            }// using

            Log.Debug( "finished adding triggers to schema" );
        }

        /// <summary>
        /// Adds the table triggers.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="dt">The dt.</param>
        private void AddTableTriggers( SQLiteConnection conn, TableSchema dt )
        {
            var triggers = TriggerBuilder.GetForeignKeyTriggers( dt );

            for( var i = 0; i < triggers.Count; i++ )
            {
                var trigger = triggers[ i ];
                using var cmd = new SQLiteCommand( WriteTriggerSchema( trigger ), conn );
                cmd.ExecuteNonQuery();
            }
        }
    }
}