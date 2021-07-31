// <copyright file = "DatabaseSchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains the entire database schema
    /// </summary>
    public class DatabaseSchema
    {
        public List<TableSchema> tables = new List<TableSchema>();

        public List<ViewSchema> views = new List<ViewSchema>();
    }
}