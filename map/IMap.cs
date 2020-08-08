// <copyright file="IKeyMap.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    public interface IMap
    {
        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        int Count { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the primary key.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetKey();

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IElement> GetElements();

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> GetInput();

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> GetOutput();
    }
}