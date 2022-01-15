// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    /// <summary> </summary>
    public interface ISqlStatement
    {
        IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <returns>
        /// SQL
        /// </returns>
        SQL GetCommandType();
        
        /// <summary>
        /// Gets the select statement.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetSelectStatement();

        /// <summary> Gets the update statement. </summary>
        /// <returns> </returns>
        string GetUpdateStatement();

        /// <summary> Gets the insert statement. </summary>
        /// <returns> </returns>
        string GetInsertStatement();

        /// <summary> Gets the delete statement. </summary>
        /// <returns> </returns>
        string GetDeleteStatement();
    }
}