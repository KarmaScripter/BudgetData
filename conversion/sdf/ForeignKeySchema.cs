// <copyright file = "ForeignKeySchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    public class ForeignKeySchema
    {
        /// <summary>
        /// The cascade on delete
        /// </summary>
        public bool CascadeOnDelete;

        /// <summary>
        /// The column name
        /// </summary>
        public string ColumnName;

        /// <summary>
        /// The foreign column name
        /// </summary>
        public string ForeignColumnName;

        /// <summary>
        /// The foreign table name
        /// </summary>
        public string ForeignTableName;

        /// <summary>
        /// The is nullable
        /// </summary>
        public bool IsNullable;

        /// <summary>
        /// The table name
        /// </summary>
        public string TableName;
    }
}