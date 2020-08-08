// <copyright file="IQuery.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
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
    using System.Threading;

    public interface IQuery : IDisposable, ISource, IProvider
    {
        bool IsDisposed { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> GetArgs();

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
        /// Gets the connection.
        /// </summary>
        /// <returns>
        /// </returns>
        DbConnection GetConnection();

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <returns>
        /// </returns>
        DbCommand GetCommand();

        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <returns>
        /// </returns>
        DbDataAdapter GetAdapter();

        /// <summary>
        /// Sets the data reader.
        /// </summary>
        /// <param name = "command" >
        /// The command.
        /// </param>
        /// <param name = "behavior" >
        /// The behavior.
        /// </param>
        /// <returns>
        /// </returns>
        DbDataReader GetDataReader( DbCommand command,
            CommandBehavior behavior = CommandBehavior.CloseConnection );
    }
}