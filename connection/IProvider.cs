// <copyright file="IProvider.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    public interface IProvider
    {
        // ************************************************
        // ****************   METHODS   *******************
        // ************************************************

        Provider GetProvider();
    }
}