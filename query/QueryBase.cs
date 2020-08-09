// <copyright file="{ClassName}.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading;

    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    public abstract class QueryBase
    {
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// Gets the connection manager.
        /// </summary>
        /// <value>
        /// The connection manager.
        /// </value>
        private protected IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        private protected ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// Gets the connector.
        /// </summary>
        /// <value>
        /// The connector.
        /// </value>
        private protected IConnectionFactory ConnectionFactory { get; set; }

        /// <summary>
        /// Gets the commander.
        /// </summary>
        /// <value>
        /// The commander.
        /// </value>
        private protected ICommandBuilder CommandBuilder { get; set; }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        [ SuppressMessage( "ReSharper", "UnassignedGetOnlyAutoProperty" ) ]
        private protected DbCommand Command { get; set; }

        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <value>
        /// The adapter.
        /// </value>
        private protected DbDataAdapter Adapter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>
        /// true
        /// </c>
        /// if this instance is disposed; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </value>
        public bool IsDisposed { get; set; }

        /// <summary>
        /// Gets or sets the data reader.
        /// </summary>
        /// <value>
        /// The data reader.
        /// </value>
        private protected DbDataReader DataReader { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return ConnectionBuilder?.GetSource() ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return ConnectionBuilder?.GetProvider() ?? Provider.SQLite;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IDictionary<string, object> SetArgs( IDictionary<string, object> dict )
        {
            try
            {
                return dict?.Any() == true
                    ? dict
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
        /// Gets the arguments.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetArgs()
        {
            try
            {
                return Verify.Map( Args )
                    ? Args
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the connection manager.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "provider" >
        /// The provider.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IConnectionBuilder SetConnectionBuilder( Source source, Provider provider )
        {
            if( Enum.IsDefined( typeof( Source ), source )
                && Enum.IsDefined( typeof( Provider ), provider ) )
            {
                try
                {
                    var connectionmanager = new ConnectionBuilder( source, provider );

                    return Verify.Input( connectionmanager?.GetConnectionString() )
                        ? connectionmanager
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
        /// Sets the connection manager.
        /// </summary>
        /// <param name = "fullpath" >
        /// The fullpath.
        /// </param>
        /// <returns>
        /// </returns>
        private protected static IConnectionBuilder SetConnectionBuilder( string fullpath )
        {
            if( Verify.Input( fullpath )
                && File.Exists( fullpath ) )
            {
                try
                {
                    return new ConnectionBuilder( fullpath );
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
        /// Gets the connection manager.
        /// </summary>
        /// <returns>
        /// </returns>
        public IConnectionBuilder GetConnectionBuilder()
        {
            try
            {
                return ConnectionBuilder ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the command builder.
        /// </summary>
        /// <returns>
        /// </returns>
        public ICommandBuilder GetCommandBuilder()
        {
            try
            {
                return CommandBuilder ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <returns>
        /// </returns>
        public ISqlStatement GetSqlStatement()
        {
            try
            {
                return SqlStatement ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
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
                return ConnectionFactory?.GetConnection() ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbCommand GetCommand()
        {
            if( SqlStatement != null
                && CommandBuilder != null )
            {
                try
                {
                    var commandfactory = new CommandFactory( CommandBuilder );

                    return SqlStatement?.GetCommandType() switch
                    {
                        SQL.SELECT => commandfactory?.GetSelectCommand(),
                        SQL.INSERT => commandfactory?.GetSelectCommand(),
                        SQL.UPDATE => commandfactory?.GetSelectCommand(),
                        SQL.DELETE => commandfactory?.GetDeleteCommand(),
                        _ => default
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return default;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <returns>
        /// </returns>
        public DbDataAdapter GetAdapter()
        {
            try
            {
                return Adapter ?? default;
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