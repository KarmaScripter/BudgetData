// <copyright file = "IConnectionBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Specialized;

    /// <summary>
    /// </summary>
    public interface IConnectionBuilder
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        Source Source { get; set; }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <returns>
        /// </returns>
        Provider Provider { get; set; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns>
        /// </returns>
        string FileName { get; set; }

        /// <summary>
        /// Gets the provider path.
        /// </summary>
        /// <returns>
        /// </returns>
        NameValueCollection ProviderPath { get; set; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>
        /// </returns>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <returns>
        /// </returns>
        string TableName { get; set; }
    }
}
