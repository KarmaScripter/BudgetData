// <copyright file="SqlTableSelectionHandler.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;

    public delegate List<TableSchema> SqlTableSelectionHandler( List<TableSchema> schema );
}
