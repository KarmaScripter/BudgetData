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
        public DbConnection Connection { get;  }

        /// <summary>
        /// The SQL statement
        /// </summary>
        public ISqlStatement SqlStatement { get;  }

        /// <summary>
        /// The connection builder
        /// </summary>
        public IConnectionBuilder ConnectionBuilder { get;  }

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
            ConnectionBuilder = commandbuilder?.GetConnectionBuilder();
            Connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();
            SqlStatement = commandbuilder?.GetSqlStatement();
            SelectCommand = new CommandBuilder( ConnectionBuilder, SqlStatement )?.GetCommand();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterBuilder"/> class.
        /// </summary>
        /// <param name="connectionbuilder">The connectionbuilder.</param>
        /// <param name="sqlstatement">The sqlstatement.</param>
        public AdapterBuilder( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
            : this()
        {
            ConnectionBuilder = connectionbuilder;
            Connection = new ConnectionFactory( ConnectionBuilder )?.GetConnection();
            SqlStatement = sqlstatement;
            SelectCommand = new CommandBuilder( ConnectionBuilder, SqlStatement )?.GetCommand();
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public DbConnection GetConnection()
        {
            try
            {
                return Verify.Ref( Connection )
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
                return Verify.Ref( ConnectionBuilder )
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
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}