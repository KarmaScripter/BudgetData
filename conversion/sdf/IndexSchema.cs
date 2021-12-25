// <copyright file = "IndexSchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class IndexSchema
    {
        /// <summary>
        /// The columns
        /// </summary>
        public List<IndexColumn> Columns;

        /// <summary>
        /// The index name
        /// </summary>
        public string IndexName;

        /// <summary>
        /// The is unique
        /// </summary>
        public bool IsUnique;
    }

    /// <summary>
    /// 
    /// </summary>
    public class IndexColumn
    {
        /// <summary>
        /// The column name
        /// </summary>
        public string ColumnName;

        /// <summary>
        /// The is ascending
        /// </summary>
        public bool IsAscending;
    }
}