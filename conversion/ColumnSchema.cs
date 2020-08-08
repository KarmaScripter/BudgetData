// <copyright file="ColumnSchema.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// Contains the schema of a single DB column.
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public sealed class ColumnSchema
    {
        public string ColumnName;

        public string ColumnType;

        public string DefaultValue;

        public bool? IsCaseSensitivite = null;

        public bool IsIdentity;

        public bool IsNullable;

        public int Length;
    }
}