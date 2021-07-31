// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Data.OleDb;
    using System.IO;
    using OfficeOpenXml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.BuilderBase" />
    /// <seealso cref="BudgetExecution.IBuilder" />
    [ SuppressMessage( "ReSharper", "ImplicitlyCapturedClosure" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class Builder : BuilderBase, IBuilder
    {
        /// <summary>
        /// The program elements
        /// </summary>
        private protected readonly IDictionary<string, IEnumerable<string>> _programElements;

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        public Builder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        public Builder( Source source, Provider provider = Provider.SQLite )
        {
            Source = source;
            Provider = provider;
            ConnectionBuilder = new ConnectionBuilder( source, provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, SQL.SELECT );
            SetQuery( ConnectionBuilder, SqlStatement );
            _programElements = GetSeries( GetDataTable() );
            Record = GetData()?.FirstOrDefault();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="dict">The dictionary.</param>
        public Builder( Source source, Provider provider, IDictionary<string, object> dict )
        {
            Source = source;
            Provider = provider;
            ConnectionBuilder = new ConnectionBuilder( source, provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, SQL.SELECT );
            SetQuery( ConnectionBuilder, SqlStatement );
            _programElements = GetSeries( GetDataTable() );
            Record = GetRecord();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="dict">The dictionary.</param>
        public Builder( Source source, IDictionary<string, object> dict )
        {
            Source = source;
            Provider = Provider.SQLite;
            ConnectionBuilder = new ConnectionBuilder( Source, Provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, SQL.SELECT );
            SetQuery( ConnectionBuilder, SqlStatement );
            _programElements = GetSeries( GetDataTable() );
            Record = GetRecord();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public Builder( IQuery query )
        {
            Query = query;
            Source = ConnectionBuilder.GetSource();
            Provider = ConnectionBuilder.GetProvider();
            ConnectionBuilder = Query.GetConnectionBuilder();
            SqlStatement = Query.GetSqlStatement();
            _programElements = GetSeries( GetDataTable() );
            Record = GetRecord();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetValues( IEnumerable<DataRow> data, string column )
        {
            if( Verify.Sequence( data )
                && Verify.Input( column ) )
            {
                try
                {
                    var _query = data?.Select( p => p.Field<string>( column ) )?.Distinct();

                    return _query?.Any() == true
                        ? _query
                        : default( IEnumerable<string> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetValues( IEnumerable<DataRow> data, Field field,
            string filter )
        {
            if( Verify.Sequence( data )
                && Validate.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var _query = data?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        ?.Select( p => p.Field<string>( $"{field}" ) )?.Distinct();

                    return _query?.Any() == true
                        ? _query
                        : default( IEnumerable<string> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }

        /// <summary>
        /// Gets the schema table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static DataTable GetSchemaTable( DataTable dataTable )
        {
            if( Verify.Table( dataTable ) )
            {
                try
                {
                    using var _reader = new DataTableReader( dataTable );
                    var _schema = _reader?.GetSchemaTable();

                    return _schema?.Rows?.Count > 0
                        ? _schema
                        : default( DataTable );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Creates the table from excel.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static DataTable CreateTableFromExcel( string filePath )
        {
            if( Verify.Input( filePath )
                && File.Exists( filePath ) )
            {
                try
                {
                    var _sheets = 0;

                    var _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                        + filePath
                        + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";

                    using var _connection = new OleDbConnection( _connectionString );
                    _connection?.Open();
                    using var _dataSet = new DataSet();

                    using var _schemaTable =
                        _connection?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    var _sheetName = string.Empty;

                    if( _schemaTable != null )
                    {
                        var _dataTable = _schemaTable?.AsEnumerable()
                            ?.Where( r =>
                                r.Field<string>( "TABLE_NAME" ).Contains( "FilterDatabase" ) )
                            ?.Select( r => r )?.CopyToDataTable();

                        _sheetName = _dataTable.Rows[ 0 ][ "TABLE_NAME" ].ToString();
                    }

                    using var _command = new OleDbCommand();
                    _command.Connection = _connection;
                    _command.CommandText = "SELECT * FROM [" + _sheetName + "]";
                    using var _dataAdapter = new OleDbDataAdapter( _command );
                    _dataAdapter.Fill( _dataSet, "excelData" );
                    using var table = _dataSet.Tables[ "ExcelData" ];
                    _connection.Close();
                    return table;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Creates the table from excel.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="header">if set to <c>true</c> [header].</param>
        /// <returns></returns>
        public static DataTable CreateTableFromExcel( string filePath, bool header = true )
        {
            if( Verify.Input( filePath )
                && File.Exists( filePath ) )
            {
                try
                {
                    using var _excelPackage = new ExcelPackage();
                    using var _fileStream = File.OpenRead( filePath );
                    _excelPackage.Load( _fileStream );
                    var _excelWorksheet = _excelPackage?.Workbook?.Worksheets?.First();
                    var _dataTable = new DataTable( _excelWorksheet?.Name );

                    if( _excelWorksheet?.Cells != null )
                    {
                        foreach( var firstrowcell in _excelWorksheet?.Cells[ 1, 1, 1,
                            _excelWorksheet.Dimension.End.Column ] )
                        {
                            _dataTable.Columns.Add( header
                                ? firstrowcell.Text
                                : $"Column {firstrowcell.Start.Column}" );
                        }

                        var _startRow = header
                            ? 2
                            : 1;

                        for( var _row = _startRow; _row <= _excelWorksheet.Dimension.End.Row;
                            _row++ )
                        {
                            var _excelRange = _excelWorksheet.Cells[ _row, 1, _row,
                                _excelWorksheet.Dimension.End.Column ];

                            var _dataRow = _dataTable.Rows.Add();

                            foreach( var cell in _excelRange )
                            {
                                _dataRow[ cell.Start.Column - 1 ] = cell.Text;
                            }
                        }
                    }

                    return _dataTable?.Rows.Count > 0
                        ? _dataTable
                        : default( DataTable );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Gets the series.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static IDictionary<string, IEnumerable<string>> GetSeries( IEnumerable<DataRow> data,
            Field field, string filter )
        {
            if( Verify.Input( data )
                && Validate.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var _dataTable = data.CopyToDataTable();
                    var _columns = _dataTable?.Columns;
                    var _dict = new Dictionary<string, IEnumerable<string>>();
                    var _values = GetValues( data, field, filter );

                    if( _values?.Any() == true )
                    {
                        for( var i = 0; i < _columns?.Count; i++ )
                        {
                            var _columnName = _columns[ i ].ColumnName;

                            if( Verify.Input( _columnName )
                                && _columns[ i ]?.DataType == typeof( string ) )
                            {
                                _dict.Add( _columns[ i ].ColumnName, _values );
                            }
                        }

                        return _dict?.Any() == true
                            ? _dict
                            : default( Dictionary<string, IEnumerable<string>> );
                    }

                    return default( IDictionary<string, IEnumerable<string>> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, IEnumerable<string>> );
                }
            }

            return default( IDictionary<string, IEnumerable<string>> );
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <returns></returns>
        public IBuilder GetBuilder()
        {
            try
            {
                return Query != null
                    ? MemberwiseClone() as Builder
                    : default( Builder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBuilder );
            }
        }

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static IEnumerable<DataRow> FilterData( IEnumerable<DataRow> data, Field field,
            string filter )
        {
            if( Verify.Sequence( data )
                && Verify.Input( filter )
                && Validate.Field( field ) )
            {
                try
                {
                    var _query = data?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        ?.Select( p => p );

                    return _query?.Any() == true
                        ? _query.ToArray()
                        : default( DataRow[ ] );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }

        /// <summary>
        /// Gets the series.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static IDictionary<string, IEnumerable<string>> GetSeries( DataTable data )
        {
            if( Verify.Table( data ) )
            {
                try
                {
                    var _dict = new Dictionary<string, IEnumerable<string>>();
                    var _columns = data.Columns;

                    for( var i = 0; i < _columns?.Count; i++ )
                    {
                        if( Verify.Input( _columns[ i ]?.ColumnName )
                            && _columns[ i ]?.DataType == typeof( string ) )
                        {
                            _dict?.Add( _columns[ i ]?.ColumnName,
                                GetValues( data?.AsEnumerable(),
                                    _columns[ i ]?.ColumnName ) );
                        }
                    }

                    return _dict?.Any() == true
                        ? _dict
                        : default( Dictionary<string, IEnumerable<string>> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, IEnumerable<string>> );
                }
            }

            return default( IDictionary<string, IEnumerable<string>> );
        }
    }
}