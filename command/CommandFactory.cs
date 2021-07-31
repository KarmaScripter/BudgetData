// <copyright file = "CommandFactory.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

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

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class CommandFactory : CommandBase, ICommandFactory
    {
        // ***************************************************************************************************************************
        // *********************************************      FIELDS    **************************************************************
        // ***************************************************************************************************************************

        private readonly ICommandBuilder _commandBuilder;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        public CommandFactory( ICommandBuilder commandbuilder )
        {
            _commandBuilder = commandbuilder;
            SqlStatement = _commandBuilder?.GetSqlStatement();
            ConnectionFactory = new ConnectionFactory( SqlStatement?.GetConnectionBuilder() );
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary> Gets the connection manager. </summary>
        /// <value> The connection manager. </value>
        private IConnectionFactory ConnectionFactory { get; }

        // **********************************************************************************************************************
        // *************************************************    METHODS     *****************************************************
        // **********************************************************************************************************************

        /// <inheritdoc/>
        /// <summary> Gets the create table command. </summary>
        /// <param name = "table" > The tablename. </param>
        /// <param name = "columns" > The columns. </param>
        /// <returns> </returns>
        public DbCommand GetCreateTableCommand( string table, IEnumerable<DataColumn> columns )
        {
            if( Verify.Input( table )
                && Verify.Sequence( columns ) )
            {
                try
                {
                    var connectionbuilder = GetConnectionBuilder();
                    var provider = connectionbuilder.GetProvider();
                    var sql = $"CREATE TABLE {table}";

                    if( Validate.Provider( provider )
                        && Verify.Input( sql ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( sql )
                                    ? new SQLiteCommand( sql )
                                    : default( SQLiteCommand );
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql )
                                    : default( SqlCeCommand );
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCommand( sql )
                                    : default( SqlCommand );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( sql )
                                    ? new OleDbCommand( sql )
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

        /// <inheritdoc/>
        /// <summary> Gets the create view command. </summary>
        /// <param name = "view" > The tablename. </param>
        /// <param name = "columns" > The columns. </param>
        /// <returns> </returns>
        public DbCommand GetCreateViewCommand( string view, IEnumerable<DataColumn> columns )
        {
            var connectionbuilder = ConnectionFactory?.GetConnectionBuilder();

            if( Verify.Input( view )
                && columns?.Any() == true
                && connectionbuilder != null
                && connectionbuilder.GetProvider() != Provider.SqlCe )
            {
                try
                {
                    var provider = connectionbuilder.GetProvider();
                    var sql = $"CREATE VIEW {view};";

                    switch( provider )
                    {
                        case Provider.SQLite:
                        {
                            return Verify.Input( sql )
                                ? new SQLiteCommand( sql )
                                : default( SQLiteCommand );
                        }

                        case Provider.SqlServer:
                        {
                            return Verify.Input( sql )
                                ? new SqlCommand( sql )
                                : default( SqlCommand );
                        }

                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            return Verify.Input( sql )
                                ? new OleDbCommand( sql )
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

        /// <inheritdoc/>
        /// <summary> Gets the drop table command. </summary>
        /// <param name = "datatable" > The datatable. </param>
        /// <returns> </returns>
        public DbCommand GetDropTableCommand( DataTable datatable )
        {
            var connectionbuilder = ConnectionFactory?.GetConnectionBuilder();

            if( datatable != null
                && connectionbuilder != null )
            {
                try
                {
                    var sql = $"DROP {datatable.TableName};";
                    var provider = connectionbuilder.GetProvider();

                    if( Verify.Input( sql )
                        && Enum.IsDefined( typeof( Provider ), provider ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( sql )
                                    ? new SQLiteCommand( sql )
                                    : default( SQLiteCommand );
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql )
                                    : default( SqlCeCommand );
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCommand( sql )
                                    : default( SqlCommand );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( sql )
                                    ? new OleDbCommand( sql )
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

        /// <inheritdoc/>
        /// <summary> Gets the alter command. </summary>
        /// <param name = "datatable" > The datatable. </param>
        /// <param name = "column" > The column. </param>
        /// <returns> </returns>
        public DbCommand GetAlterCommand( DataTable datatable, DataColumn column )
        {
            var connectionbuilder = ConnectionFactory?.GetConnectionBuilder();

            if( datatable != null
                && column != null
                && connectionbuilder != null )
            {
                try
                {
                    var provider = connectionbuilder?.GetProvider();
                    var sql = $"ALTER TABLE {datatable.TableName} ADD COLUMN {column.ColumnName};";

                    if( Verify.Input( sql )
                        && Enum.IsDefined( typeof( Provider ), provider ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( sql )
                                    ? new SQLiteCommand( sql )
                                    : default( SQLiteCommand );
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql )
                                    : default( SqlCeCommand );
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCommand( sql )
                                    : default( SqlCommand );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( sql )
                                    ? new OleDbCommand( sql )
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

        /// <inheritdoc/>
        /// <summary> Gets the alter command. </summary>
        /// <param name = "datatable" > The datatable. </param>
        /// <param name = "name" > The name. </param>
        /// <returns> </returns>
        public DbCommand GetAlterCommand( DataTable datatable, string name )
        {
            if( datatable != null
                && Verify.Input( name )
                && _commandBuilder != null )
            {
                try
                {
                    var provider = _commandBuilder?.GetProvider();
                    var sql = $"ALTER TABLE {datatable.TableName} RENAME {name};";

                    if( Enum.IsDefined( typeof( Provider ), provider )
                        && Verify.Input( sql ) )
                    {
                        switch( provider )
                        {
                            case Provider.SQLite:
                            {
                                return Verify.Input( sql )
                                    ? new SQLiteCommand( sql )
                                    : default( SQLiteCommand );
                            }

                            case Provider.SqlCe:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCeCommand( sql )
                                    : default( SqlCeCommand );
                            }

                            case Provider.SqlServer:
                            {
                                return Verify.Input( sql )
                                    ? new SqlCommand( sql )
                                    : default( SqlCommand );
                            }

                            case Provider.Excel:
                            case Provider.CSV:
                            case Provider.Access:
                            case Provider.OleDb:
                            {
                                return Verify.Input( sql )
                                    ? new OleDbCommand( sql )
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

        /// <summary> Gets the select command. </summary>
        /// <returns> </returns>
        public DbCommand GetSelectCommand()
        {
            try
            {
                return _commandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }

        /// <summary> Gets the insert command. </summary>
        /// <returns> </returns>
        public DbCommand GetInsertCommand()
        {
            try
            {
                return _commandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }

        /// <summary> Gets the update command. </summary>
        /// <returns> </returns>
        public DbCommand GetUpdateCommand()
        {
            try
            {
                return _commandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }

        /// <summary> Gets the delete command. </summary>
        /// <returns> </returns>
        public DbCommand GetDeleteCommand()
        {
            try
            {
                return _commandBuilder?.GetCommand();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }
    }
}