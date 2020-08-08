// <copyright file="IConnectionBuilder.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    /// <summary>
    /// </summary>
    public interface IConnectionBuilder
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
        /// Gets the file path.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetFilePath();

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        /// <returns>
        /// </returns>
        EXT GetFileExtension();

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetFileName();

        /// <summary>
        /// Gets the provider path.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetProviderPath();

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetConnectionString();

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetTableName();
    }
}