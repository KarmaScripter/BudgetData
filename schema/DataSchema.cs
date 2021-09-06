// <copyright file = "DataSchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IDataSchema"/>
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    public class DataSchema : ISource, IDataSchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "DataSchema"/> class.
        /// </summary>
        public DataSchema()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "DataSchema"/> class.
        /// </summary>
        /// <param name = "table" >
        /// The Table.
        /// </param>
        public DataSchema( DataTable table )
        {
            _name = table?.TableName;
            _data = table?.AsEnumerable();
            IsSource = Resource.Sources.Contains( _name );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "DataSchema"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public DataSchema( IEnumerable<DataRow> data )
        {
            _name = data?.CopyToDataTable()?.TableName;
            _data = data;
            IsSource = Resource.Sources.Contains( _name );
        }

        /// <summary>
        /// Gets the name of the Table.
        /// </summary>
        /// <value>
        /// The name of the Table.
        /// </value>
        private protected readonly string _name;

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected readonly IEnumerable<DataRow> _data;

        /// <summary>
        /// Gets a value indicating whether this instance is source.
        /// </summary>
        /// <value>
        /// <c>
        /// true
        /// </c>
        /// if this instance is source; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </value>
        [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
        public bool IsSource { get; }

        /// <summary>
        /// Sets the column names.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<string> GetColumnNames()
        {
            try
            {
                var _list = new List<string>();
                var _dataTable = _data?.CopyToDataTable();

                if( _dataTable?.Columns != null )
                {
                    foreach( DataColumn datacolumn in _dataTable?.Columns )
                    {
                        _list.Add( datacolumn?.ColumnName );
                    }
                }

                return _list?.Any() == true
                    ? _list
                    : default( List<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Gets the column captions.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<string> GetColumnCaptions()
        {
            try
            {
                var _schema = _data?.CopyToDataTable()?.Columns;
                var _list = new List<string>();

                if( _schema != null )
                {
                    foreach( DataColumn caption in _schema )
                    {
                        if( Verify.Input( caption.Caption ) )
                        {
                            _list.Add( caption.Caption );
                        }
                        else if( Verify.Input( caption.ColumnName ) )
                        {
                            _list.Add( caption.ColumnName.SplitPascal() );
                        }
                    }
                }

                return _list?.Any() == true
                    ? _list
                    : default( List<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Gets the column ordinals.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<int> GetColumnOrdinals()
        {
            try
            {
                var _schema = _data
                    ?.CopyToDataTable()
                    ?.Columns;

                var _list = new List<int>();

                if( _schema != null )
                {
                    foreach( DataColumn column in _schema )
                    {
                        _list.Add( column.Ordinal );
                    }
                }

                return _list?.Any() == true
                    ? _list
                    : default( List<int> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<int> );
            }
        }

        /// <summary>
        /// Sets the column types.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<Type> GetColumnTypes()
        {
            try
            {
                var _list = new List<Type>();
                var _dataTable = _data?.CopyToDataTable();

                if( _dataTable?.Columns != null )
                {
                    foreach( DataColumn datacolumn in _dataTable?.Columns )
                    {
                        _list.Add( datacolumn?.DataType );
                    }
                }

                return _list?.Any() == true
                    ? _list
                    : default( List<Type> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<Type> );
            }
        }

        /// <summary>
        /// Sets the primary keys.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<int> GetIndexes()
        {
            try
            {
                var _list = new List<int>();
                var _dataTable = _data?.CopyToDataTable();

                if( _dataTable?.Rows != null )
                {
                    foreach( DataRow datarow in _dataTable?.Rows )
                    {
                        if( datarow?.HasPrimaryKey() == true )
                        {
                            var key = datarow
                                ?.GetPrimaryKey()
                                ?.ToArray();

                            if( key?.Any() == true )
                            {
                                _list.Add( (int)key[ 0 ].Value );
                            }
                        }
                    }
                }

                return _list?.Any() == true
                    ? _list
                    : default( List<int> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<int> );
            }
        }

        /// <summary>
        /// Gets the primary key columns.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataColumn> GetPrimaryKeyColumn()
        {
            try
            {
                var _primaryKey = _data?.CopyToDataTable()?.PrimaryKey;

                return _primaryKey?.Any() == true
                    ? _primaryKey?.ToArray()
                    : default( DataColumn[ ] );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<DataColumn> );
            }
        }

        /// <summary>
        /// Gets the column schema.
        /// </summary>
        /// <returns>
        /// </returns>
        public DataColumnCollection GetColumnSchema()
        {
            try
            {
                return Verify.Rows( _data )
                    ? _data?.CopyToDataTable()?.Columns
                    : default( DataColumnCollection );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataColumnCollection );
            }
        }

        /// <summary>
        /// Gets the schema table.
        /// </summary>
        /// <returns>
        /// </returns>
        public DataTable GetSchemaTable()
        {
            try
            {
                using var _dataTableReader = new DataTableReader( _data.CopyToDataTable() );
                return _dataTableReader?.GetSchemaTable();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary>
        /// Gets the data Table.
        /// </summary>
        /// <returns>
        /// </returns>
        public DataTable GetDataTable()
        {
            try
            {
                return Verify.Rows( _data )
                    ? _data?.CopyToDataTable()
                    : default( DataTable );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary>
        /// Gets the name of the Table.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetTableName()
        {
            try
            {
                return Verify.Input( _name )
                    ? _name
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            try
            {
                return Verify.Rows( _data )
                    ? _data
                    : default( IEnumerable<DataRow> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<DataRow> );
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Input( _name ) && IsSource
                    ? (Source)Enum.Parse( typeof( Source ), _name )
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
