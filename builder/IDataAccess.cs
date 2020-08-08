// <copyright file="IDataAccess.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
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

    /// <summary>
    /// 
    /// </summary>
    public interface IDataAccess
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns></returns>
        IQuery GetQuery();

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <param name="connectionbuilder">The connectionbuilder.</param>
        /// <param name="sqlstatement">The sqlstatement.</param>
        /// <returns></returns>
        IQuery GetQuery( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement );

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <returns></returns>
        DataRow GetRecord();

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataRow> GetData();

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns></returns>
        DataTable GetDataTable();

        /// <summary>
        /// Sets the column captions.
        /// </summary>
        /// <param name="datatable">The datatable.</param>
        void SetColumnCaptions( DataTable datatable );

        /// <summary>
        /// Gets the column schema.
        /// </summary>
        /// <returns></returns>
        DataColumnCollection GetColumnSchema();

        /// <summary>
        /// Gets the schema table.
        /// </summary>
        /// <param name="datatable">The datatable.</param>
        /// <returns></returns>
        DataTable GetSchemaTable( DataTable datatable );

        /// <summary>
        /// Gets the primary indexes.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        IEnumerable<int> GetPrimaryIndexes( IEnumerable<DataRow> data );

        /// <summary>
        /// Gets the column ordinals.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        IEnumerable<int> GetColumnOrdinals( IEnumerable<DataColumn> data );

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <returns></returns>
        DataSet GetDataSet();
    }
}