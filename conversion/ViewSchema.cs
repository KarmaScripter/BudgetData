// <copyright file="ViewSchema.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    /// <summary>
    /// Describes a single view schema
    /// </summary>
    public class ViewSchema
    {
        /// <summary>
        /// Contains the view name
        /// </summary>
        public string ViewName;

        /// <summary>
        /// Contains the view SQL statement
        /// </summary>
        public string ViewSQL;
    }
}