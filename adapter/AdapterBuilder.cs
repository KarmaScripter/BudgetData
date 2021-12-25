﻿// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Office.Interop.Excel;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.Common.DbDataAdapter" />
    [SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class AdapterBuilder : DbDataAdapter
    {
        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public DbConnection Connection { get; protected internal set; }

        /// <summary>
        /// Gets or sets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        public ISqlStatement SqlStatement { get; protected internal set; }

        /// <summary>
        /// Gets or sets the connection builder.
        /// </summary>
        /// <value>
        /// The connection builder.
        /// </value>
        public IConnectionBuilder ConnectionBuilder { get; protected internal set; }

        /// <summary>
        /// Gets the command builder.
        /// </summary>
        /// <value>
        /// The command builder.
        /// </value>
        public ICommandBuilder CommandBuilder { get; }

        /// <summary>
        /// Gets the command factory.
        /// </summary>
        /// <value>
        /// The command factory.
        /// </value>
        public ICommandFactory CommandFactory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterBuilder"/> class.
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

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterBuilder"/> class.
        /// </summary>
        /// <param name="commandBuilder">The commandBuilder.</param>
        public AdapterBuilder( ICommandBuilder commandBuilder )
            : this()
        {
            ConnectionBuilder = commandBuilder.ConnectionBuilder;
            SqlStatement = commandBuilder.SqlStatement;
            Connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
            CommandFactory = new CommandFactory( CommandBuilder );
            SelectCommand = CommandFactory.GetSelectCommand();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterBuilder"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connectionBuilder.</param>
        /// <param name="sqlStatement">The sqlStatement.</param>
        public AdapterBuilder( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
            : this()
        {
            ConnectionBuilder = connectionBuilder;
            Connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();
            SqlStatement = sqlStatement;
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
            CommandFactory = new CommandFactory( CommandBuilder );
            SelectCommand = CommandFactory.GetSelectCommand();
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public DbConnection GetConnection()
        {
            try
            {
                return Verify.IsRef( Connection )
                    ? Connection
                    : default( DbConnection );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbConnection );
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
                return Verify.IsRef( ConnectionBuilder )
                    ? ConnectionBuilder
                    : default( IConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IConnectionBuilder );
            }
        }

        /// <summary>
        /// Fails the specified ex.
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