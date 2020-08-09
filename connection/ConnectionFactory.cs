// <copyright file="ConnectionFactory.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Configuration;
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
    /// <seealso cref = "T:BudgetExecution.ISource"/>
    /// <seealso cref = "T:BudgetExecution.IProvider"/>
    /// <seealso/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class ConnectionFactory : ISource, IConnectionFactory
    {
        // ***************************************************************************************************************************
        // ****************************************************     FIELDS    ********************************************************
        // ***************************************************************************************************************************

        private readonly IConnectionBuilder ConnectionBuilder;

        // ***************************************************************************************************************************
        // ******************************************************  CONSTRUCTORS  *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "ConnectionFactory"/> class.
        /// </summary>
        public ConnectionFactory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ConnectionFactory"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The manager.
        /// </param>
        public ConnectionFactory( IConnectionBuilder builder )
        {
            ConnectionBuilder = GetConnectionBuilder( builder );
            Connection = SetConnection( ConnectionBuilder );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ConnectionFactory"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        public ConnectionFactory( IConnectionBuilder builder, ISqlStatement sqlstatement )
        {
            ConnectionBuilder = GetConnectionBuilder( builder );
            Connection = SetConnection( ConnectionBuilder );
        }

        // ***************************************************************************************************************************
        // ******************************************************   PROPERTIES   *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        private DbConnection Connection { get; }

        // ***************************************************************************************************************************
        // *******************************************************      METHODS        ***********************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Sets the connection manager.
        /// </summary>
        /// <param name = "builder" >
        /// The manager.
        /// </param>
        /// <returns>
        /// </returns>
        private IConnectionBuilder GetConnectionBuilder( IConnectionBuilder builder )
        {
            try
            {
                return Verify.Ref( builder )
                    ? builder
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the connection manager.
        /// </summary>
        /// <returns>
        /// </returns>
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
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>
        /// </returns>
        private DbConnection SetConnection( IConnectionBuilder builder )
        {
            if( Verify.Ref( builder ) )
            {
                try
                {
                    var provider = builder.GetProvider();

                    if( Verify.Provider( provider ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                var connectionstring = ConfigurationManager
                                    .ConnectionStrings[ $"{Provider.SQLite}" ]
                                    ?.ConnectionString;

                                return Verify.Input( connectionstring )
                                    ? new SQLiteConnection( connectionstring )
                                    : default( DbConnection );
                            }

                            case Provider.SqlCe:
                            {
                                var connectionstring = ConfigurationManager
                                    .ConnectionStrings[ $"{Provider.SqlCe}" ]
                                    .ConnectionString;

                                return Verify.Input( connectionstring )
                                    ? new SqlCeConnection( connectionstring )
                                    : default( DbConnection );
                            }

                            case Provider.SqlServer:
                            {
                                var connectionstring = ConfigurationManager
                                    .ConnectionStrings[ $"{Provider.SqlServer}" ]
                                    .ConnectionString;

                                return Verify.Input( connectionstring )
                                    ? new SqlConnection( connectionstring )
                                    : default( DbConnection );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                var connectionstring = ConfigurationManager
                                    .ConnectionStrings[ $"{Provider.OleDb}" ]
                                    .ConnectionString;

                                return Verify.Input( connectionstring )
                                    ? new OleDbConnection( connectionstring )
                                    : default( DbConnection );
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbConnection GetConnection()
        {
            try
            {
                return Verify.Ref( Connection )
                    ? Connection
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                var connectionstring = ConnectionBuilder?.GetConnectionString();

                return Verify.Input( connectionstring )
                    ? connectionstring
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
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
                var provider = ConnectionBuilder.GetProvider();

                return Verify.Provider( provider )
                    ? provider
                    : Provider.None;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Provider.None;
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
                var source = ConnectionBuilder.GetSource();

                return Verify.Source( source )
                    ? source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
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