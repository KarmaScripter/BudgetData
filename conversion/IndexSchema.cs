// <copyright file="IndexSchema.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class IndexSchema
    {
        public List<IndexColumn> Columns;

        public string IndexName;

        public bool IsUnique;
    }

    public class IndexColumn
    {
        public string ColumnName;

        public bool IsAscending;
    }
}