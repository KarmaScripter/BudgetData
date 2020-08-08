// <copyright file="IBuilder.cs" company="Terry D. Eppler">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    public interface IBuilder : ISource
    {
        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the program elements.
        /// </summary>
        /// <value>
        /// The program elements.
        /// </value>
        IDictionary<string, IEnumerable<string>> ProgramElements { get; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns>
        /// </returns>
        DataRow GetRecord();

        /// <summary>
        /// Gets the column ordinals.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<int> GetColumnOrdinals();

        /// <summary>
        /// Gets the data elements.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<Field> GetFields();

        /// <summary>
        /// Gets the data elements.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<IElement> GetElements();

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <returns>
        /// </returns>
        Provider GetProvider();

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns>
        /// </returns>
        IQuery GetQuery();

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionbuilder.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// </returns>
        IQuery GetQuery( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement );

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<DataRow> GetData();

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns>
        /// </returns>
        DataTable GetDataTable();

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <returns>
        /// </returns>
        DataSet GetDataSet();

        /// <summary>
        /// Gets the column schema.
        /// </summary>
        /// <returns>
        /// </returns>
        DataColumnCollection GetColumnSchema();

        /// <summary>
        /// Gets the primary keys.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <returns>
        /// </returns>
        IEnumerable<int> GetPrimaryIndexes( IEnumerable<DataRow> data );

        /// <summary>
        /// Gets the column ordinals.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <returns>
        /// </returns>
        IEnumerable<int> GetColumnOrdinals( IEnumerable<DataColumn> data );
    }
}