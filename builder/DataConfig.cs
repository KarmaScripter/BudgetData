// <copyright file="{ClassName}.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

    public abstract class DataConfig : ISource, IProvider
    {
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected Source Source { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        private protected Provider Provider { get; set; }

        /// <summary>
        /// Gets or sets the connection builder.
        /// </summary>
        /// <value>
        /// The connection builder.
        /// </value>
        private protected IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// Gets or sets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        private protected ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        private protected IQuery Query { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the r6.
        /// </summary>
        /// <value>
        /// The r6.
        /// </value>
        private protected DataSet R6 { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Source( Source )
                    ? Source
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <returns>
        /// </returns>
        public Provider GetProvider()
        {
            try
            {
                return Verify.Provider( Provider )
                    ? Provider
                    : Provider.None;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Provider.None;
            }
        }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <returns></returns>
        public DataRow GetRecord()
        {
            try
            {
                return Verify.Row( Record )
                    ? Record
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}