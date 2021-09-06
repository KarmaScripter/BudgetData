// <copyright file = "SqlServerQuery.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.Query" />
    public class SqlServerQuery : Query
    {
        /// <summary>
        /// Gets or sets the _provider
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        private readonly Provider _provider = Provider.SqlServer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerQuery"/> class.
        /// </summary>
        public SqlServerQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public SqlServerQuery( Source source )
            : base( source, Provider.SqlServer )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="dict">The dictionary.</param>
        public SqlServerQuery( Source source, IDictionary<string, object> dict )
            : base( source, Provider.SqlServer, dict, SQL.SELECT )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerQuery"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connectionBuilder.</param>
        /// <param name="sqlStatement">The sqlStatement.</param>
        public SqlServerQuery( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
            : base( connectionBuilder, sqlStatement )
        {
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing"><c>
        /// true
        /// </c>
        /// to release both managed and unmanaged resources;
        /// <c>
        /// false
        /// </c>
        /// to release only unmanaged resources.</param>
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
