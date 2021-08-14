// <copyright file = "CommandBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.CommandBase" />
    /// <seealso cref="BudgetExecution.ICommandBuilder" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class CommandBuilder : CommandBase, ICommandBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBuilder"/> class.
        /// </summary>
        public CommandBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBuilder"/> class.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        public CommandBuilder( ISqlStatement sqlStatement )
        {
            _sqlStatement = sqlStatement;
            _connectionBuilder = _sqlStatement.GetConnectionBuilder();
            _command = SetCommand( _sqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBuilder"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        public CommandBuilder( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
        {
            _sqlStatement = sqlStatement;
            _connectionBuilder = connectionBuilder;
            _command = SetCommand( _sqlStatement );
        }

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        public DbCommand SetCommand( ISqlStatement sqlStatement )
        {
            if( Verify.Ref( sqlStatement )
                && Enum.IsDefined( typeof( Provider ), _connectionBuilder.GetProvider() ) )
            {
                try
                {
                    _provider = _connectionBuilder.GetProvider();

                    switch( _provider )
                    {
                        case Provider.SQLite:
                        {
                            _command = GetSQLiteCommand( sqlStatement );
                            return _command;
                        }

                        case Provider.SqlCe:
                        {
                            _command = GetSQLiteCommand( sqlStatement );
                            return _command;
                        }

                        case Provider.SqlServer:
                        {
                            _command = GetSQLiteCommand( sqlStatement );
                            return _command;
                        }

                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            _command = GetSQLiteCommand( sqlStatement );
                            return _command;
                        }

                        default:
                        {
                            return default( DbCommand );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <returns></returns>
        public DbCommand GetCommand()
        {
            try
            {
                return Verify.Ref( _command )
                    ? _command
                    : default( DbCommand );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }
    }
}