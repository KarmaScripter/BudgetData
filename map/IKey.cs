// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
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
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns></returns>
        int GetIndex();

        /// <summary>
        /// Gets the primary key.
        /// </summary>
        /// <returns></returns>
        PrimaryKey GetPrimaryKey();
    }
}