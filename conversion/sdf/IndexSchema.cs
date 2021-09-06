// <copyright file = "IndexSchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;

    public class IndexSchema
    {
        public List<IndexColumn> columns;

        public string indexName;

        public bool isUnique;
    }

    public class IndexColumn
    {
        public string columnName;

        public bool isAscending;
    }
}