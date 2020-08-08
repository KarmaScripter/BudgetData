// <copyright file="SqlConversionHandler.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;

    public delegate void SqlConversionHandler( bool done, bool success, int percent,
        string msg );
}
