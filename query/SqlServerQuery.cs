// <copyright file="SqlServerQuery.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // *********************************************************************************************************
    // ********************************************      ASSEMBLIES    *****************************************
    // *********************************************************************************************************
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public sealed class SqlServerQuery : Query
    {
        // *********************************************************************************************************
        // ********************************************      FIELDS     ********************************************
        // *********************************************************************************************************

        /// <summary>
        /// Gets or sets the Provider
        /// </summary>
        private Provider Provider { get; } = Provider.SqlServer;

        // *********************************************************************************************************
        // ********************************************   CONSTRUCTORS     *****************************************
        // *********************************************************************************************************

        public SqlServerQuery()
        {
        }

        public SqlServerQuery( Source source )
            : base( source, Provider.SqlServer )
        {
        }

        public SqlServerQuery( Source source, IDictionary<string, object> dict )
            : base( source, Provider.SqlServer, dict, SQL.SELECT )
        {
        }

        public SqlServerQuery( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
            : base( connectionbuilder, sqlstatement )
        {
        }

        // *********************************************************************************************************
        // ********************************************      METHODS    ********************************************
        // *********************************************************************************************************

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                Dispose();
            }

            IsDisposed = true;
        }
    }
}