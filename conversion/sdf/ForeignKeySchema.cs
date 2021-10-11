// <copyright file = "ForeignKeySchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    /// <summary>
    /// 
    /// </summary>
    public class ForeignKeySchema
    {
        /// <summary>
        /// The cascade on delete
        /// </summary>
        public bool cascadeOnDelete;

        /// <summary>
        /// The column name
        /// </summary>
        public string columnName;

        /// <summary>
        /// The foreign column name
        /// </summary>
        public string foreignColumnName;

        /// <summary>
        /// The foreign table name
        /// </summary>
        public string foreignTableName;

        /// <summary>
        /// The is nullable
        /// </summary>
        public bool isNullable;

        /// <summary>
        /// The table name
        /// </summary>
        public string tableName;
    }
}