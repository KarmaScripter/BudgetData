// <copyright file = "TriggerBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
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
                + fks.TableName
                + ""
                + fks.ColumnName
                + ""
                + fks.ForeignTableName
                + ""
                + fks.ForeignColumnName;
        }

        public static TriggerSchema GenerateInsertTrigger( ForeignKeySchema fks )
        {
            var trigger = new TriggerSchema
            {
                name = MakeTriggerName( fks, "fki" ), type = TriggerType.Before,
                @event = TriggerEvent.Insert, table = fks.TableName
            };

            var nullstring = string.Empty;

            if( fks.IsNullable )
            {
                nullstring = " NEW." + fks.ColumnName + " IS NOT NULL AND";
            }

            trigger.body = "SELECT RAISE(ROLLBACK, 'insert on table "
                + fks.TableName
                + " violates foreign key constraint "
                + trigger.name
                + "')"
                + " WHERE"
                + nullstring
                + " (SELECT "
                + fks.ForeignColumnName
                + " FROM "
                + fks.ForeignTableName
                + " WHERE "
                + fks.ForeignColumnName
                + " = NEW."
                + fks.ColumnName
                + ") IS NULL; ";

            return trigger;
        }

        public static TriggerSchema GenerateUpdateTrigger( ForeignKeySchema fks )
        {
            var trigger = new TriggerSchema
            {
                name = MakeTriggerName( fks, "fku" ), type = TriggerType.Before,
                @event = TriggerEvent.Update, table = fks.TableName
            };

            var triggername = trigger.name;
            var nullstring = string.Empty;

            if( fks.IsNullable )
            {
                nullstring = " NEW." + fks.ColumnName + " IS NOT NULL AND";
            }

            trigger.body = "SELECT RAISE(ROLLBACK, 'update on table "
                + fks.TableName
                + " violates foreign key constraint "
                + triggername
                + "')"
                + " WHERE"
                + nullstring
                + " (SELECT "
                + fks.ForeignColumnName
                + " FROM "
                + fks.ForeignTableName
                + " WHERE "
                + fks.ForeignColumnName
                + " = NEW."
                + fks.ColumnName
                + ") IS NULL; ";

            return trigger;
        }

        public static TriggerSchema GenerateDeleteTrigger( ForeignKeySchema fks )
        {
            var trigger = new TriggerSchema
            {
                name = MakeTriggerName( fks, "fkd" ), type = TriggerType.Before,
                @event = TriggerEvent.Delete, table = fks.ForeignTableName
            };

            var triggername = trigger.name;

            trigger.body = !fks.CascadeOnDelete
                ? "SELECT RAISE(ROLLBACK, 'delete on table "
                + fks.ForeignTableName
                + " violates foreign key constraint "
                + triggername
                + "')"
                + " WHERE (SELECT "
                + fks.ColumnName
                + " FROM "
                + fks.TableName
                + " WHERE "
                + fks.ColumnName
                + " = OLD."
                + fks.ForeignColumnName
                + ") IS NOT NULL; "
                : "DELETE FROM ["
                + fks.TableName
                + "] WHERE "
                + fks.ColumnName
                + " = OLD."
                + fks.ForeignColumnName
                + "; ";

            return trigger;
        }
    }
}