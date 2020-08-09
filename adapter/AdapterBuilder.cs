// <copyright file="AdapterBuilder.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref = "T:System.Data.Common.DataAdapter"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class AdapterBuilder : DbDataAdapter
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS    ***********************************************************
        // ***************************************************************************************************************************

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "T:BudgetExecution.AdapterBuilder"/> class.
        /// </summary>
        public AdapterBuilder()
        {
            MissingMappingAction = MissingMappingAction.Passthrough;
            MissingSchemaAction = MissingSchemaAction.AddWithKey;
            MissingMappingAction = MissingMappingAction.Passthrough;
            ContinueUpdateOnError = true;
            AcceptChangesDuringFill = true;
            AcceptChangesDuringUpdate = true;
        }

        public AdapterBuilder( ICommandBuilder commandbuilder )
            : this()
        {
            ConnectionBuilder = commandbuilder.GetConnectionBuilder();
            Connection = new ConnectionFactory( ConnectionBuilder ).GetConnection();
            SqlStatement = commandbuilder.GetSqlStatement();
            SelectCommand = new CommandBuilder( ConnectionBuilder, SqlStatement ).GetCommand();
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "T:BudgetExecution.AdapterBuilder"/> class.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionmanager.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        public AdapterBuilder( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
            : this()
        {
            ConnectionBuilder = connectionbuilder;
            Connection = new ConnectionFactory( ConnectionBuilder ).GetConnection();
            SqlStatement = sqlstatement;
            SelectCommand = new CommandBuilder( ConnectionBuilder, SqlStatement ).GetCommand();
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
        /// Gets the connection builder.
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