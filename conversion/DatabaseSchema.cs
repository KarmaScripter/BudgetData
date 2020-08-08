// <copyright file="DatabaseSchema.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Contains the entire database schema
    /// </summary>
    public class DatabaseSchema
    {
        public List<TableSchema> Tables = new List<TableSchema>();

        public List<ViewSchema> Views = new List<ViewSchema>();
    }
}