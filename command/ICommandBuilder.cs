// <copyright file = "ICommandBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data.Common;

    /// <summary>
    /// 
    /// </summary>
    public interface ICommandBuilder
    {
        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns></returns>
        DbCommand SetCommand( ISqlStatement sqlStatement );

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <returns></returns>
        DbCommand GetCommand();

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