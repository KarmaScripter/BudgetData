// <copyright file = "ColumnSchema.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Contains the schema of a single DB column.
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class ColumnSchema
    {
        public string columnName;

        public string columnType;

        public string defaultValue;

        public bool? isCaseSensitivite = null;

        public bool isIdentity;

        public bool isNullable;

        public int length;
    }
}