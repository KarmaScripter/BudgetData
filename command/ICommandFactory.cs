// <copyright file = "ICommandFactory.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// 
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// The command builder
        /// </summary>
        public ICommandBuilder CommandBuilder { get; }

        /// <summary>
        /// Gets the connection builder.
        /// </summary>
        /// <value>
        /// The connection builder.
        /// </value>
        public IConnectionBuilder ConnectionBuilder { get; }

        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        public ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source { get; set; }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        public Provider Provider { get; set; }

        /// <summary>
        /// Gets the create table command.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="dataColumns">The Data Columns.</param>
        /// <returns></returns>
        DbCommand GetCreateTableCommand( string tableName, IEnumerable<DataColumn> dataColumns );

        /// <summary>
        /// Gets the create view command.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="dataColumns">The Data Columns.</param>
        /// <returns></returns>
        DbCommand GetCreateViewCommand( string viewName, IEnumerable<DataColumn> dataColumns );

        /// <summary>
        /// Gets the drop table command.
        /// </summary>
        /// <param name="dataTable">The Data table.</param>
        /// <returns></returns>
        DbCommand GetDropTableCommand( DataTable dataTable );

        /// <summary>
        /// Gets the alter command.
        /// </summary>
        /// <param name="dataTable">The Data table.</param>
        /// <param name="dataColumn">The Data column.</param>
        /// <returns></returns>
        DbCommand GetAlterCommand( DataTable dataTable, DataColumn dataColumn );

        /// <summary>
        /// Gets the alter command.
        /// </summary>
        /// <param name="dataTable">The Data table.</param>
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
    }
}