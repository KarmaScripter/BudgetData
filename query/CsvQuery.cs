// <copyright file="CsvQuery.cs" company="Terry D. Eppler">
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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Excel;
    using OfficeOpenXml;
    using App = Microsoft.Office.Interop.Excel.Application;
    using DataTable = System.Data.DataTable;

    /// <summary>
    /// </summary>
    /// <seealso cref = "Query"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class CsvQuery : Query
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        private Provider Provider { get; } = Provider.CSV;

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        public CsvQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <param name = "command" >
        /// The command.
        /// </param>
        public CsvQuery( string filepath, SQL command = SQL.SELECT )
            : base( filepath, command )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public CsvQuery( string filepath, IDictionary<string, object> dict )
            : base( filepath, SQL.SELECT, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <param name = "command" >
        /// The command.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public CsvQuery( string filepath, SQL command, IDictionary<string, object> dict = null )
            : base( filepath, command, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionbuilder.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        public CsvQuery( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
            : base( connectionbuilder, sqlstatement )
        {
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the data set.
        /// </summary>
        /// <value>
        /// The data set.
        /// </value>
        private DataSet DataSet { get; set; }

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>
        /// The table.
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
        /// <param name = "workbook" >
        /// The workbook.
        /// </param>
        public void SaveFile( Workbook workbook )
        {
            if( workbook != null )
            {
                try
                {
                    using var dialog = new SaveFileDialog
                    {
                        Filter = "CSV files (*.csv)|*.csv",
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
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// CSVs the import.
        /// </summary>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CsvImport( ref string sheetname )
        {
            if( Verify.Input( sheetname )
                && Verify.Input( sheetname ) )
            {
                try
                {
                    using var data = new DataSet();
                    var sql = "SELECT * FROM [" + sheetname + "]";

                    var conectionstring =
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( sheetname )};Extended Properties='Text;HDR=YES;FMT=Delimited'";

                    using var connection = new OleDbConnection( conectionstring );
                    var schema = connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( Verify.Input( sheetname ) )
                    {
                        if( !SheetExists( sheetname, schema ) )
                        {
                            var msg = $"{sheetname} in {sheetname} Does Not Exist!";
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
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// CSVs the import.
        /// </summary>
        /// <param name = "filename" >
        /// The filename.
        /// </param>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
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
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( filename )};Extended Properties='Text;HDR=YES;FMT=Delimited'";

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
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// CSVs the export.
        /// </summary>
        /// <param name = "table" >
        /// The table.
        /// </param>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        public void CsvExport( DataTable table, string filepath )
        {
            if( table != null
                && table.Columns.Count > 0
                && table.Rows.Count > 0
                && Verify.Input( filepath ) )
            {
                try
                {
                    using var excel = CreateCsvFile( filepath );
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
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// CSVs the export.
        /// </summary>
        /// <param name = "datagrid" >
        /// The datagrid.
        /// </param>
        public void CsvExport( DataGridView datagrid )
        {
            if( datagrid?.DataSource != null )
            {
                try
                {
                    var filepath = GetConnectionBuilder().GetFilePath();
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
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Creates the CSV file.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <returns>
        /// </returns>
        public ExcelPackage CreateCsvFile( string filepath )
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
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the CSV file.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetCsvFile()
        {
            try
            {
                var fname = "";

                using var dialog = new OpenFileDialog
                {
                    Title = "CSV File Dialog",
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
                using var error = new Error( ex );
                error?.SetText();
                error?.ShowDialog();
                return default;
            }
        }

        /// <summary>
        /// Sheets the exists.
        /// </summary>
        /// <param name = "sheetname" >
        /// The sheetname.
        /// </param>
        /// <param name = "datatable" >
        /// The datatable.
        /// </param>
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
                        var row = datatable.Rows[ i ];

                        if( sheetname == row[ "TABLENAME" ].ToString() )
                        {
                            return true;
                        }
                    }

                    return false;
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }

            return false;
        }

        /// <summary>
        /// Releases the specified range.
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
        private void Release( Range range, Worksheet worksheet, _Workbook workbook,
            _Application excel )
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
                using var error = new Error( ex );
                error?.SetText();
                error?.ShowDialog();
                Dispose( true );
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name = "disposing" >
        /// <c>
        /// true
        /// </c>
        /// to release both managed and unmanaged resources;
        /// <c>
        /// false
        /// </c>
        /// to release only unmanaged resources.
        /// </param>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                base.Dispose();
            }
        }
    }
}