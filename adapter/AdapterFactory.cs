// <copyright file="AdapterFactory.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Data.SqlServerCe;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class AdapterFactory : IDisposable
    {
        // ***************************************************************************************************************************
        // *********************************************      FIELDS    **************************************************************
        // ***************************************************************************************************************************

        private readonly AdapterBuilder AdapterBuilder;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "AdapterFactory"/> class.
        /// </summary>
        public AdapterFactory( AdapterBuilder adapterbuilder )
        {
            AdapterBuilder = adapterbuilder;
            ConnectionBuilder = AdapterBuilder.GetConnectionBuilder();
            Connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();
            SqlStatement = new SqlStatement( ConnectionBuilder );
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "AdapterFactory"/> class.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionmanager.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        public AdapterFactory( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
        {
            ConnectionBuilder = connectionbuilder;
            SqlStatement = sqlstatement;
            AdapterBuilder = new AdapterBuilder( ConnectionBuilder, SqlStatement );
            Connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "AdapterFactory"/> class.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionbuilder.
        /// </param>
        /// <param name = "commandbuilder" >
        /// The commandbuilder.
        /// </param>
        public AdapterFactory( IConnectionBuilder connectionbuilder, ICommandBuilder commandbuilder )
        {
            ConnectionBuilder = connectionbuilder;
            CommandBuilder = commandbuilder;
            SqlStatement = CommandBuilder.GetSqlStatement();
            AdapterBuilder = new AdapterBuilder( ConnectionBuilder, SqlStatement );
            Connection = new ConnectionFactory( ConnectionBuilder ).GetConnection();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        private DbConnection Connection { get; }

        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        private ISqlStatement SqlStatement { get; }

        /// <summary>
        /// Gets the commander.
        /// </summary>
        /// <value>
        /// The commander.
        /// </value>
        private ICommandBuilder CommandBuilder { get; }

        /// <summary>
        /// Gets the connection manager.
        /// </summary>
        /// <value>
        /// The connection manager.
        /// </value>
        private IConnectionBuilder ConnectionBuilder { get; }

        // **********************************************************************************************************************
        // *************************************************    METHODS     *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbDataAdapter GetAdapter()
        {
            if( Verify.Input( ConnectionBuilder.GetConnectionString() )
                && Verify.Input( SqlStatement.GetSelectStatement() ) )
            {
                try
                {
                    var provider = ConnectionBuilder.GetProvider();

                    if( Verify.Provider( provider ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return GetSQLiteAdapter() ?? default;
                            }

                            case Provider.SqlCe:
                            {
                                return GetSqlCeAdapter() ?? default;
                            }

                            case Provider.SqlServer:
                            {
                                return GetSqlAdapter() ?? default;
                            }

                            case Provider.CSV:
                            case Provider.OleDb:
                            case Provider.Access:
                            case Provider.Excel:
                            {
                                return GetOleDbDataAdapter() ?? default;
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the OLE database data adapter.
        /// </summary>
        /// <returns>
        /// </returns>
        private OleDbDataAdapter GetOleDbDataAdapter()
        {
            if( Verify.Input( SqlStatement.GetSelectStatement() ) )
            {
                try
                {
                    var connection = ConnectionBuilder?.GetConnectionString();

                    return Verify.Input( connection )
                        ? new OleDbDataAdapter( SqlStatement.GetSelectStatement(), connection )
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the SQL server adapter.
        /// </summary>
        /// <returns>
        /// </returns>
        private SqlDataAdapter GetSqlAdapter()
        {
            if( Verify.Ref( SqlStatement ) )
            {
                try
                {
                    var connection = ConnectionBuilder?.GetConnectionString();

                    return Verify.Input( connection )
                        ? new SqlDataAdapter( SqlStatement.GetSelectStatement(), connection )
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the SQL ce adapter.
        /// </summary>
        /// <returns>
        /// </returns>
        private SqlCeDataAdapter GetSqlCeAdapter()
        {
            if( Verify.Input( Connection?.ConnectionString )
                && Verify.Input( SqlStatement?.GetSelectStatement() ) )
            {
                try
                {
                    var adapter = new SqlCeDataAdapter( SqlStatement?.GetSelectStatement(),
                        Connection as SqlCeConnection );

                    return adapter;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the sq lite adapter.
        /// </summary>
        /// <returns>
        /// </returns>
        private SQLiteDataAdapter GetSQLiteAdapter()
        {
            if( SqlStatement != null )
            {
                try
                {
                    var adapter = new SQLiteDataAdapter( SqlStatement.GetSelectStatement(),
                        Connection as SQLiteConnection );

                    return adapter;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name = "disposing" >
        /// <c>
        /// true
        /// </c>
        /// to release both managed and unmanaged resources;
        /// <c>
        /// false
        /// </c>
        /// to release only unmanaged resources.
        /// </param>
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

        /// <inheritdoc/>
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
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