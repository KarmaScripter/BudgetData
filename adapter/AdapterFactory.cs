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
    /// <seealso cref="System.IDisposable" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class AdapterFactory : IDisposable
    {
        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public DbConnection Connection { get; set; }

        /// <summary>
        /// Gets or sets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        public ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// Gets or sets the command builder.
        /// </summary>
        /// <value>
        /// The command builder.
        /// </value>
        public ICommandBuilder CommandBuilder { get; set; }

        /// <summary>
        /// Gets or sets the connection builder.
        /// </summary>
        /// <value>
        /// The connection builder.
        /// </value>
        public IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// Gets or sets the adapter builder.
        /// </summary>
        /// <value>
        /// The adapter builder.
        /// </value>
        public AdapterBuilder AdapterBuilder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterFactory"/> class.
        /// </summary>
        /// <param name="adapterBuilder">The adapter builder.</param>
        public AdapterFactory( AdapterBuilder adapterBuilder )
        {
            AdapterBuilder = adapterBuilder;
            ConnectionBuilder = AdapterBuilder.GetConnectionBuilder();
            Connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();
            SqlStatement = new SqlStatement( ConnectionBuilder );
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterFactory"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        public AdapterFactory( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
        {
            ConnectionBuilder = connectionBuilder;
            SqlStatement = sqlStatement;
            AdapterBuilder = new AdapterBuilder( ConnectionBuilder, SqlStatement );
            Connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterFactory"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="commandBuilder">The command builder.</param>
        public AdapterFactory( IConnectionBuilder connectionBuilder, ICommandBuilder commandBuilder )
        {
            ConnectionBuilder = connectionBuilder;
            CommandBuilder = commandBuilder;
            SqlStatement = CommandBuilder.SqlStatement;
            AdapterBuilder = new AdapterBuilder( ConnectionBuilder, SqlStatement );
            Connection = new ConnectionFactory( ConnectionBuilder ).GetConnection();
        }

        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <returns></returns>
        public DbDataAdapter GetAdapter()
        {
            if( Verify.IsInput( ConnectionBuilder.ConnectionString )
                && Verify.IsInput( SqlStatement.GetSelectStatement() ) )
            {
                try
                {
                    var _provider = ConnectionBuilder.Provider;

                    if( Verify.Provider( _provider ) )
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
            if( Verify.IsInput( SqlStatement.GetSelectStatement() ) )
            {
                try
                {
                    var _connectionString = ConnectionBuilder?.ConnectionString;

                    return Verify.IsInput( _connectionString )
                        ? new OleDbDataAdapter( SqlStatement.GetSelectStatement(), _connectionString )
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
            if( Verify.IsRef( SqlStatement ) )
            {
                try
                {
                    var _connectionString = ConnectionBuilder?.ConnectionString;

                    return Verify.IsInput( _connectionString )
                        ? new SqlDataAdapter( SqlStatement.GetSelectStatement(), _connectionString )
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
            if( Verify.IsInput( Connection?.ConnectionString )
                && Verify.IsInput( SqlStatement?.GetSelectStatement() ) )
            {
                try
                {
                    var _dataAdapter = new SqlCeDataAdapter( SqlStatement?.GetSelectStatement(),
                        Connection as SqlCeConnection );

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
            if( SqlStatement != null )
            {
                try
                {
                    var _adapter = new SQLiteDataAdapter( SqlStatement.GetSelectStatement(),
                        Connection as SQLiteConnection );

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
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                try
                {
                    AdapterBuilder?.Dispose();
                    Connection?.Dispose();
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