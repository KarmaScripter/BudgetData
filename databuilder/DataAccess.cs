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

    /// <summary> </summary>
    /// <seealso cref = "IDataAccess"/>
    [SuppressMessage( "ReSharper", "ImplicitlyCapturedClosure" )]
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "MemberCanBeInternal" )]
    [SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" )]
    [SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" )]
    public abstract class DataAccess : DataConfig, ISource, IProvider
    {
        /// <summary> Gets the query. </summary>
        /// <returns> </returns>
        public IQuery GetQuery()
        {
            try
            {
                return _query ?? new Query( _connectionBuilder, _sqlStatement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IQuery );
            }
        }

        /// <summary> Gets the dataRows. </summary>
        /// <returns> </returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Table( _dataTable ) )
            {
                try
                {
                    var _data = _dataTable
                        ?.AsEnumerable();

                    return Verify.Rows( _data )
                        ? _data
                        : default( EnumerableRowCollection<DataRow> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<DataRow> );
                }
            }

            return default( IEnumerable<DataRow> );
        }

        /// <summary> Gets the dataRows table. </summary>
        /// <returns> </returns>
        public DataTable GetDataTable()
        {
            if( Verify.Table( _dataTable ) )
            {
                try
                {
                    _dataSet = new DataSet( $"{_source}" )
                    {
                        DataSetName = $"{_source}"
                    };

                    _dataTable = new DataTable( $"{_source}" );
                    _dataTable.TableName = $"{_source}";
                    _dataSet.Tables.Add( _dataTable );
                    var _adapter = _query?.GetAdapter();
                    _adapter?.Fill( _dataSet, _dataTable.TableName );
                    SetColumnCaptions( _dataTable );

                    return _dataTable?.Rows?.Count > 0
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

        /// <summary> Gets the dataRows set. </summary>
        /// <returns> </returns>
        public DataSet GetDataSet()
        {
            if( Enum.IsDefined( typeof( Source ), _source ) )
            {
                try
                {
                    _dataSet = new DataSet( "DataSet" )
                    {
                        DataSetName = "DataSet"
                    };

                    var _table = new DataTable( $"{_source}" );
                    _table.TableName = $"{_source}";
                    _dataSet.Tables.Add( _table );
                    using var _adapter = _query?.GetAdapter();
                    _adapter?.Fill( _dataSet, _table?.TableName );
                    SetColumnCaptions( _table );

                    return _table?.Rows?.Count > 0
                        ? _dataSet
                        : default( DataSet );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataSet );
                }
            }

            return default( DataSet );
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns></returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( _source )
                    ? _source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Provider GetProvider()
        {
            try
            {
                return Validate.Provider( _provider )
                    ? _provider
                    : Provider.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Provider.NS;
            }
        }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <returns></returns>
        public DataRow GetRecord()
        {
            try
            {
                return Verify.Row( _record )
                    ? _record
                    : default( DataRow );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataRow );
            }
        }

        /// <summary> Sets the column captions. </summary>
        /// <param name = "dataTable" > The dataTable. </param>
        public void SetColumnCaptions( DataTable dataTable )
        {
            if( Verify.Table( dataTable ) )
            {
                try
                {
                    foreach( DataColumn column in dataTable.Columns )
                    {
                        if( column?.ColumnName?.Length < 5 )
                        {
                            var _caption = column.ColumnName.ToUpper();
                            column.Caption = _caption;
                            continue;
                        }

                        if( column?.ColumnName?.Length >= 5 )
                        {
                            column.Caption = column.ColumnName.SplitPascal();
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Gets the column schema. </summary>
        /// <returns> </returns>
        public DataColumnCollection GetColumnSchema()
        {
            try
            {
                var _table = GetDataTable();
                SetColumnCaptions( _table );

                _dataSet = new DataSet( $"{_source}" )
                {
                    DataSetName = $"{_source}"
                };

                var _datatable = new DataTable( $"{_source}" );
                _datatable.TableName = $"{_source}";
                _dataSet.Tables.Add( _datatable );
                using var _adapter = _query?.GetAdapter();
                _adapter?.Fill( _dataSet, _datatable.TableName );
                SetColumnCaptions( _datatable );

                return _table.Columns.Count > 0
                    ? _table.Columns
                    : default( DataColumnCollection );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataColumnCollection );
            }
        }

        /// <summary> Gets the primary keys. </summary>
        /// <param name = "dataRows" > The dataRows. </param>
        /// <returns> </returns>
        public IEnumerable<int> GetPrimaryIndexes( IEnumerable<DataRow> dataRows )
        {
            if( Verify.Input( dataRows )
                && dataRows?.HasPrimaryKey() == true )
            {
                try
                {
                    var _table = dataRows?.CopyToDataTable();
                    var _values = _table?.GetPrimaryKeyValues();

                    return _values?.Any() == true
                        ? _values.ToArray()
                        : default( IEnumerable<int> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<int> );
                }
            }

            return default( IEnumerable<int> );
        }

        /// <summary> Gets the column ordinals. </summary>
        /// <param name = "dataColumns" > The dataRows. </param>
        /// <returns> </returns>
        public IEnumerable<int> GetColumnOrdinals( IEnumerable<DataColumn> dataColumns )
        {
            if( Verify.Sequence( dataColumns ) )
            {
                try
                {
                    var _list = dataColumns.ToList();
                    var _values = new List<int>();

                    if( _list?.Any() == true )
                    {
                        foreach( var column in _list )
                        {
                            _values.Add( column.Ordinal );
                        }
                    }

                    return _values?.Any() == true
                        ? _values.ToArray()
                        : default( int[ ] );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<int> );
                }
            }

            return default( IEnumerable<int> );
        }
    }
}