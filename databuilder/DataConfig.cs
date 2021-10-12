// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
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
        public Source Source { get; set; }

        /// <summary>
        /// The provider
        /// </summary>
        public Provider Provider { get; set; }

        /// <summary>
        /// The connection builder
        /// </summary>
        public IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// The arguments
        /// </summary>
        public IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// The SQL statement
        /// </summary>
        public ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// The query
        /// </summary>
        public IQuery Query { get; set; }

        /// <summary>
        /// The record
        /// </summary>
        public DataRow Record { get; set; }

        /// <summary>
        /// The data table
        /// </summary>
        public DataTable DataTable { get; set; }

        /// <summary>
        /// The data set
        /// </summary>
        public DataSet DataSet { get; set; }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="source">The source.</param>
        public void SetSource( Source source )
        {
            if( Validate.Source( source ) )
            {
                try
                {
                    Source = source;
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
        public void SetProvider( Provider provider )
        {
            if( Validate.Provider( provider ) )
            {
                try
                {
                    Provider = provider;
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
        public void SetQuery( IConnectionBuilder connectionBuilder )
        {
            if( Validate.Source( Source )
                && Validate.Provider( Provider ) )
            {
                try
                {
                    switch( Provider )
                    {
                        case Provider.SQLite:
                        {
                            Query = new SQLiteQuery( Source );
                            break;
                        }

                        case Provider.SqlServer:
                        {
                            Query = new SqlServerQuery( Source );
                            break;
                        }

                        case Provider.SqlCe:
                        {
                            Query = new SqlCeQuery( Source );
                            break;
                        }

                        case Provider.Access:
                        {
                            Query = new AccessQuery( Source );
                            break;
                        }

                        case Provider.OleDb:
                        {
                            var _filePath = connectionBuilder?.GetFilePath();

                            Query = Verify.Input( _filePath )
                                && File.Exists( _filePath )
                                    ? new ExcelQuery( _filePath )
                                    : default( ExcelQuery );

                            break;
                        }

                        case Provider.Excel:
                        {
                            var _filePath = connectionBuilder?.GetFilePath();
                            Query = new ExcelQuery( _filePath );
                            break;
                        }

                        case Provider.CSV:
                        {
                            var _filePath = connectionBuilder.GetFilePath();
                            Query = new CsvQuery( _filePath );
                            break;
                        }

                        case Provider.NS:
                            break;

                        default:
                        {
                            Query = new SQLiteQuery( Source );
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
        public void SetQuery( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
        {
            if( Validate.Source( Source )
                && Validate.Provider( Provider )
                && Verify.Ref( sqlStatement ) )
            {
                try
                {
                    switch( Provider )
                    {
                        case Provider.SQLite:
                        {
                            Query = new SQLiteQuery( Source, Args );
                            break;
                        }

                        case Provider.SqlServer:
                        {
                            Query = new SqlServerQuery( Source, Args );
                            break;
                        }

                        case Provider.SqlCe:
                        {
                            Query = new SqlCeQuery( Source, Args );
                            break;
                        }

                        case Provider.Access:
                        {
                            Query = new AccessQuery( Source, Args );
                            break;
                        }

                        case Provider.OleDb:
                        {
                            var filepath = connectionBuilder?.GetFilePath();

                            Query = Verify.Input( filepath ) && File.Exists( filepath )
                                ? new ExcelQuery( filepath, Args )
                                : default( ExcelQuery );

                            break;
                        }

                        case Provider.Excel:
                        {
                            var filepath = connectionBuilder?.GetFilePath();
                            Query = new ExcelQuery( filepath, Args );
                            break;
                        }

                        case Provider.CSV:
                        {
                            var filepath = connectionBuilder.GetFilePath();
                            Query = new CsvQuery( filepath, Args );
                            break;
                        }

                        case Provider.NS:
                            break;

                        default:
                        {
                            Query = new SQLiteQuery( Source, Args );
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
        public void SetData( string name )
        {
            if( Verify.Input( name )
                && Validate.Source( Source ) )
            {
                try
                {
                    DataSet = new DataSet( $"{name}" )
                    {
                        DataSetName = $"{name}"
                    };

                    DataTable = new DataTable( $"{Source}" );
                    DataTable.TableName = $"{Source}";
                    DataSet.Tables.Add( DataTable );
                    var _adapter = Query?.GetAdapter();
                    _adapter?.Fill( DataSet, DataTable.TableName );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}