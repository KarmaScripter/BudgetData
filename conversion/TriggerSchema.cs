// <copyright file="TriggerSchema.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    public enum TriggerEvent
    {
        Delete,

        Update,

        Insert
    }

    public enum TriggerType
    {
        After,

        Before
    }

    public class TriggerSchema
    {
        public string Body;

        public TriggerEvent Event;

        public string Name;

        public string Table;

        public TriggerType Type;
    }
}