// <copyright file = "DataWorker.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    public class DataWorker : BackgroundWorker
    {
        /// <summary>
        /// 
        /// </summary>
        public Builder UnitBuilder { get; protected internal set; }

        /// <summary>
        /// 
        /// </summary>
        public DataWorker()
        {
        }
        
        /// <summary>
        /// Gets or sets the binding source.
        /// </summary>
        /// <value>
        /// The binding source.
        /// </value>
        public BindingSource BindingSource { get; set; }
    }
}
