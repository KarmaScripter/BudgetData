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
            SqlStatement = sqlStatement;
            ConnectionBuilder = SqlStatement.GetConnectionBuilder();
            Command = SetCommand( SqlStatement );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBuilder"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        public CommandBuilder( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
        {
            SqlStatement = sqlStatement;
            ConnectionBuilder = connectionBuilder;
            Command = SetCommand( SqlStatement );
        }

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        public DbCommand SetCommand( ISqlStatement sqlStatement )
        {
            if( Verify.Ref( sqlStatement )
                && Enum.IsDefined( typeof( Provider ), ConnectionBuilder.GetProvider() ) )
            {
                try
                {
                    Provider = ConnectionBuilder.GetProvider();

                    switch( Provider )
                    {
                        case Provider.SQLite:
                        {
                            Command = GetSQLiteCommand( sqlStatement );
                            return Command;
                        }

                        case Provider.SqlCe:
                        {
                            Command = GetSQLiteCommand( sqlStatement );
                            return Command;
                        }

                        case Provider.SqlServer:
                        {
                            Command = GetSQLiteCommand( sqlStatement );
                            return Command;
                        }

                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            Command = GetSQLiteCommand( sqlStatement );
                            return Command;
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
                return Verify.Ref( Command )
                    ? Command
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