// <copyright file="TableSchema.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class TableSchema
    {
        public List<ColumnSchema> Columns { get; set; }

        public List<ForeignKeySchema> ForeignKeys { get; set; }

        public List<IndexSchema> Indexes { get; set; }

        public List<string> PrimaryKey { get; set; }

        public string TableName { get; set; }

        public string TableSchemaName { get; set; }
    }
}