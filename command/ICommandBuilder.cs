// // <copyright file = "ICommandBuilder.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************
    using System;
    using System.Data.Common;
    using System.Threading;

    public interface ICommandBuilder
    {
        // ***************************************************************************************************************************
        // ****************************************************    MEMBERS    ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// </returns>
        DbCommand SetCommand( ISqlStatement sqlstatement );

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <returns>
        /// </returns>
        DbCommand GetCommand();

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