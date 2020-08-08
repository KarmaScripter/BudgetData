// <copyright file="IElement.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    // ***************************************************************************************************************************
    // ****************************************************     METHODS   ********************************************************
    // ***************************************************************************************************************************

    public interface IElement
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetName();

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetValue();

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <returns>
        /// </returns>
        Field GetField();
    }
}