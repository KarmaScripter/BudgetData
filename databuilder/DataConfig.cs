// // <copyright file = "DataConfig.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Threading;

    public abstract class DataConfig : ISource, IProvider
    {
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected Source Source { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        private protected Provider Provider { get; set; }

        /// <summary>
        /// Gets or sets the connection builder.
        /// </summary>
        /// <value>
        /// The connection builder.
        /// </value>
        private protected IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// Gets or sets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        private protected ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        private protected IQuery Query { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the r6.
        /// </summary>
        /// <value>
        /// The r6.
        /// </value>
        private protected DataSet R6 { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Sets the query.
        /// </summary>
        /// <param name="connectionbuilder">The connectionbuilder.</param>
        private protected void SetQuery( IConnectionBuilder connectionbuilder )
        {
            var source = connectionbuilder.GetSource();
            var provider = connectionbuilder.GetProvider();

            if( Verify.Source( source )
                && Verify.Provider( provider ) )
            {
                try
                {
                    switch( provider )
                    {
                        case Provider.SQLite:
                        {
                            Query = new SQLiteQuery( source );
                            break;
                        }

                        case Provider.SqlServer:
                        {
                            Query = new SqlServerQuery( source );
                            break;
                        }

                        case Provider.SqlCe:
                        {
                            Query = new SqlCeQuery( source );
                            break;
                        }

                        case Provider.Access:
                        {
                            Query = new AccessQuery( source );
                            break;
                        }

                        case Provider.OleDb:
                        {
                            var filepath = connectionbuilder?.GetFilePath();

                            Query = Verify.Input( connectionbuilder?.GetFilePath() )
                                && File.Exists( connectionbuilder?.GetFilePath() )
                                    ? new ExcelQuery( filepath )
                                    : default;

                            break;
                        }

                        case Provider.Excel:
                        {
                            var filepath = connectionbuilder?.GetFilePath();
                            Query = new ExcelQuery( filepath );
                            break;
                        }

                        case Provider.CSV:
                        {
                            var filepath = connectionbuilder.GetFilePath();
                            Query = new CsvQuery( filepath );
                            break;
                        }

                        case Provider.NS:
                            break;

                        default:
                        {
                            Query = new SQLiteQuery( source );
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
        /// Gets the query.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionbuilder.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetQuery( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
        {
            var source = connectionbuilder.GetSource();
            var provider = connectionbuilder.GetProvider();
            var args = sqlstatement?.GetArgs();

            if( Verify.Source( source )
                && Verify.Provider( provider )
                && Verify.Ref( sqlstatement ) )
            {
                try
                {
                    switch( provider )
                    {
                        case Provider.SQLite:
                        {
                            Query = new SQLiteQuery( source, args );
                            break;
                        }

                        case Provider.SqlServer:
                        {
                            Query = new SqlServerQuery( source, args );
                            break;
                        }

                        case Provider.SqlCe:
                        {
                            Query = new SqlCeQuery( source, args );
                            break;
                        }

                        case Provider.Access:
                        {
                            Query = new AccessQuery( source, args );
                            break;
                        }

                        case Provider.OleDb:
                        {
                            var filepath = connectionbuilder?.GetFilePath();

                            Query = Verify.Input( filepath )
                                && File.Exists( filepath )
                                    ? new ExcelQuery( filepath, args )
                                    : default;

                            break;
                        }

                        case Provider.Excel:
                        {
                            var filepath = connectionbuilder?.GetFilePath();
                            Query = new ExcelQuery( filepath, args );
                            break;
                        }

                        case Provider.CSV:
                        {
                            var filepath = connectionbuilder.GetFilePath();
                            Query = new CsvQuery( filepath, args );
                            break;
                        }

                        case Provider.NS:
                            break;

                        default:
                        {
                            Query = new SQLiteQuery( source, args );
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
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Source( Source )
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
        /// Gets the provider.
        /// </summary>
        /// <returns>
        /// </returns>
        public Provider GetProvider()
        {
            try
            {
                return Verify.Provider( Provider )
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
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}