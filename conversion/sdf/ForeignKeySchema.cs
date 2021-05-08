// <copyright file = "ForeignKeySchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    public class ForeignKeySchema
    {
        public bool CascadeOnDelete;

        public string ColumnName;

        public string ForeignColumnName;

        public string ForeignTableName;

        public bool IsNullable;

        public string TableName;
    }
}
