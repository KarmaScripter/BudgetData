// <copyright file = "TriggerBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    public static class TriggerBuilder
    {
        public static IList<TriggerSchema> GetForeignKeyTriggers( TableSchema dt )
        {
            IList<TriggerSchema> result = new List<TriggerSchema>();

            foreach( var fks in dt.ForeignKeys )
            {
                result.Add( GenerateInsertTrigger( fks ) );
                result.Add( GenerateUpdateTrigger( fks ) );
                result.Add( GenerateDeleteTrigger( fks ) );
            }

            return result;
        }

        private static string MakeTriggerName( ForeignKeySchema fks, string prefix )
        {
            return prefix
                + ""
                + fks.tableName
                + ""
                + fks.columnName
                + ""
                + fks.foreignTableName
                + ""
                + fks.foreignColumnName;
        }

        public static TriggerSchema GenerateInsertTrigger( ForeignKeySchema fks )
        {
            var trigger = new TriggerSchema
            {
                name = MakeTriggerName( fks, "fki" ), type = TriggerType.Before,
                @event = TriggerEvent.Insert, table = fks.tableName
            };

            var nullstring = string.Empty;

            if( fks.isNullable )
            {
                nullstring = " NEW." + fks.columnName + " IS NOT NULL AND";
            }

            trigger.body = "SELECT RAISE(ROLLBACK, 'insert on table "
                + fks.tableName
                + " violates foreign key constraint "
                + trigger.name
                + "')"
                + " WHERE"
                + nullstring
                + " (SELECT "
                + fks.foreignColumnName
                + " FROM "
                + fks.foreignTableName
                + " WHERE "
                + fks.foreignColumnName
                + " = NEW."
                + fks.columnName
                + ") IS NULL; ";

            return trigger;
        }

        public static TriggerSchema GenerateUpdateTrigger( ForeignKeySchema fks )
        {
            var trigger = new TriggerSchema
            {
                name = MakeTriggerName( fks, "fku" ), type = TriggerType.Before,
                @event = TriggerEvent.Update, table = fks.tableName
            };

            var triggername = trigger.name;
            var nullstring = string.Empty;

            if( fks.isNullable )
            {
                nullstring = " NEW." + fks.columnName + " IS NOT NULL AND";
            }

            trigger.body = "SELECT RAISE(ROLLBACK, 'update on table "
                + fks.tableName
                + " violates foreign key constraint "
                + triggername
                + "')"
                + " WHERE"
                + nullstring
                + " (SELECT "
                + fks.foreignColumnName
                + " FROM "
                + fks.foreignTableName
                + " WHERE "
                + fks.foreignColumnName
                + " = NEW."
                + fks.columnName
                + ") IS NULL; ";

            return trigger;
        }

        public static TriggerSchema GenerateDeleteTrigger( ForeignKeySchema fks )
        {
            var trigger = new TriggerSchema
            {
                name = MakeTriggerName( fks, "fkd" ), type = TriggerType.Before,
                @event = TriggerEvent.Delete, table = fks.foreignTableName
            };

            var triggername = trigger.name;

            trigger.body = !fks.cascadeOnDelete
                ? "SELECT RAISE(ROLLBACK, 'delete on table "
                + fks.foreignTableName
                + " violates foreign key constraint "
                + triggername
                + "')"
                + " WHERE (SELECT "
                + fks.columnName
                + " FROM "
                + fks.tableName
                + " WHERE "
                + fks.columnName
                + " = OLD."
                + fks.foreignColumnName
                + ") IS NOT NULL; "
                : "DELETE FROM ["
                + fks.tableName
                + "] WHERE "
                + fks.columnName
                + " = OLD."
                + fks.foreignColumnName
                + "; ";

            return trigger;
        }
    }
}