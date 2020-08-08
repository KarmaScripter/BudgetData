// <copyright file="ISqlStatement.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    /// <summary>
    /// </summary>
    public interface ISqlStatement
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <returns>
        /// SQL
        /// </returns>
        SQL GetCommandType();

        /// <summary>
        /// Gets the connection manager.
        /// </summary>
        /// <returns>
        /// </returns>
        IConnectionBuilder GetConnectionBuilder();

        /// <summary>
        /// Gets the select statement.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetSelectStatement();

        /// <summary>
        /// Gets the update statement.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetUpdateStatement();

        /// <summary>
        /// Gets the insert statement.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetInsertStatement();

        /// <summary>
        /// Gets the delete statement.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetDeleteStatement();

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> GetArgs();
    }
}