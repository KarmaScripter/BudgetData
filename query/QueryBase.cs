// <copyright file = "QueryBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    public abstract class QueryBase
    {
        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// Gets the connection manager.
        /// </summary>
        /// <value>
        /// The connection manager.
        /// </value>
        public IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        public ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// Gets the connector.
        /// </summary>
        /// <value>
        /// The connector.
        /// </value>
        public IConnectionFactory ConnectionFactory { get; set; }

        /// <summary>
        /// Gets the commander.
        /// </summary>
        /// <value>
        /// The commander.
        /// </value>
        public ICommandBuilder CommandBuilder { get; set; }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        [ SuppressMessage( "ReSharper", "UnassignedGetOnlyAutoProperty" ) ]
        public DbCommand Command { get; set; }

        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <value>
        /// The adapter.
        /// </value>
        public DbDataAdapter Adapter { get; set; }

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
        /// Gets or sets the Data reader.
        /// </summary>
        /// <value>
        /// The Data reader.
        /// </value>
        public DbDataReader DataReader { get; set; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return ConnectionBuilder?.GetSource() ?? default( Source );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
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
                return default( Provider );
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
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
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
                return Verify.IsMap( Args )
                    ? Args
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
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
        private protected void SetConnectionBuilder( Source source, Provider provider )
        {
            if( Enum.IsDefined( typeof( Source ), source )
                && Enum.IsDefined( typeof( Provider ), provider ) )
            {
                try
                {
                    ConnectionBuilder = new ConnectionBuilder( source, provider );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the connection manager.
        /// </summary>
        /// <param name = "fullpath" >
        /// The fullpath.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetConnectionBuilder( string fullpath )
        {
            if( Verify.IsInput( fullpath )
                && File.Exists( fullpath ) )
            {
                try
                {
                    ConnectionBuilder = new ConnectionBuilder( fullpath );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
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
                return ConnectionBuilder ?? default( IConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IConnectionBuilder );
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
                return CommandBuilder ?? default( ICommandBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ICommandBuilder );
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
                return SqlStatement ?? default( ISqlStatement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ISqlStatement );
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
                return ConnectionFactory?.GetConnection() ?? default( DbConnection );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbConnection );
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
                        _ => default( DbCommand )
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return default( DbCommand );
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
                return Adapter ?? default( DbDataAdapter );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbDataAdapter );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
