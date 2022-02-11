// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAmount
    {
        /// <summary>
        /// Gets the funding.
        /// </summary>
        /// <returns></returns>
        double Funding { get; set; }
        
        /// <summary>
        /// Gets the numeric.
        /// </summary>
        /// <returns></returns>
        Numeric Numeric { get; set; }
    }
}