// // <copyright file = "ICommandFactory.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Threading;

    public interface ICommandFactory
    {
        // ***************************************************************************************************************************
        // ****************************************************    MEMBERS    ********************************************************
        // ***************************************************************************************************************************

        /// <inheritdoc/>
        /// <summary>
        /// Gets the create table command.
        /// </summary>
        /// <param name = "table" >
        /// The tablename.
        /// </param>
        /// <param name = "columns" >
        /// The columns.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetCreateTableCommand( string table, IEnumerable<DataColumn> columns );

        /// <inheritdoc/>
        /// <summary>
        /// Gets the create view command.
        /// </summary>
        /// <param name = "view" >
        /// The tablename.
        /// </param>
        /// <param name = "columns" >
        /// The columns.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetCreateViewCommand( string view, IEnumerable<DataColumn> columns );

        /// <inheritdoc/>
        /// <summary>
        /// Gets the drop table command.
        /// </summary>
        /// <param name = "datatable" >
        /// The datatable.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetDropTableCommand( DataTable datatable );

        /// <inheritdoc/>
        /// <summary>
        /// Gets the alter command.
        /// </summary>
        /// <param name = "datatable" >
        /// The datatable.
        /// </param>
        /// <param name = "column" >
        /// The column.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetAlterCommand( DataTable datatable, DataColumn column );

        /// <inheritdoc/>
        /// <summary>
        /// Gets the alter command.
        /// </summary>
        /// <param name = "datatable" >
        /// The datatable.
        /// </param>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetAlterCommand( DataTable datatable, string name );

        /// <summary>
        /// Gets the select command.
        /// </summary>
        /// <returns>
        /// </returns>
        DbCommand GetSelectCommand();

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <returns>
        /// </returns>
        DbCommand GetInsertCommand();

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <returns>
        /// </returns>
        DbCommand GetUpdateCommand();

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <returns>
        /// </returns>
        DbCommand GetDeleteCommand();

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        Source GetSource();

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <returns>
        /// </returns>
        Provider GetProvider();

        /// <summary>
        /// Gets the connection manager.
        /// </summary>
        /// <returns>
        /// </returns>
        IConnectionBuilder GetConnectionBuilder();

        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <returns>
        /// </returns>
        ISqlStatement GetSqlStatement();

        /// <summary>
        /// Gets the sq lite command.
        /// </summary>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetSQLiteCommand( ISqlStatement sqlstatement );

        /// <summary>
        /// Gets the SQL ce command.
        /// </summary>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetSqlCeCommand( ISqlStatement sqlstatement );

        /// <summary>
        /// Gets the SQL command.
        /// </summary>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetSqlCommand( ISqlStatement sqlstatement );

        /// <summary>
        /// Gets the OLE database command.
        /// </summary>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand GetOleDbCommand( ISqlStatement sqlstatement );
    }
}