// <copyright file="IUnit.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    public interface IUnit
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        string GetValue();

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        object GetData();

        /// <summary>
        /// Determines whether the specified unit is equal.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>
        ///   <c>true</c> if the specified unit is equal; otherwise, <c>false</c>.
        /// </returns>
        bool IsEqual( IUnit unit );

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString();
    }
}