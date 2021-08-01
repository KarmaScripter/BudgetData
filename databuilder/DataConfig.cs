// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    public abstract class DataConfig  
    {
        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The connection builder
        /// </summary>
        private protected IConnectionBuilder _connectionBuilder;

        /// <summary>
        /// The arguments
        /// </summary>
        private protected IDictionary<string, object> _args;

        /// <summary>
        /// The SQL statement
        /// </summary>
        private protected ISqlStatement _sqlStatement;

        /// <summary>
        /// The query
        /// </summary>
        private protected IQuery _query;

        /// <summary>
        /// The record
        /// </summary>
        private protected DataRow _record;

        /// <summary>
        /// The data table
        /// </summary>
        private protected DataTable _dataTable;

        /// <summary>
        /// The data set
        /// </summary>
        private protected DataSet _dataSet;

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="source">The source.</param>
        private protected void SetSource( Source source )
        {
            if( Validate.Source( source ) )
            {
                try
                {
                    _source = source;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private protected void SetProvider( Provider provider )
        {
            if( Validate.Provider( provider ) )
            {
                try
                {
                    _provider = provider;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the query.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        private protected void SetQuery( IConnectionBuilder connectionBuilder )
        {
            if( Validate.Source( _source )
                && Validate.Provider( _provider ) )
            {
                try
                {
                    switch( _provider )
                    {
                        case Provider.SQLite:
                        {
                            _query = new SQLiteQuery( _source );
                            break;
                        }

                        case Provider.SqlServer:
                        {
                            _query = new SqlServerQuery( _source );
                            break;
                        }

                        case Provider.SqlCe:
                        {
                            _query = new SqlCeQuery( _source );
                            break;
                        }

                        case Provider.Access:
                        {
                            _query = new AccessQuery( _source );
                            break;
                        }

                        case Provider.OleDb:
                        {
                            var _filePath = connectionBuilder?.GetFilePath();

                            _query = Verify.Input( _filePath )
                                && File.Exists( _filePath )
                                    ? new ExcelQuery( _filePath )
                                    : default( ExcelQuery );

                            break;
                        }

                        case Provider.Excel:
                        {
                            var _filePath = connectionBuilder?.GetFilePath();
                            _query = new ExcelQuery( _filePath );
                            break;
                        }

                        case Provider.CSV:
                        {
                            var _filePath = connectionBuilder.GetFilePath();
                            _query = new CsvQuery( _filePath );
                            break;
                        }

                        case Provider.NS:
                            break;

                        default:
                        {
                            _query = new SQLiteQuery( _source );
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
        /// Sets the query.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        private protected void SetQuery( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
        {
            if( Validate.Source( _source )
                && Validate.Provider( _provider )
                && Verify.Ref( sqlStatement ) )
            {
                try
                {
                    switch( _provider )
                    {
                        case Provider.SQLite:
                        {
                            _query = new SQLiteQuery( _source, _args );
                            break;
                        }

                        case Provider.SqlServer:
                        {
                            _query = new SqlServerQuery( _source, _args );
                            break;
                        }

                        case Provider.SqlCe:
                        {
                            _query = new SqlCeQuery( _source, _args );
                            break;
                        }

                        case Provider.Access:
                        {
                            _query = new AccessQuery( _source, _args );
                            break;
                        }

                        case Provider.OleDb:
                        {
                            var filepath = connectionBuilder?.GetFilePath();

                            _query = Verify.Input( filepath ) && File.Exists( filepath )
                                ? new ExcelQuery( filepath, _args )
                                : default( ExcelQuery );

                            break;
                        }

                        case Provider.Excel:
                        {
                            var filepath = connectionBuilder?.GetFilePath();
                            _query = new ExcelQuery( filepath, _args );
                            break;
                        }

                        case Provider.CSV:
                        {
                            var filepath = connectionBuilder.GetFilePath();
                            _query = new CsvQuery( filepath, _args );
                            break;
                        }

                        case Provider.NS:
                            break;

                        default:
                        {
                            _query = new SQLiteQuery( _source, _args );
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
        /// Sets the data.
        /// </summary>
        /// <param name="name">The name.</param>
        private protected void SetData( string name )
        {
            if( Verify.Input( name ) 
                && Validate.Source(  _source ) )
            {
                try
                {
                    _dataSet = new DataSet( $"{name}" )
                    {
                        DataSetName = $"{name}"
                    };

                    _dataTable = new DataTable( $"{_source}" );
                    _dataTable.TableName = $"{_source}";
                    _dataSet.Tables.Add( _dataTable );
                    var _adapter = _query?.GetAdapter();
                    _adapter?.Fill( _dataSet, _dataTable.TableName );
                }
                catch( Exception ex )
                {
                    Fail( ex );;
                }
            }
        }

        /// <summary>
        /// Fails the specified ex.
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