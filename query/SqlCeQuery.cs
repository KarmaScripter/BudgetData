// <copyright file="SqlCeQuery.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Threading;
    using System.Windows.Forms;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref = "T:BudgetExecution.Query"/>
    public sealed class SqlCeQuery : Query
    {
        // **********************************************************************************************************************
        // ********************************************      FIELDS     *********************************************************
        // **********************************************************************************************************************

#pragma warning disable CS0414// The field 'SqlCeQuery.Provider' is assigned but its value is never used
        private readonly Provider Provider = Provider.SqlCe;
#pragma warning restore CS0414// The field 'SqlCeQuery.Provider' is assigned but its value is never used

        // **********************************************************************************************************************
        // ********************************************   CONSTRUCTORS     ******************************************************
        // **********************************************************************************************************************

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetExecution.SqlCeQuery"/>
        /// class.
        /// </summary>
        public SqlCeQuery()
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetExecution.SqlCeQuery"/>
        /// class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        public SqlCeQuery( Source source )
            : base( source, Provider.SqlCe )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetExecution.SqlCeQuery"/>
        /// class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public SqlCeQuery( Source source, IDictionary<string, object> dict )
            : base( source, Provider.SqlCe, dict, SQL.SELECT )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlCeQuery"/> class.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionbuilder.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        public SqlCeQuery( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
            : base( connectionbuilder, sqlstatement )
        {
        }

        // **********************************************************************************************************************
        // ********************************************      PROPERTIES    ******************************************************
        // **********************************************************************************************************************

        // **********************************************************************************************************************
        // ********************************************      METHODS    *********************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the excel file path.
        /// </summary>
        /// <returns>
        /// </returns>
        private string GetExcelFilePath()
        {
            try
            {
                var fname = "";

                using var fdlg = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( fdlg.ShowDialog() == DialogResult.OK )
                {
                    fname = fdlg.FileName;
                }

                return fname;
            }
            catch( Exception ex )
            {
                using var error = new Error( ex );
                error?.SetText();
                error?.ShowDialog();
                return default;
            }
        }

        /// <summary>
        /// Creates the table from excel file.
        /// </summary>
        /// <param name = "filename" >
        /// The filepath.
        /// </param>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CreateTableFromExcelFile( string filename, ref string sheetname )
        {
            if( Verify.Input( filename )
                && Verify.Input( sheetname ) )
            {
                try
                {
                    using var dataset = new DataSet();
                    using var datatable = new DataTable();
                    dataset.DataSetName = filename;
                    datatable.TableName = sheetname;
                    dataset.Tables.Add( datatable );
                    var cstring = GetExcelFilePath();

                    if( Verify.Input( cstring ) )
                    {
                        using var excelquery = new ExcelQuery( cstring );
                        using var connection = excelquery.GetConnection() as OleDbConnection;
                        connection?.Open();
                        var adapter = excelquery.GetAdapter();
                        adapter.Fill( dataset );

                        return datatable.Columns.Count > 0
                            ? datatable
                            : default;
                    }
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Creates the table from CSV file.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CreateTableFromCsvFile( string filepath, ref string sheetname )
        {
            if( Verify.Input( filepath )
                && Verify.Input( sheetname ) )
            {
                try
                {
                    using var dataset = new DataSet();
                    using var datatable = new DataTable();
                    var filename = GetConnectionBuilder().GetFileName();
                    dataset.DataSetName = filename;
                    datatable.TableName = sheetname;
                    dataset.Tables.Add( datatable );
                    var cstring = GetExcelFilePath();

                    if( Verify.Input( cstring ) )
                    {
                        using var csvquery = new CsvQuery( cstring );
                        var adapter = csvquery.GetAdapter() as OleDbDataAdapter;
                        adapter?.Fill( dataset, sheetname );

                        return datatable.Columns.Count > 0
                            ? datatable
                            : default;
                    }
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Checks if sheet name exists.
        /// </summary>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
        /// <param name = "schematable" >
        /// The datatable.
        /// </param>
        /// <returns>
        /// </returns>
        private bool CheckIfSheetNameExists( string sheetname, DataTable schematable )
        {
            for( var i = 0; i < schematable.Rows.Count; i++ )
            {
                var datarow = schematable.Rows[ i ];

                if( sheetname == datarow[ "TABLENAME" ].ToString() )
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                Dispose();
                IsDisposed = true;
            }
        }
    }
}