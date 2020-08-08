// <copyright file="ExcelQuery.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **************************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Excel;
    using OfficeOpenXml;
    using App = Microsoft.Office.Interop.Excel.Application;
    using DataTable = System.Data.DataTable;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref = "T:BudgetExecution.Query"/>
    /// <seealso cref = "T:BudgetExecution.IQueryBase"/>
    public class ExcelQuery : Query
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        private protected Provider Provider { get; } = Provider.Excel;

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        public ExcelQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="command">The command.</param>
        public ExcelQuery( string filepath, SQL command = SQL.SELECT )
            : base( filepath, command )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="command">The command.</param>
        /// <param name="dict">The dictionary.</param>
        public ExcelQuery( string filepath, SQL command, IDictionary<string, object> dict )
            : base( filepath, command, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="dict">The dictionary.</param>
        public ExcelQuery( string filepath, IDictionary<string, object> dict )
            : base( filepath, SQL.SELECT, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        /// <param name="connectionbuilder">The connectionbuilder.</param>
        /// <param name="sqlstatement">The sqlstatement.</param>
        public ExcelQuery( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
            : base( connectionbuilder, sqlstatement )
        {
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the r6.
        /// </summary>
        /// <value>
        /// The r6.
        /// </value>
        private DataSet DataSet { get; set; }

        /// <summary>
        /// Gets or sets the datatable.
        /// </summary>
        /// <value>
        /// The datatable.
        /// </value>
        private DataTable Table { get; set; }

        /// <summary>
        /// Gets or sets the excel.
        /// </summary>
        /// <value>
        /// The excel.
        /// </value>
        private ExcelPackage Excel { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <dict name = "workbook" >
        /// The workbook.
        /// </dict>
        public void SaveFile( Workbook workbook )
        {
            if( workbook != null )
            {
                try
                {
                    using var dialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FilterIndex = 1
                    };

                    if( dialog.ShowDialog() == DialogResult.OK )
                    {
                        workbook.SaveAs( dialog.FileName );
                        const string msg = "Save Successful!";
                        using var message = new Message( msg );
                        message?.ShowDialog();
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Exports to excel.
        /// </summary>
        /// <dict name = "table" >
        /// The datatable.
        /// </dict>
        public void WriteExcelFile( DataTable table, string filepath )
        {
            if( Verify.Table( table )
                && Verify.Input( filepath ) )
            {
                try
                {
                    using var excel = ReadExcelFile( filepath );
                    var filename = Path.GetFileNameWithoutExtension( filepath );
                    var worksheet = excel.Workbook.Worksheets.Add( filename );
                    var columns = table.Columns.Count;
                    var rows = table.Rows.Count;

                    for( var column = 1; column <= columns; column++ )
                    {
                        worksheet.Cells[ 1, column ].Value = table.Columns[ column - 1 ].ColumnName;
                    }

                    for( var row = 1; row <= rows; row++ )
                    {
                        for( var col = 0; col < columns; col++ )
                        {
                            worksheet.Cells[ row + 1, col + 1 ].Value = table.Rows[ row - 1 ][ col ];
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Creates the excel file.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <returns>
        /// </returns>
        private static ExcelPackage ReadExcelFile( string filepath )
        {
            if( Verify.Input( filepath ) )
            {
                try
                {
                    var fileinfo = new FileInfo( filepath );
                    return new ExcelPackage( fileinfo );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetExcelFile()
        {
            try
            {
                var fname = "";

                using var dialog = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    fname = dialog.FileName;
                }

                return fname;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the data datatable from excel file.
        /// </summary>
        /// <dict name = "sheetname" >
        /// The sheetname.
        /// </dict>
        /// <returns>
        /// </returns>
        public DataTable ImportData( ref string sheetname )
        {
            if( Verify.Input( sheetname ) )
            {
                try
                {
                    using var dataset = new DataSet();
                    using var connection = GetConnection();
                    connection?.Open();
                    var sql = "SELECT * FROM [" + sheetname + "]";

                    var schema =
                        ( (OleDbConnection)connection )?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( schema != null
                        && schema.Columns?.Count > 0
                        && !SheetExists( sheetname, schema ) )
                    {
                        const string msg = "Sheet Does Not Exist!";
                        using var message = new Message( msg );
                        message?.ShowDialog();
                    }
                    else
                    {
                        sheetname = schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var adapter = new OleDbDataAdapter( sql, connection as OleDbConnection );
                    adapter?.Fill( dataset );
                    return dataset?.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the data datatable from CSV file.
        /// </summary>
        /// <dict name = "filename" >
        /// The filename.
        /// </dict>
        /// <dict name = "sheetname" >
        /// The sheetname.
        /// </dict>
        /// <returns>
        /// </returns>
        public DataTable CsvImport( string filename, ref string sheetname )
        {
            if( Verify.Input( filename )
                && Verify.Input( sheetname ) )
            {
                try
                {
                    using var data = new DataSet();
                    var sql = "SELECT * FROM [" + sheetname + "]";

                    var conectionstring =
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( filename )};" 
                        + @"Extended Properties='Text;HDR=YES;FMT=Delimited'";

                    using var connection = new OleDbConnection( conectionstring );
                    var schema = connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( Verify.Input( sheetname ) )
                    {
                        if( !SheetExists( sheetname, schema ) )
                        {
                            var msg = $"{sheetname} in {filename} Does Not Exist!";
                            using var message = new Message( msg );
                            message?.ShowDialog();
                        }
                    }
                    else
                    {
                        sheetname = schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var adapter = new OleDbDataAdapter( sql, connection );
                    adapter.Fill( data );
                    return data.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Imports to data grid view.
        /// </summary>
        /// <dict name = "datagrid" >
        /// The datagrid.
        /// </dict>
        private void ExportToDataGrid( DataGridView datagrid )
        {
            try
            {
                var filepath = GetConnectionBuilder()?.GetFilePath();
                var excel = new App();
                var workbook = excel.Workbooks.Open( filepath );
                Worksheet worksheet = workbook.Sheets[ 1 ];
                var range = worksheet.UsedRange;
                var rows = range.Rows.Count;
                var columns = range.Columns.Count;
                datagrid.ColumnCount = columns;
                datagrid.RowCount = rows;

                for( var i = 1; i <= rows; i++ )
                {
                    for( var j = 1; j <= columns; j++ )
                    {
                        if( range.Cells[ i, j ] != null
                            && range.Cells[ i, j ].Value2 != null )
                        {
                            datagrid.Rows[ i - 1 ].Cells[ j - 1 ].Value =
                                range.Cells[ i, j ].Value2.ToString();
                        }
                    }
                }

                Release( range, worksheet, workbook, excel );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Checks if sheet name exists.
        /// </summary>
        /// <dict name = "sheetname" >
        /// Name of the sheet.
        /// </dict>
        /// <dict name = "datatable" >
        /// The dt datatable.
        /// </dict>
        /// <returns>
        /// </returns>
        private bool SheetExists( string sheetname, DataTable datatable )
        {
            if( Verify.Input( sheetname )
                && datatable != null
                && datatable.Columns.Count > 0
                && datatable.Rows.Count > 0 )
            {
                try
                {
                    for( var i = 0; i < datatable.Rows.Count; i++ )
                    {
                        var datarow = datatable.Rows[ i ];

                        if( sheetname == datarow[ "TABLENAME" ].ToString() )
                        {
                            return true;
                        }
                    }

                    return false;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return false;
        }

        /// <summary>
        /// Disposes the excel objects.
        /// </summary>
        /// <param name = "range" >
        /// The range.
        /// </param>
        /// <param name = "worksheet" >
        /// The worksheet.
        /// </param>
        /// <param name = "workbook" >
        /// The workbook.
        /// </param>
        /// <param name = "excel" >
        /// The excel.
        /// </param>
        protected virtual void Release( Range range, Worksheet worksheet, Workbook workbook,
            App excel )
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject( range );
                Marshal.ReleaseComObject( worksheet );
                workbook.Close();
                Marshal.ReleaseComObject( workbook );
                excel.Quit();
                Marshal.ReleaseComObject( excel );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                base.Dispose();
            }

            IsDisposed = true;
        }
    }
}