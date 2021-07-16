// // <copyright file = "TriggerSchema.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;

    public enum TriggerEvent { Delete, Update, Insert }

    public enum TriggerType { After, Before }

    public class TriggerSchema
    {
        public string body;

        public TriggerEvent @event;

        public string name;

        public string table;

        public TriggerType type;
    }
}