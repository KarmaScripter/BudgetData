// <copyright file = "ColumnSchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Contains the schema of a single DB column.
    /// </summary>
    [SuppressMessage( "ReSharper", "MemberCanBeInternal" )]
    public class ColumnSchema
    {
        /// <summary>
        /// The column name
        /// </summary>
        public string ColumnName;

        /// <summary>
        /// The column type
        /// </summary>
        public string ColumnType;

        /// <summary>
        /// The default value
        /// </summary>
        public string DefaultValue;

        /// <summary>
        /// The is case sensitivite
        /// </summary>
        public bool? IsCaseSensitivite = null;

        /// <summary>
        /// The is identity
        /// </summary>
        public bool IsIdentity;

        /// <summary>
        /// The is nullable
        /// </summary>
        public bool IsNullable;

        /// <summary>
        /// The length
        /// </summary>
        public int Length;
    }
}