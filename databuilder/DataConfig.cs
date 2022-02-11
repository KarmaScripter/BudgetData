// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public abstract class DataConfig
    {
        /// <summary>
        /// The source
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// The provider
        /// </summary>
        public Provider Provider { get; set; }

        /// <summary>
        /// The connection builder
        /// </summary>
        public IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// The arguments
        /// </summary>
        public IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// The SQL statement
        /// </summary>
        public ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// The query
        /// </summary>
        public IQuery Query { get; set; }

        /// <summary>
        /// The record
        /// </summary>
        public DataRow Record { get; set; }

        /// <summary>
        /// The Data table
        /// </summary>
        public DataTable Table { get; set; }

        /// <summary>
        /// Gets or sets the Data set.
        /// </summary>
        /// <value>
        /// The Data set.
        /// </value>
        public DataSet DataSet { get; set; }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( );
            _error?.ShowDialog();
        }
    }
}