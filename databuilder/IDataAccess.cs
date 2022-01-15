// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary> </summary>
    public interface IDataAccess
    {
        /// <summary> Gets the query. </summary>
        /// <returns> </returns>
        IQuery GetQuery();

        /// <summary> Gets the query. </summary>
        /// <param name = "connectionBuilder" > The connectionBuilder. </param>
        /// <param name = "sqlStatement" > The sqlStatement. </param>
        /// <returns> </returns>
        IQuery GetQuery( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement );

        /// <summary> Gets the record. </summary>
        /// <returns> </returns>
        DataRow GetRecord();

        /// <summary> Gets the Data. </summary>
        /// <returns> </returns>
        IEnumerable<DataRow> GetData();

        /// <summary> Gets the Data table. </summary>
        /// <returns> </returns>
        DataTable GetDataTable();

        /// <summary> Sets the column captions. </summary>
        /// <param name = "dataTable" > The dataTable. </param>
        void SetColumnCaptions( DataTable dataTable );

        /// <summary> Gets the column schema. </summary>
        /// <returns> </returns>
        DataColumnCollection GetColumnSchema();

        /// <summary> Gets the schema table. </summary>
        /// <param name = "dataTable" > The dataTable. </param>
        /// <returns> </returns>
        DataTable GetSchemaTable( DataTable dataTable );

        /// <summary> Gets the primary indexes. </summary>
        /// <param name = "data" > The Data. </param>
        /// <returns> </returns>
        IEnumerable<int> GetPrimaryIndexes( IEnumerable<DataRow> data );

        /// <summary> Gets the column ordinals. </summary>
        /// <param name = "data" > The Data. </param>
        /// <returns> </returns>
        IEnumerable<int> GetColumnOrdinals( IEnumerable<DataColumn> data );

        /// <summary> Gets the Data set. </summary>
        /// <returns> </returns>
        DataSet GetDataSet();
    }
}