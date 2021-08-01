// <copyright file = "ICommandFactory.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// 
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Gets the create table command.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="dataColumns">The data columns.</param>
        /// <returns></returns>
        DbCommand GetCreateTableCommand( string tableName, IEnumerable<DataColumn> dataColumns );

        /// <summary>
        /// Gets the create view command.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="dataColumns">The data columns.</param>
        /// <returns></returns>
        DbCommand GetCreateViewCommand( string viewName, IEnumerable<DataColumn> dataColumns );

        /// <summary>
        /// Gets the drop table command.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        DbCommand GetDropTableCommand( DataTable dataTable );

        /// <summary>
        /// Gets the alter command.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="dataColumn">The data column.</param>
        /// <returns></returns>
        DbCommand GetAlterCommand( DataTable dataTable, DataColumn dataColumn );

        /// <summary>
        /// Gets the alter command.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        DbCommand GetAlterCommand( DataTable dataTable, string name );

        /// <summary>
        /// Gets the select command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetSelectCommand();

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetInsertCommand();

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetUpdateCommand();

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetDeleteCommand();

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns></returns>
        Source GetSource();

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <returns></returns>
        Provider GetProvider();

        /// <summary>
        /// Gets the connection builder.
        /// </summary>
        /// <returns></returns>
        IConnectionBuilder GetConnectionBuilder();

        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <returns></returns>
        ISqlStatement GetSqlStatement();

        /// <summary>
        /// Gets the sq lite command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        DbCommand GetSQLiteCommand( ISqlStatement sqlStatement );

        /// <summary>
        /// Gets the SQL ce command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        DbCommand GetSqlCeCommand( ISqlStatement sqlStatement );

        /// <summary>
        /// Gets the SQL command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        DbCommand GetSqlCommand( ISqlStatement sqlStatement );

        /// <summary>
        /// Gets the OLE database command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        DbCommand GetOleDbCommand( ISqlStatement sqlStatement );
    }
}