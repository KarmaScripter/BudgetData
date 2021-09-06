// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
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
        double GetFunding();

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Gets the numeric.
        /// </summary>
        /// <returns></returns>
        Numeric GetNumeric();

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns></returns>
        IAmount GetAmount();
    }
}