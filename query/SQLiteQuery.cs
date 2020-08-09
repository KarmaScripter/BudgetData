// <copyright file="SQLiteQuery.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SQLite;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// </summary>
    /// <seealso cref = "Query"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "BadListLineBreaks" ) ]
    public class SQLiteQuery : Query
    {
        // **********************************************************************************************************************
        // ********************************************      FIELDS     *********************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        private protected Provider Provider { get; } = Provider.SQLite;

        // **********************************************************************************************************************
        // ********************************************   CONSTRUCTORS     ******************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "SQLiteQuery"/> class.
        /// </summary>
        public SQLiteQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SQLiteQuery"/> class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        public SQLiteQuery( Source source )
            : base( source, Provider.SQLite, SQL.SELECT )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SQLiteQuery"/> class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public SQLiteQuery( Source source, IDictionary<string, object> dict )
            : base( source, Provider.SQLite, dict, SQL.SELECT )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SQLiteQuery"/> class.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionbuilder.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        public SQLiteQuery( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
            : base( connectionbuilder, sqlstatement )
        {
        }

        // **********************************************************************************************************************
        // ********************************************      PROPERTIES    ******************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// </summary>
        public enum ColDataType
        {
            /// <summary>
            /// The default
            /// </summary>
            Default,

            Text,

            DateTime,

            Integer,

            Decimal,

            Blob
        }

        // **********************************************************************************************************************
        // ********************************************      METHODS    *********************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the data adapter.
        /// </summary>
        /// <param name = "command" >
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        public SQLiteDataAdapter GetDataAdapter( SQLiteCommand command )
        {
            try
            {
                return new SQLiteDataAdapter( command );
            }
            catch( Exception ex )
            {
                using var error = new Error( ex );
                error?.SetText();
                error?.ShowDialog();
                return default;
            }
        }

        /// <summary>
        /// Gets the data reader.
        /// </summary>
        /// <param name = "command" >
        /// The command.
        /// </param>
        /// <returns>
        /// </returns>
        public SQLiteDataReader GetDataReader( SQLiteCommand command )
        {
            try
            {
                return command.ExecuteReader();
            }
            catch( Exception ex )
            {
                using var error = new Error( ex );
                error?.SetText();
                error?.ShowDialog();
                return default;
            }
        }

        /// <summary>
        /// Gets the command builder.
        /// </summary>
        /// <param name = "adapter" >
        /// The adapter.
        /// </param>
        /// <returns>
        /// </returns>
        private SQLiteCommandBuilder GetCommandBuilder( SQLiteDataAdapter adapter )
        {
            try
            {
                return new SQLiteCommandBuilder( adapter );
            }
            catch( SystemException ex )
            {
                using var error = new Error( ex );
                error?.SetText();
                error?.ShowDialog();
                return default;
            }
        }

        /// <summary>
        /// Gets the excel file path.
        /// </summary>
        /// <returns>
        /// </returns>
        private string GetExcelFilePath()
        {
            try
            {
                var fname = "";

                using var fdlg = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( fdlg.ShowDialog() == DialogResult.OK )
                {
                    fname = fdlg.FileName;
                }

                return fname;
            }
            catch( Exception ex )
            {
                using var error = new Error( ex );
                error?.SetText();
                error?.ShowDialog();
                return default;
            }
        }

        /// <summary>
        /// Creates the table from excel file.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CreateTableFromExcelFile( string filepath, ref string sheetname )
        {
            if( Verify.Input( filepath )
                && Verify.Input( sheetname ) )
            {
                try
                {
                    using var dataset = new DataSet();
                    var cstring = GetExcelFilePath();
                    var sql = "SELECT * FROM [" + sheetname + "]";
                    var msg = "Sheet Does Not Exist!";
                    using var excelquery = new ExcelQuery( cstring );
                    using var connection = excelquery.GetConnection() as OleDbConnection;
                    connection?.Open();
                    using var table = connection?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( table != null
                        && table.Rows.Count > 0
                        && CheckIfSheetNameExists( sheetname, table ) )
                    {
                        using var message = new Message( msg );
                        message?.ShowDialog();
                    }
                    else
                    {
                        sheetname = table?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var adapter = new OleDbDataAdapter( sql, connection );
                    adapter.Fill( dataset, sheetname );
                    return dataset.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Creates the table from CSV file.
        /// </summary>
        /// <param name = "filename" >
        /// The filename.
        /// </param>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CreateTableFromCsvFile( string filename, ref string sheetname )
        {
            if( Verify.Input( filename )
                && Verify.Input( sheetname ) )
            {
                try
                {
                    using var dataset = new DataSet();
                    using var datatable = new DataTable();
                    dataset.DataSetName = filename;
                    datatable.TableName = sheetname;
                    dataset.Tables.Add( datatable );
                    var cstring = GetExcelFilePath();

                    if( Verify.Input( cstring ) )
                    {
                        using var csvquery = new CsvQuery( cstring );
                        var select = csvquery.GetCommand();
                        using var connection = csvquery.GetConnection() as OleDbConnection;
                        using var adapter = new OleDbDataAdapter( select.CommandText, connection );
                        adapter?.Fill( dataset, sheetname );

                        return datatable.Columns.Count > 0
                            ? datatable
                            : default;
                    }
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<DbParameter> GetParameters( Dictionary<string, object> dict )
        {
            try
            {
                return dict.Keys.Any()
                    ? dict.ToSqlDbParameters( Provider )
                    : default;
            }
            catch( Exception ex )
            {
                using var error = new Error( ex );
                error?.SetText();
                error?.ShowDialog();
                return default;
            }
        }

        /// <summary>
        /// Checks if sheet name exists.
        /// </summary>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
        /// <param name = "dtschema" >
        /// The dtschema.
        /// </param>
        /// <returns>
        /// </returns>
        private bool CheckIfSheetNameExists( string sheetname, DataTable dtschema )
        {
            for( var i = 0; i < dtschema.Rows.Count; i++ )
            {
                var datarow = dtschema.Rows[ i ];

                if( sheetname == datarow[ "TABLENAME" ].ToString() )
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Creates the database.
        /// </summary>
        private void CreateDatabase()
        {
            var createtablequery = @"CREATE TABLE IF NOT EXISTS [MyTable] (
                                    [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                    [Key] NVARCHAR(2048)  NULL,
                                    [Value] VARCHAR(2048)  NULL
                                    )";

            SQLiteConnection.CreateFile( "databaseFile.db3" );
            using var connection = new SQLiteConnection( "data source=databaseFile.db3" );
            using var command = new SQLiteCommand( connection );
            connection.Open();
            command.CommandText = createtablequery;
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO MyTable (Key,Value) Values ('key one','value one')";
            command.ExecuteNonQuery();

            // Add another entry into our database 
            command.CommandText = "INSERT INTO MyTable (Key,Value) Values ('key two','value value')";

            // Execute the query
            command.ExecuteNonQuery();
            command.CommandText = "Select * FROM MyTable";
            using var reader = command.ExecuteReader();

            while( reader.Read() )
            {
                Console.WriteLine( reader[ "Key" ] + " : " + reader[ "Value" ] );
            }

            connection.Close();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name = "disposing" >
        /// <c>
        /// true
        /// </c>
        /// to release both managed and unmanaged resources;
        /// <c>
        /// false
        /// </c>
        /// to release only unmanaged resources.
        /// </param>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                base.Dispose();
            }

            IsDisposed = true;
        }
    }
}
