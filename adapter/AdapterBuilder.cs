// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.Common.DbDataAdapter" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class AdapterBuilder : DbDataAdapter
    {
        /// <summary>
        /// The connection
        /// </summary>
        public DbConnection Connection { get; set; }

        /// <summary>
        /// The SQL statement
        /// </summary>
        public ISqlStatement SqlStatement { get;  set; }

        /// <summary>
        /// The connection builder
        /// </summary>
        public IConnectionBuilder ConnectionBuilder { get;  set; }

        /// <summary>
        /// Gets the command builder.
        /// </summary>
        /// <value>
        /// The command builder.
        /// </value>
        public ICommandBuilder CommandBuilder { get; set; }

        /// <summary>
        /// Gets the command factory.
        /// </summary>
        /// <value>
        /// The command factory.
        /// </value>
        public ICommandFactory CommandFactory { get; set; }

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
        /// <param name="commandBuilder">The commandbuilder.</param>
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
        /// <param name="connectionBuilder">The connectionbuilder.</param>
        /// <param name="sqlStatement">The sqlstatement.</param>
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