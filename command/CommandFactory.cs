// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Data.SqlServerCe;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.CommandBase" />
    /// <seealso cref="BudgetExecution.ICommandFactory" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class CommandFactory : CommandBase, ICommandFactory
    {
        /// <summary>
        /// The command builder
        /// </summary>
        public ICommandBuilder CommandBuilder { get; set; }

        /// <summary>
        /// The connection factory
        /// </summary>
        public IConnectionFactory ConnectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactory"/> class.
        /// </summary>
        /// <param name="commandBuilder">The command builder.</param>
        public CommandFactory( ICommandBuilder commandBuilder )
        {
            CommandBuilder = commandBuilder;
            SqlStatement = CommandBuilder?.GetSqlStatement();
            ConnectionFactory = new ConnectionFactory( SqlStatement?.GetConnectionBuilder() );
        }

        /// <summary>
        /// Gets the create table command.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="dataColumns">The data columns.</param>
        /// <returns></returns>
        public DbCommand GetCreateTableCommand( string tableName, IEnumerable<DataColumn> dataColumns )
        {
            if( Verify.Input( tableName )
                && Verify.Sequence( dataColumns ) )
            {
                try
                {
                    ConnectionBuilder = GetConnectionBuilder();
                    Provider = ConnectionBuilder.GetProvider();
                    var _sql = $"CREATE TABLE {tableName}";

                    if( Validate.Provider( Provider )
                        && Verify.Input( _sql ) )
                    {
                        switch( Provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( _sql )
                                    ? new SQLiteCommand( _sql )
                                    : default( SQLiteCommand );
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql )
                                    : default( SqlCeCommand );
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( _sql )
                                    ? new SqlCommand( _sql )
                                    : default( SqlCommand );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( _sql )
                                    ? new OleDbCommand( _sql )
                                    : default( OleDbCommand );
                            }
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
        /// Gets the create view command.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="dataColumns">The data columns.</param>
        /// <returns></returns>
        public DbCommand GetCreateViewCommand( string viewName, IEnumerable<DataColumn> dataColumns )
        {
            if( Verify.Input( viewName )
                && dataColumns?.Any() == true
                && ConnectionBuilder != null
                && ConnectionBuilder.GetProvider() != Provider.SqlCe )
            {
                try
                {
                    Provider = ConnectionBuilder.GetProvider();
                    var _sql = $"CREATE VIEW {viewName};";

                    switch( Provider )
                    {
                        case Provider.SQLite:
                        {
                            return Verify.Input( _sql )
                                ? new SQLiteCommand( _sql )
                                : default( SQLiteCommand );
                        }

                        case Provider.SqlServer:
                        {
                            return Verify.Input( _sql )
                                ? new SqlCommand( _sql )
                                : default( SqlCommand );
                        }

                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            return Verify.Input( _sql )
                                ? new OleDbCommand( _sql )
                                : default( OleDbCommand );
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
        /// Gets the drop table command.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public DbCommand GetDropTableCommand( DataTable dataTable )
        {
            if( dataTable != null
                && ConnectionBuilder != null )
            {
                try
                {
                    var _sql = $"DROP {dataTable.TableName};";
                    Provider = ConnectionBuilder.GetProvider();

                    if( Verify.Input( _sql )
                        && Enum.IsDefined( typeof( Provider ), Provider ) )
                    {
                        switch( Provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( _sql )
                                    ? new SQLiteCommand( _sql )
                                    : default( SQLiteCommand );
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql )
                                    : default( SqlCeCommand );
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( _sql )
                                    ? new SqlCommand( _sql )
                                    : default( SqlCommand );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( _sql )
                                    ? new OleDbCommand( _sql )
                                    : default( OleDbCommand );
                            }
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
        /// Gets the alter command.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="dataColumn">The data column.</param>
        /// <returns></returns>
        public DbCommand GetAlterCommand( DataTable dataTable, DataColumn dataColumn )
        {
            if( dataTable != null
                && dataColumn != null
                && ConnectionBuilder != null )
            {
                try
                {
                    Provider = ConnectionBuilder.GetProvider();

                    var _sql =
                        $"ALTER TABLE {dataTable.TableName} ADD COLUMN {dataColumn.ColumnName};";

                    if( Verify.Input( _sql )
                        && Enum.IsDefined( typeof( Provider ), Provider ) )
                    {
                        switch( Provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( _sql )
                                    ? new SQLiteCommand( _sql )
                                    : default( SQLiteCommand );
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql )
                                    : default( SqlCeCommand );
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( _sql )
                                    ? new SqlCommand( _sql )
                                    : default( SqlCommand );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( _sql )
                                    ? new OleDbCommand( _sql )
                                    : default( OleDbCommand );
                            }
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
        /// Gets the alter command.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public DbCommand GetAlterCommand( DataTable dataTable, string name )
        {
            if( dataTable != null
                && Verify.Input( name )
                && CommandBuilder != null )
            {
                try
                {
                    Provider = CommandBuilder.GetProvider();
                    var _sql = $"ALTER TABLE {dataTable.TableName} RENAME {name};";

                    if( Enum.IsDefined( typeof( Provider ), Provider )
                        && Verify.Input( _sql ) )
                    {
                        switch( Provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( _sql )
                                    ? new SQLiteCommand( _sql )
                                    : default( SQLiteCommand );
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( _sql )
                                    ? new SqlCeCommand( _sql )
                                    : default( SqlCeCommand );
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( _sql )
                                    ? new SqlCommand( _sql )
                                    : default( SqlCommand );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( _sql )
                                    ? new OleDbCommand( _sql )
                                    : default( OleDbCommand );
                            }
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
        /// Gets the select command.
        /// </summary>
        /// <returns></returns>
        public DbCommand GetSelectCommand()
        {
            try
            {
                return CommandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <returns></returns>
        public DbCommand GetInsertCommand()
        {
            try
            {
                return CommandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <returns></returns>
        public DbCommand GetUpdateCommand()
        {
            try
            {
                return CommandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <returns></returns>
        public DbCommand GetDeleteCommand()
        {
            try
            {
                return CommandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }
    }
}