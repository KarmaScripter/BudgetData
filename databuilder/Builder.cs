// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Data.OleDb;
    using System.IO;
    using OfficeOpenXml;

    /// <summary> </summary>
    /// <seealso cref = "BuilderBase"/>
    /// <seealso cref = "System.IDisposable"/>
    /// <seealso cref = "IBuilder"/>
    [ SuppressMessage( "ReSharper", "ImplicitlyCapturedClosure" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" ) ]
    public class Builder : BuilderBase, IBuilder
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Builder"/>
        /// class.
        /// </summary>
        public Builder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Builder"/>
        /// class.
        /// </summary>
        /// <param name = "source" > The source. </param>
        /// <param name = "provider" > The provider. </param>
        public Builder( Source source, Provider provider = Provider.SQLite )
        {
            Source = source;
            Provider = provider;
            ConnectionBuilder = new ConnectionBuilder( source, provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, SQL.SELECT );
            SetQuery( ConnectionBuilder, SqlStatement );
            ProgramElements = GetSeries( GetDataTable() );
            Record = GetData()?.FirstOrDefault();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Builder"/>
        /// class.
        /// </summary>
        /// <param name = "source" > The source. </param>
        /// <param name = "provider" > The provider. </param>
        /// <param name = "dict" > The dictionary. </param>
        public Builder( Source source, Provider provider, IDictionary<string, object> dict )
        {
            Source = source;
            Provider = provider;
            ConnectionBuilder = new ConnectionBuilder( source, provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, SQL.SELECT );
            SetQuery( ConnectionBuilder, SqlStatement );
            ProgramElements = GetSeries( GetDataTable() );
            Record = GetRecord();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Builder"/>
        /// class.
        /// </summary>
        /// <param name = "source" > The source. </param>
        /// <param name = "dict" > The dictionary. </param>
        public Builder( Source source, IDictionary<string, object> dict )
        {
            Source = source;
            Provider = Provider.SQLite;
            ConnectionBuilder = new ConnectionBuilder( Source, Provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, SQL.SELECT );
            SetQuery( ConnectionBuilder, SqlStatement );
            ProgramElements = GetSeries( GetDataTable() );
            Record = GetRecord();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Builder"/>
        /// class.
        /// </summary>
        /// <param name = "query" > The query. </param>
        public Builder( IQuery query )
        {
            Query = query;
            Source = ConnectionBuilder.GetSource();
            Provider = ConnectionBuilder.GetProvider();
            ConnectionBuilder = Query.GetConnectionBuilder();
            SqlStatement = Query.GetSqlStatement();
            ProgramElements = GetSeries( GetDataTable() );
            Record = GetRecord();
            Args = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary> Gets the program elements. </summary>
        /// <value> The program elements. </value>
        public IDictionary<string, IEnumerable<string>> ProgramElements { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the unique field values. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "column" > The column. </param>
        /// <returns> </returns>
        public static IEnumerable<string> GetValues( IEnumerable<DataRow> data, string column )
        {
            if( Verify.Sequence( data )
                && Verify.Input( column ) )
            {
                try
                {
                    var query = data?.Select( p => p.Field<string>( column ) )?.Distinct();

                    return query?.Any() == true
                        ? query
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the unique field values. </summary>
        /// <param name = "data" > The table. </param>
        /// <param name = "field" > The column. </param>
        /// <param name = "filter" > The filter. </param>
        /// <returns> </returns>
        public static IEnumerable<string> GetValues( IEnumerable<DataRow> data, Field field, string filter )
        {
            if( Verify.Sequence( data )
                && Validate.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var query = data?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        ?.Select( p => p.Field<string>( $"{field}" ) )
                        ?.Distinct();

                    return query?.Any() == true
                        ? query
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the program elements. </summary>
        /// <param name = "data" > The data. </param>
        /// <returns> </returns>
        private static IDictionary<string, IEnumerable<string>> GetSeries( DataTable data )
        {
            if( Verify.Table( data ) )
            {
                try
                {
                    var dict = new Dictionary<string, IEnumerable<string>>();
                    var columns = data.Columns;

                    for( var i = 0; i < columns?.Count; i++ )
                    {
                        if( Verify.Input( columns[ i ]?.ColumnName )
                            && columns[ i ]?.DataType == typeof( string ) )
                        {
                            dict?.Add( columns[ i ]?.ColumnName,
                                GetValues( data?.AsEnumerable(), columns[ i ]?.ColumnName ) );
                        }
                    }

                    return dict?.Any() == true
                        ? dict
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the schema table. </summary>
        /// <param name = "datatable" > The datatable. </param>
        /// <returns> </returns>
        public static DataTable GetSchemaTable( DataTable datatable )
        {
            if( Verify.Table( datatable ) )
            {
                try
                {
                    using var reader = new DataTableReader( datatable );
                    var schema = reader?.GetSchemaTable();

                    return schema?.Rows?.Count > 0
                        ? schema
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Creates the table from excel. </summary>
        /// <param name = "filepath" > The filepath. </param>
        /// <returns> </returns>
        public static DataTable CreateTableFromExcel( string filepath )
        {
            if( Verify.Input( filepath )
                && File.Exists( filepath ) )
            {
                try
                {
                    var sheets = 0;

                    var connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                        + filepath
                        + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";

                    using var connection = new OleDbConnection( connectionstring );
                    connection?.Open();
                    using var dataset = new DataSet();
                    using var schematable = connection?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );
                    var sheetname = string.Empty;

                    if( schematable != null )
                    {
                        var datatable = schematable?.AsEnumerable()
                            ?.Where( r => r.Field<string>( "TABLE_NAME" ).Contains( "FilterDatabase" ) )
                            ?.Select( r => r )
                            ?.CopyToDataTable();

                        sheetname = datatable.Rows[ 0 ][ "TABLE_NAME" ].ToString();
                    }

                    using var command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [" + sheetname + "]";
                    using var adapter = new OleDbDataAdapter( command );
                    adapter.Fill( dataset, "excelData" );
                    using var table = dataset.Tables[ "ExcelData" ];
                    connection.Close();
                    return table;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Loads from excel. </summary>
        /// <param name = "filepath" > The path. </param>
        /// <param name = "header" >
        /// if set to
        /// <c> true </c>
        /// [header].
        /// </param>
        /// <returns> </returns>
        public static DataTable CreateTableFromExcel( string filepath, bool header = true )
        {
            if( Verify.Input( filepath )
                && File.Exists( filepath ) )
            {
                try
                {
                    using var excel = new ExcelPackage();
                    using var stream = File.OpenRead( filepath );
                    excel.Load( stream );
                    var worksheet = excel?.Workbook?.Worksheets?.First();
                    var table = new DataTable( worksheet?.Name );

                    if( worksheet?.Cells != null )
                    {
                        foreach( var firstrowcell in worksheet?.Cells[ 1, 1, 1,
                            worksheet.Dimension.End.Column ] )
                        {
                            table.Columns.Add( header
                                ? firstrowcell.Text
                                : $"Column {firstrowcell.Start.Column}" );
                        }

                        var startrow = header
                            ? 2
                            : 1;

                        for( var rownum = startrow; rownum <= worksheet.Dimension.End.Row; rownum++ )
                        {
                            var range = worksheet.Cells[ rownum, 1, rownum, worksheet.Dimension.End.Column ];
                            var row = table.Rows.Add();

                            foreach( var cell in range )
                            {
                                row[ cell.Start.Column - 1 ] = cell.Text;
                            }
                        }
                    }

                    return table;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the program elements. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "field" > The field. </param>
        /// <param name = "filter" > The filter. </param>
        /// <returns> </returns>
        public static IDictionary<string, IEnumerable<string>> GetSeries( IEnumerable<DataRow> data,
            Field field, string filter )
        {
            if( Verify.Input( data )
                && Validate.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var datatable = data.CopyToDataTable();
                    var columns = datatable?.Columns;
                    var dict = new Dictionary<string, IEnumerable<string>>();
                    var values = GetValues( data, field, filter );

                    if( values?.Any() == true )
                    {
                        for( var i = 0; i < columns?.Count; i++ )
                        {
                            var name = columns[ i ].ColumnName;

                            if( Verify.Input( name )
                                && columns[ i ]?.DataType == typeof( string ) )
                            {
                                dict.Add( columns[ i ].ColumnName, values );
                            }
                        }

                        return dict?.Any() == true
                            ? dict
                            : default;
                    }

                    return default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the data builder. </summary>
        /// <returns> </returns>
        public IBuilder GetBuilder()
        {
            try
            {
                return Query != null
                    ? MemberwiseClone() as Builder
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary> Filters the specified data. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "field" > The column. </param>
        /// <param name = "filter" > The filter. </param>
        /// <returns> </returns>
        public static IEnumerable<DataRow> FilterData( IEnumerable<DataRow> data, Field field, string filter )
        {
            if( Verify.Sequence( data )
                && Verify.Input( filter )
                && Validate.Field( field ) )
            {
                try
                {
                    var query = data?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        ?.Select( p => p );

                    return query?.Any() == true
                        ? query.ToArray()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }
    }
}