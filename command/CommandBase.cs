// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Data.SqlServerCe;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.ISource" />
    /// <seealso cref="BudgetExecution.IProvider" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class CommandBase : ISource, IProvider
    {
        /// <summary>
        /// The command
        /// </summary>
        private protected DbCommand _command;

        /// <summary>
        /// The connection builder
        /// </summary>
        private protected IConnectionBuilder _connectionBuilder;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The SQL statement
        /// </summary>
        private protected ISqlStatement _sqlStatement;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Provider GetProvider()
        {
            try
            {
                return Validate.Provider( _provider )
                    ? _provider
                    : default( Provider );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Provider );
            }
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
                    : default( Source );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }

        /// <summary>
        /// Gets the connection builder.
        /// </summary>
        /// <returns></returns>
        public IConnectionBuilder GetConnectionBuilder()
        {
            try
            {
                return Verify.Ref( _connectionBuilder )
                    ? _connectionBuilder
                    : default( IConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IConnectionBuilder );
            }
        }

        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <returns></returns>
        public ISqlStatement GetSqlStatement()
        {
            try
            {
                return Verify.Ref( _sqlStatement )
                    ? _sqlStatement
                    : default( ISqlStatement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ISqlStatement );
            }
        }

        /// <summary>
        /// Gets the sq lite command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        public DbCommand GetSQLiteCommand( ISqlStatement sqlStatement )
        {
            if( Verify.Ref( sqlStatement ) )
            {
                try
                {
                    var _connection = new ConnectionFactory( _connectionBuilder )?.GetConnection();

                    switch( sqlStatement?.GetCommandType() )
                    {
                        case SQL.SELECT:
                        {
                            var _sql = sqlStatement?.GetSelectStatement();

                            return Verify.Input( _sql )
                                ? new SQLiteCommand( _sql, _connection as SQLiteConnection )
                                : default( SQLiteCommand );
                        }

                        case SQL.INSERT:
                        {
                            var _sql = sqlStatement?.GetInsertStatement();

                            return Verify.Input( _sql )
                                ? new SQLiteCommand( _sql, _connection as SQLiteConnection )
                                : default( SQLiteCommand );
                        }

                        case SQL.UPDATE:
                        {
                            var _sql = sqlStatement?.GetUpdateStatement();

                            return Verify.Input( _sql )
                                ? new SQLiteCommand( _sql, _connection as SQLiteConnection )
                                : default( SQLiteCommand );
                        }

                        case SQL.DELETE:
                        {
                            var _sql = sqlStatement?.GetDeleteStatement();

                            return Verify.Input( _sql )
                                ? new SQLiteCommand( _sql, _connection as SQLiteConnection )
                                : default( SQLiteCommand );
                        }

                        default:
                        {
                            var _sql = sqlStatement?.GetSelectStatement();

                            return Verify.Input( _sql )
                                ? new SQLiteCommand( _sql, _connection as SQLiteConnection )
                                : default( SQLiteCommand );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary>
        /// Gets the SQL ce command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        public DbCommand GetSqlCeCommand( ISqlStatement sqlStatement )
        {
            if( Verify.Ref( sqlStatement ) )
            {
                try
                {
                    var _connection = new ConnectionFactory( _connectionBuilder )?.GetConnection();

                    if( Verify.Input( _connection?.ConnectionString ) )
                    {
                        switch( sqlStatement?.GetCommandType() )
                        {
                            case SQL.SELECT:
                            {
                                var _sql = sqlStatement?.GetSelectStatement();

                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                    : default( SqlCeCommand );
                            }

                            case SQL.INSERT:
                            {
                                var _sql = sqlStatement?.GetInsertStatement();

                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                    : default( SqlCeCommand );
                            }

                            case SQL.UPDATE:
                            {
                                var _sql = sqlStatement?.GetUpdateStatement();

                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                    : default( SqlCeCommand );
                            }

                            case SQL.DELETE:
                            {
                                var _sql = sqlStatement?.GetDeleteStatement();

                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                    : default( SqlCeCommand );
                            }

                            default:
                            {
                                var _sql = sqlStatement?.GetSelectStatement();

                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                    : default( DbCommand );
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary>
        /// Gets the SQL command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        public DbCommand GetSqlCommand( ISqlStatement sqlStatement )
        {
            if( Verify.Ref( sqlStatement ) )
            {
                try
                {
                    var _connection = new ConnectionFactory( _connectionBuilder )
                        ?.GetConnection();

                    switch( sqlStatement?.GetCommandType() )
                    {
                        case SQL.SELECT:
                        {
                            var _sql = sqlStatement?.GetSelectStatement();

                            return Verify.Input( _sql )
                                ? new SqlCommand( _sql, _connection as SqlConnection )
                                : default( DbCommand );
                        }

                        case SQL.INSERT:
                        {
                            var _sql = sqlStatement?.GetInsertStatement();

                            return Verify.Input( _sql )
                                ? new SqlCommand( _sql, _connection as SqlConnection )
                                : default( DbCommand );
                        }

                        case SQL.UPDATE:
                        {
                            var _sql = sqlStatement?.GetUpdateStatement();

                            return Verify.Input( _sql )
                                ? new SqlCommand( _sql, _connection as SqlConnection )
                                : default( DbCommand );
                        }

                        case SQL.DELETE:
                        {
                            var _sql = sqlStatement?.GetDeleteStatement();

                            return Verify.Input( _sql )
                                ? new SqlCommand( _sql, _connection as SqlConnection )
                                : default( DbCommand );
                        }

                        default:
                        {
                            var _sql = sqlStatement?.GetSelectStatement();

                            return Verify.Input( _sql )
                                ? new SqlCommand( _sql, _connection as SqlConnection )
                                : default( DbCommand );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary>
        /// Gets the OLE database command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        public DbCommand GetOleDbCommand( ISqlStatement sqlStatement )
        {
            if( Verify.Ref( sqlStatement ) )
            {
                try
                {
                    var _connection = new ConnectionFactory( _connectionBuilder )?.GetConnection();

                    switch( sqlStatement?.GetCommandType() )
                    {
                        case SQL.SELECT:
                        {
                            var _sql = sqlStatement?.GetSelectStatement();

                            return Verify.Input( _sql )
                                ? new OleDbCommand( _sql, _connection as OleDbConnection )
                                : default( DbCommand );
                        }

                        case SQL.INSERT:
                        {
                            var _sql = sqlStatement?.GetInsertStatement();

                            return Verify.Input( _sql )
                                ? new OleDbCommand( _sql, _connection as OleDbConnection )
                                : default( DbCommand );
                        }

                        case SQL.UPDATE:
                        {
                            var _sql = sqlStatement.GetUpdateStatement();

                            return Verify.Input( _sql )
                                ? new OleDbCommand( _sql, _connection as OleDbConnection )
                                : default( DbCommand );
                        }

                        case SQL.DELETE:
                        {
                            var _sql = sqlStatement?.GetDeleteStatement();

                            return Verify.Input( _sql )
                                ? new OleDbCommand( _sql, _connection as OleDbConnection )
                                : default( DbCommand );
                        }

                        default:
                        {
                            var _sql = sqlStatement?.GetSelectStatement();

                            return Verify.Input( _sql )
                                ? new OleDbCommand( _sql, _connection as OleDbConnection )
                                : default( DbCommand );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary>
        /// Sets the connection builder.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        private protected void SetConnectionBuilder( Source source, Provider provider )
        {
            try
            {
                _connectionBuilder = Validate.Source( source ) && Validate.Provider( provider )
                    ? new ConnectionBuilder( source, provider )
                    : default( ConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
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