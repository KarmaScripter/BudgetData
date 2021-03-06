﻿// // <copyright file = "CommandBase.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Data.SqlServerCe;

    public abstract class CommandBase : ISource, IProvider
    {
        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        private protected DbCommand Command { get; set; }

        /// <summary> Gets the source. </summary>
        /// <value> The source. </value>
        private protected Source Source { get; set; }

        /// <summary> Gets the provider. </summary>
        /// <value> The provider. </value>
        private protected Provider Provider { get; set; }

        /// <summary> Gets the connection manager. </summary>
        /// <value> The connection manager. </value>
        private protected IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary> Gets the SQL statement. </summary>
        /// <value> The SQL statement. </value>
        private protected ISqlStatement SqlStatement { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the source. </summary>
        /// <returns> </returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( Source )
                    ? Source
                    : default;
            }
            catch( Exception ex )
            {
                CommandBase.Fail( ex );
                return default;
            }
        }

        /// <summary> Gets the provider. </summary>
        /// <returns> </returns>
        public Provider GetProvider()
        {
            try
            {
                return Validate.Provider( Provider )
                    ? Provider
                    : default;
            }
            catch( Exception ex )
            {
                CommandBase.Fail( ex );
                return default;
            }
        }

        private protected void SetConnectionBuilder( Source source, Provider provider )
        {
            try
            {
                ConnectionBuilder = Validate.Source( source ) && Validate.Provider( provider )
                    ? new ConnectionBuilder( source, provider )
                    : default;
            }
            catch( Exception ex )
            {
                CommandBase.Fail( ex );
            }
        }

        /// <summary> Gets the connection manager. </summary>
        /// <returns> </returns>
        public IConnectionBuilder GetConnectionBuilder()
        {
            try
            {
                return Verify.Ref( ConnectionBuilder )
                    ? ConnectionBuilder
                    : default;
            }
            catch( Exception ex )
            {
                CommandBase.Fail( ex );
                return default;
            }
        }

        /// <summary> Gets the SQL statement. </summary>
        /// <returns> </returns>
        public ISqlStatement GetSqlStatement()
        {
            try
            {
                return Verify.Ref( SqlStatement )
                    ? SqlStatement
                    : default;
            }
            catch( Exception ex )
            {
                CommandBase.Fail( ex );
                return default;
            }
        }

        /// <summary> Gets the sq lite command. </summary>
        /// <param name = "sqlstatement" > The sqlstatement. </param>
        /// <returns> </returns>
        public DbCommand GetSQLiteCommand( ISqlStatement sqlstatement )
        {
            if( Verify.Ref( sqlstatement ) )
            {
                try
                {
                    var connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();

                    switch( sqlstatement?.GetCommandType() )
                    {
                        case SQL.SELECT:
                        {
                            var sql = sqlstatement?.GetSelectStatement();

                            return Verify.Input( sql )
                                ? new SQLiteCommand( sql, connection as SQLiteConnection )
                                : default;
                        }

                        case SQL.INSERT:
                        {
                            var sql = sqlstatement?.GetInsertStatement();

                            return Verify.Input( sql )
                                ? new SQLiteCommand( sql, connection as SQLiteConnection )
                                : default;
                        }

                        case SQL.UPDATE:
                        {
                            var sql = sqlstatement?.GetUpdateStatement();

                            return Verify.Input( sql )
                                ? new SQLiteCommand( sql, connection as SQLiteConnection )
                                : default;
                        }

                        case SQL.DELETE:
                        {
                            var sql = sqlstatement?.GetDeleteStatement();

                            return Verify.Input( sql )
                                ? new SQLiteCommand( sql, connection as SQLiteConnection )
                                : default;
                        }

                        default:
                        {
                            var sql = sqlstatement?.GetSelectStatement();

                            return Verify.Input( sql )
                                ? new SQLiteCommand( sql, connection as SQLiteConnection )
                                : default;
                        }
                    }
                }
                catch( Exception ex )
                {
                    CommandBase.Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the SQL ce command. </summary>
        /// <param name = "sqlstatement" > The sqlstatement. </param>
        /// <returns> </returns>
        public DbCommand GetSqlCeCommand( ISqlStatement sqlstatement )
        {
            if( Verify.Ref( sqlstatement ) )
            {
                try
                {
                    var connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();

                    if( Verify.Input( connection?.ConnectionString ) )
                    {
                        switch( sqlstatement?.GetCommandType() )
                        {
                            case SQL.SELECT:
                            {
                                var sql = sqlstatement?.GetSelectStatement();

                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql, connection as SqlCeConnection )
                                    : default;
                            }

                            case SQL.INSERT:
                            {
                                var sql = sqlstatement?.GetInsertStatement();

                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql, connection as SqlCeConnection )
                                    : default;
                            }

                            case SQL.UPDATE:
                            {
                                var sql = sqlstatement?.GetUpdateStatement();

                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql, connection as SqlCeConnection )
                                    : default;
                            }

                            case SQL.DELETE:
                            {
                                var sql = sqlstatement?.GetDeleteStatement();

                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql, connection as SqlCeConnection )
                                    : default;
                            }

                            default:
                            {
                                var sql = sqlstatement?.GetSelectStatement();

                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql, connection as SqlCeConnection )
                                    : default( DbCommand );
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    CommandBase.Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the SQL command. </summary>
        /// <param name = "sqlstatement" > The sqlstatement. </param>
        /// <returns> </returns>
        public DbCommand GetSqlCommand( ISqlStatement sqlstatement )
        {
            if( Verify.Ref( sqlstatement ) )
            {
                try
                {
                    var connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();

                    switch( sqlstatement?.GetCommandType() )
                    {
                        case SQL.SELECT:
                        {
                            var sql = sqlstatement?.GetSelectStatement();

                            return Verify.Input( sql )
                                ? new SqlCommand( sql, connection as SqlConnection )
                                : default( DbCommand );
                        }

                        case SQL.INSERT:
                        {
                            var sql = sqlstatement?.GetInsertStatement();

                            return Verify.Input( sql )
                                ? new SqlCommand( sql, connection as SqlConnection )
                                : default( DbCommand );
                        }

                        case SQL.UPDATE:
                        {
                            var sql = sqlstatement?.GetUpdateStatement();

                            return Verify.Input( sql )
                                ? new SqlCommand( sql, connection as SqlConnection )
                                : default( DbCommand );
                        }

                        case SQL.DELETE:
                        {
                            var sql = sqlstatement?.GetDeleteStatement();

                            return Verify.Input( sql )
                                ? new SqlCommand( sql, connection as SqlConnection )
                                : default( DbCommand );
                        }

                        default:
                        {
                            var sql = sqlstatement?.GetSelectStatement();

                            return Verify.Input( sql )
                                ? new SqlCommand( sql, connection as SqlConnection )
                                : default( DbCommand );
                        }
                    }
                }
                catch( Exception ex )
                {
                    CommandBase.Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Gets the OLE database command. </summary>
        /// <param name = "sqlstatement" > The sqlstatement. </param>
        /// <returns> </returns>
        public DbCommand GetOleDbCommand( ISqlStatement sqlstatement )
        {
            if( Verify.Ref( sqlstatement ) )
            {
                try
                {
                    var connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();

                    switch( sqlstatement?.GetCommandType() )
                    {
                        case SQL.SELECT:
                        {
                            var sql = sqlstatement?.GetSelectStatement();

                            return Verify.Input( sql )
                                ? new OleDbCommand( sql, connection as OleDbConnection )
                                : default( DbCommand );
                        }

                        case SQL.INSERT:
                        {
                            var sql = sqlstatement?.GetInsertStatement();

                            return Verify.Input( sql )
                                ? new OleDbCommand( sql, connection as OleDbConnection )
                                : default( DbCommand );
                        }

                        case SQL.UPDATE:
                        {
                            var sql = sqlstatement.GetUpdateStatement();

                            return Verify.Input( sql )
                                ? new OleDbCommand( sql, connection as OleDbConnection )
                                : default( DbCommand );
                        }

                        case SQL.DELETE:
                        {
                            var sql = sqlstatement?.GetDeleteStatement();

                            return Verify.Input( sql )
                                ? new OleDbCommand( sql, connection as OleDbConnection )
                                : default( DbCommand );
                        }

                        default:
                        {
                            var sql = sqlstatement?.GetSelectStatement();

                            return Verify.Input( sql )
                                ? new OleDbCommand( sql, connection as OleDbConnection )
                                : default( DbCommand );
                        }
                    }
                }
                catch( Exception ex )
                {
                    CommandBase.Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary> Get Error Dialog. </summary>
        /// <param name = "ex" > The ex. </param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}