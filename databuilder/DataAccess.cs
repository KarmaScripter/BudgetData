// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
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
    /// <seealso cref="BudgetExecution.DataConfig" />
    /// <seealso cref="BudgetExecution.ISource" />
    /// <seealso cref="BudgetExecution.IProvider" />
    [ SuppressMessage( "ReSharper", "ImplicitlyCapturedClosure" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" ) ]
    public abstract class DataAccess : DataConfig, ISource, IProvider
    {
        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns></returns>
        public IQuery GetQuery()
        {
            try
            {
                return Query ?? new Query( ConnectionBuilder, SqlStatement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IQuery );
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataRow> GetData()
        {
            if( Verify.Table( DataTable ) )
            {
                try
                {
                    var _data = DataTable
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

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            if( Verify.Table( DataTable ) )
            {
                try
                {
                    DataSet = new DataSet( $"{Source}" )
                    {
                        DataSetName = $"{Source}"
                    };

                    DataTable = new DataTable( $"{Source}" );
                    DataTable.TableName = $"{Source}";
                    DataSet.Tables.Add( DataTable );
                    var _adapter = Query?.GetAdapter();
                    _adapter?.Fill( DataSet, DataTable.TableName );
                    SetColumnCaptions( DataTable );

                    return DataTable?.Rows?.Count > 0
                        ? DataTable
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
        /// Gets the data set.
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            if( Enum.IsDefined( typeof( Source ), Source ) )
            {
                try
                {
                    DataSet = new DataSet( "DataSet" )
                    {
                        DataSetName = "DataSet"
                    };

                    var _table = new DataTable( $"{Source}" );
                    _table.TableName = $"{Source}";
                    DataSet.Tables.Add( _table );
                    using var _adapter = Query?.GetAdapter();
                    _adapter?.Fill( DataSet, _table?.TableName );
                    SetColumnCaptions( _table );

                    return _table?.Rows?.Count > 0
                        ? DataSet
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
                return Validate.Source( Source )
                    ? Source
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
                return Validate.Provider( Provider )
                    ? Provider
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
                return Verify.Row( Record )
                    ? Record
                    : default( DataRow );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataRow );
            }
        }

        /// <summary>
        /// Sets the column captions.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public void SetColumnCaptions( DataTable dataTable )
        {
            if( Verify.Table( dataTable ) )
            {
                try
                {
                    foreach( DataColumn _column in dataTable.Columns )
                    {
                        switch( _column?.ColumnName?.Length )
                        {
                            case < 5:
                            {
                                var _caption = _column.ColumnName.ToUpper();
                                _column.Caption = _caption;
                                continue;
                            }

                            case >= 5:
                                _column.Caption = _column.ColumnName.SplitPascal();
                                break;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the column schema.
        /// </summary>
        /// <returns></returns>
        public DataColumnCollection GetColumnSchema()
        {
            try
            {
                var _table = GetDataTable();
                SetColumnCaptions( _table );

                DataSet = new DataSet( $"{Source}" )
                {
                    DataSetName = $"{Source}"
                };

                var _datatable = new DataTable( $"{Source}" );
                _datatable.TableName = $"{Source}";
                DataSet.Tables.Add( _datatable );
                using var _adapter = Query?.GetAdapter();
                _adapter?.Fill( DataSet, _datatable.TableName );
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

        /// <summary>
        /// Gets the primary indexes.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the column ordinals.
        /// </summary>
        /// <param name="dataColumns">The data columns.</param>
        /// <returns></returns>
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