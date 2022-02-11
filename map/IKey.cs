// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    /// <summary>
    /// 
    /// </summary>
    public interface IKey
    {
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns></returns>
        int Index { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string Name { get; set; }
    }
}