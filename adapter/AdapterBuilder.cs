// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
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
    [SuppressMessage( "ReSharper", "MemberCanBeInternal" )]
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    public class AdapterBuilder : DbDataAdapter
    {
        /// <summary>
        /// The connection
        /// </summary>
        private protected readonly DbConnection _connection;

        /// <summary>
        /// The SQL statement
        /// </summary>
        private protected readonly ISqlStatement _sqlStatement;

        /// <summary>
        /// The connection builder
        /// </summary>
        private protected readonly IConnectionBuilder _connectionBuilder;

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
        /// <param name="commandbuilder">The commandbuilder.</param>
        public AdapterBuilder( ICommandBuilder commandbuilder )
            : this()
        {
            _connectionBuilder = commandbuilder?.GetConnectionBuilder();
            _connection = new ConnectionFactory( _connectionBuilder )?.GetConnection();
            _sqlStatement = commandbuilder?.GetSqlStatement();
            SelectCommand = new CommandBuilder( _connectionBuilder, _sqlStatement )?.GetCommand();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterBuilder"/> class.
        /// </summary>
        /// <param name="connectionbuilder">The connectionbuilder.</param>
        /// <param name="sqlstatement">The sqlstatement.</param>
        public AdapterBuilder( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
            : this()
        {
            _connectionBuilder = connectionbuilder;
            _connection = new ConnectionFactory( _connectionBuilder )?.GetConnection();
            _sqlStatement = sqlstatement;
            SelectCommand = new CommandBuilder( _connectionBuilder, _sqlStatement )?.GetCommand();
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public DbConnection GetConnection()
        {
            try
            {
                return Verify.Ref( _connection )
                    ? _connection
                    : default( DbConnection );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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
                return Verify.Ref( _connectionBuilder )
                    ? _connectionBuilder
                    : default( IConnectionBuilder );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}