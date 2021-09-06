// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Data.SqlServerCe;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class AdapterFactory : IDisposable
    {
        /// <summary>
        /// The data connection
        /// </summary>
        private protected readonly DbConnection _dataConnection;

        /// <summary>
        /// The SQL statement
        /// </summary>
        private protected readonly ISqlStatement _sqlStatement;

        /// <summary>
        /// The command builder
        /// </summary>
        private protected readonly ICommandBuilder _commandBuilder;

        /// <summary>
        /// The connection builder
        /// </summary>
        private protected readonly IConnectionBuilder _connectionBuilder;

        /// <summary>
        /// The adapter builder
        /// </summary>
        private protected readonly AdapterBuilder _adapterBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterFactory"/> class.
        /// </summary>
        /// <param name="adapterBuilder">The adapter builder.</param>
        public AdapterFactory( AdapterBuilder adapterBuilder )
        {
            _adapterBuilder = adapterBuilder;
            _connectionBuilder = _adapterBuilder.GetConnectionBuilder();
            _dataConnection = new ConnectionFactory( _connectionBuilder )?.GetConnection();
            _sqlStatement = new SqlStatement( _connectionBuilder );
            _commandBuilder = new CommandBuilder( _connectionBuilder, _sqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterFactory"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        public AdapterFactory( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
        {
            _connectionBuilder = connectionBuilder;
            _sqlStatement = sqlStatement;
            _adapterBuilder = new AdapterBuilder( _connectionBuilder, _sqlStatement );
            _dataConnection = new ConnectionFactory( _connectionBuilder )?.GetConnection();
            _commandBuilder = new CommandBuilder( _connectionBuilder, _sqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterFactory"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="commandBuilder">The command builder.</param>
        public AdapterFactory( IConnectionBuilder connectionBuilder, ICommandBuilder commandBuilder )
        {
            _connectionBuilder = connectionBuilder;
            _commandBuilder = commandBuilder;
            _sqlStatement = _commandBuilder.GetSqlStatement();
            _adapterBuilder = new AdapterBuilder( _connectionBuilder, _sqlStatement );
            _dataConnection = new ConnectionFactory( _connectionBuilder ).GetConnection();
        }

        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <returns></returns>
        public DbDataAdapter GetAdapter()
        {
            if( Verify.Input( _connectionBuilder.GetConnectionString() )
                && Verify.Input( _sqlStatement.GetSelectStatement() ) )
            {
                try
                {
                    var _provider = _connectionBuilder.GetProvider();

                    if( Validate.Provider( _provider ) )
                    {
                        switch( _provider )
                        {
                            case Provider.SQLite:
                            {
                                return GetSQLiteAdapter() ?? default( SQLiteDataAdapter );
                            }

                            case Provider.SqlCe:
                            {
                                return GetSqlCeAdapter() ?? default( SqlCeDataAdapter );
                            }

                            case Provider.SqlServer:
                            {
                                return GetSqlAdapter() ?? default( SqlDataAdapter );
                            }

                            case Provider.CSV:
                            case Provider.OleDb:
                            case Provider.Access:
                            case Provider.Excel:
                            {
                                return GetOleDbDataAdapter() ?? default( OleDbDataAdapter );
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return default( DbDataAdapter );
        }

        /// <summary>
        /// Gets the OLE database data adapter.
        /// </summary>
        /// <returns></returns>
        private OleDbDataAdapter GetOleDbDataAdapter()
        {
            if( Verify.Input( _sqlStatement.GetSelectStatement() ) )
            {
                try
                {
                    var _connectionString = _connectionBuilder?.GetConnectionString();

                    return Verify.Input( _connectionString )
                        ? new OleDbDataAdapter( _sqlStatement.GetSelectStatement(), _connectionString )
                        : default( OleDbDataAdapter );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( OleDbDataAdapter );
                }
            }

            return default( OleDbDataAdapter );
        }

        /// <summary>
        /// Gets the SQL adapter.
        /// </summary>
        /// <returns></returns>
        private SqlDataAdapter GetSqlAdapter()
        {
            if( Verify.Ref( _sqlStatement ) )
            {
                try
                {
                    var _connectionString = _connectionBuilder?.GetConnectionString();

                    return Verify.Input( _connectionString )
                        ? new SqlDataAdapter( _sqlStatement.GetSelectStatement(), _connectionString )
                        : default( SqlDataAdapter );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( SqlDataAdapter );
                }
            }

            return default( SqlDataAdapter );
        }

        /// <summary>
        /// Gets the SQL ce adapter.
        /// </summary>
        /// <returns></returns>
        private SqlCeDataAdapter GetSqlCeAdapter()
        {
            if( Verify.Input( _dataConnection?.ConnectionString )
                && Verify.Input( _sqlStatement?.GetSelectStatement() ) )
            {
                try
                {
                    var _dataAdapter = new SqlCeDataAdapter( _sqlStatement?.GetSelectStatement(),
                        _dataConnection as SqlCeConnection );

                    return _dataAdapter ?? default( SqlCeDataAdapter );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( SqlCeDataAdapter );
                }
            }

            return default( SqlCeDataAdapter );
        }

        /// <summary>
        /// Gets the sq lite adapter.
        /// </summary>
        /// <returns></returns>
        private SQLiteDataAdapter GetSQLiteAdapter()
        {
            if( _sqlStatement != null )
            {
                try
                {
                    var _adapter = new SQLiteDataAdapter( _sqlStatement.GetSelectStatement(),
                        _dataConnection as SQLiteConnection );

                    return _adapter ?? default( SQLiteDataAdapter );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( SQLiteDataAdapter );
                }
            }

            return default( SQLiteDataAdapter );
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c>
        /// to release both managed and unmanaged resources;
        /// <c>false</c>
        /// to release only unmanaged resources.
        /// </param>
        private protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                try
                {
                    _adapterBuilder?.Dispose();
                    _dataConnection?.Dispose();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                Dispose( true );
                GC.SuppressFinalize( this );
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
            _error.SetText();
            _error.ShowDialog();
        }
    }
}