// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    public interface IDataUnit 
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        object Value { get; set; }
        
        /// <summary> Determines whether the specified dataUnit is equal. </summary>
        /// <param name = "dataUnit" > The dataUnit. </param>
        /// <returns>
        /// <c> true </c>
        /// if the specified dataUnit is equal; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        bool IsMatch( IDataUnit dataUnit );
    }
}