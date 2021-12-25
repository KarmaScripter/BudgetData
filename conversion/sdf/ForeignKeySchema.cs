// <copyright file = "ForeignKeySchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    public class ForeignKeySchema
    {
        public bool cascadeOnDelete;

        public string columnName;

        public string foreignColumnName;

        public string foreignTableName;

        public bool isNullable;

        public string tableName;
    }
}