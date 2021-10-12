// <copyright file = "ExcelQuery.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.InteropServices;
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
    [ SuppressMessage( "ReSharper", "UnassignedReadonlyField" ) ]
    public class ExcelQuery : Query
    {
        /// <summary>
        /// 
        /// </summary>
        private protected Provider Provider { get; } = Provider.Excel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        public ExcelQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <param name="command">The command.</param>
        public ExcelQuery( string filePath, SQL command = SQL.SELECT )
            : base( filePath, command )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <param name="command">The command.</param>
        /// <param name="dict">The dictionary.</param>
        public ExcelQuery( string filePath, SQL command, IDictionary<string, object> dict )
            : base( filePath, command, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <param name="dict">The dictionary.</param>
        public ExcelQuery( string filePath, IDictionary<string, object> dict )
            : base( filePath, SQL.SELECT, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelQuery"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connectionBuilder.</param>
        /// <param name="sqlStatement">The sqlStatement.</param>
        public ExcelQuery( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
            : base( connectionBuilder, sqlStatement )
        {
        }

        /// <summary>
        /// Gets or sets the r6.
        /// </summary>
        /// <value>
        /// The r6.
        /// </value>
        public DataSet DataSet { get; set; }

        /// <summary>
        /// Gets or sets the dataTable.
        /// </summary>
        /// <value>
        /// The dataTable.
        /// </value>
        public DataTable Table { get; set; }

        /// <summary>
        /// Gets or sets the excel.
        /// </summary>
        /// <value>
        /// The excel.
        /// </value>
        public ExcelPackage Excel { get; set; }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <dict name = "workBook" >
        /// The workBook.
        /// </dict>
        public void SaveFile( Workbook workBook )
        {
            if( workBook != null )
            {
                try
                {
                    using var _dialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FilterIndex = 1
                    };

                    if( _dialog.ShowDialog() == DialogResult.OK )
                    {
                        workBook.SaveAs( _dialog.FileName );
                        const string _successful = "Save Successful!";
                        using var _message = new Message( _successful );
                        _message?.ShowDialog();
                    }
                }
                catch( Exception ex )
                {
                    ExcelQuery.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Exports to excel.
        /// </summary>
        /// <dict name = "table" >
        /// The dataTable.
        /// </dict>
        public void WriteExcelFile( DataTable table, string filePath )
        {
            if( Verify.Table( table )
                && Verify.Input( filePath ) )
            {
                try
                {
                    using var _excelPackage = ExcelQuery.ReadExcelFile( filePath );
                    var _name = Path.GetFileNameWithoutExtension( filePath );
                    using var _excelWorksheet = _excelPackage.Workbook.Worksheets.Add( _name );
                    var _columns = table.Columns.Count;
                    var _rows = table.Rows.Count;

                    for( var column = 1; column <= _columns; column++ )
                    {
                        _excelWorksheet.Cells[ 1, column ].Value = table.Columns[ column - 1 ].ColumnName;
                    }

                    for( var row = 1; row <= _rows; row++ )
                    {
                        for( var col = 0; col < _columns; col++ )
                        {
                            _excelWorksheet.Cells[ row + 1, col + 1 ].Value = table.Rows[ row - 1 ][ col ];
                        }
                    }
                }
                catch( Exception ex )
                {
                    ExcelQuery.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Creates the excel file.
        /// </summary>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        /// <returns>
        /// </returns>
        private static ExcelPackage ReadExcelFile( string filePath )
        {
            if( Verify.Input( filePath ) )
            {
                try
                {
                    var _fileInfo = new FileInfo( filePath );
                    return new ExcelPackage( _fileInfo );
                }
                catch( Exception ex )
                {
                    ExcelQuery.Fail( ex );
                    return default( ExcelPackage );
                }
            }

            return default( ExcelPackage );
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
                var _fileName = "";

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
                    _fileName = dialog.FileName;
                }

                return _fileName;
            }
            catch( Exception ex )
            {
                ExcelQuery.Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the data dataTable from excel file.
        /// </summary>
        /// <dict name = "sheetName" >
        /// The sheetName.
        /// </dict>
        /// <returns>
        /// </returns>
        public DataTable ImportData( ref string sheetName )
        {
            if( Verify.Input( sheetName ) )
            {
                try
                {
                    using var _data = new DataSet();
                    using var _connection = GetConnection();
                    _connection?.Open();
                    var _sql = "SELECT * FROM [" + sheetName + "]";

                    var _schema =
                        ( (OleDbConnection)_connection )?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( _schema?.Columns?.Count > 0
                        && !SheetExists( sheetName, _schema ) )
                    {
                        const string _msg = "Sheet Does Not Exist!";
                        using var _message = new Message( _msg );
                        _message?.ShowDialog();
                    }
                    else
                    {
                        sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var _dataAdapter = new OleDbDataAdapter( _sql, _connection as OleDbConnection );
                    _dataAdapter?.Fill( _data );
                    return _data?.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    ExcelQuery.Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Gets the data dataTable from CSV file.
        /// </summary>
        /// <dict name = "fileName" >
        /// The fileName.
        /// </dict>
        /// <dict name = "sheetName" >
        /// The sheetName.
        /// </dict>
        /// <returns>
        /// </returns>
        public DataTable CsvImport( string fileName, ref string sheetName )
        {
            if( Verify.Input( fileName )
                && Verify.Input( sheetName ) )
            {
                try
                {
                    using var _data = new DataSet();
                    var _sql = "SELECT * FROM [" + sheetName + "]";

                    var _connectionString =
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( fileName )};"
                        + @"Extended Properties='Text;HDR=YES;FMT=Delimited'";

                    using var _connection = new OleDbConnection( _connectionString );
                    var _schema = _connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( Verify.Input( sheetName ) )
                    {
                        if( !SheetExists( sheetName, _schema ) )
                        {
                            var _msg = $"{sheetName} in {fileName} Does Not Exist!";
                            using var _message = new Message( _msg );
                            _message?.ShowDialog();
                        }
                    }
                    else
                    {
                        sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var _dataAdapter = new OleDbDataAdapter( _sql, _connection );
                    _dataAdapter.Fill( _data );
                    return _data.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    ExcelQuery.Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Imports to data grid view.
        /// </summary>
        /// <dict name = "dataGrid" >
        /// The dataGrid.
        /// </dict>
        private void ExportToDataGrid( DataGridView dataGrid )
        {
            try
            {
                var _filePath = GetConnectionBuilder()?.GetFilePath();
                var _application = new App();
                var _workbook = _application.Workbooks.Open( _filePath );
                Worksheet worksheet = _workbook.Sheets[ 1 ];
                var _range = worksheet.UsedRange;
                var _rows = _range.Rows.Count;
                var _columns = _range.Columns.Count;
                dataGrid.ColumnCount = _columns;
                dataGrid.RowCount = _rows;

                for( var i = 1; i <= _rows; i++ )
                {
                    for( var j = 1; j <= _columns; j++ )
                    {
                        if( _range.Cells[ i, j ]           != null
                            && _range.Cells[ i, j ].Value2 != null )
                        {
                            dataGrid.Rows[ i - 1 ].Cells[ j - 1 ].Value =
                                _range.Cells[ i, j ].Value2.ToString();
                        }
                    }
                }

                Release( _range, worksheet, _workbook, _application );
            }
            catch( Exception ex )
            {
                ExcelQuery.Fail( ex );
            }
        }

        /// <summary>
        /// Checks if sheet name exists.
        /// </summary>
        /// <dict name = "sheetName" >
        /// Name of the sheet.
        /// </dict>
        /// <dict name = "dataTable" >
        /// The dt dataTable.
        /// </dict>
        /// <returns>
        /// </returns>
        private bool SheetExists( string sheetName, DataTable dataTable )
        {
            if( Verify.Input( sheetName )
                && dataTable?.Columns.Count > 0
                && dataTable.Rows.Count     > 0 )
            {
                try
                {
                    for( var i = 0; i < dataTable.Rows.Count; i++ )
                    {
                        var _dataRow = dataTable.Rows[ i ];

                        if( sheetName == _dataRow[ "TABLENAME" ].ToString() )
                        {
                            return true;
                        }
                    }

                    return false;
                }
                catch( Exception ex )
                {
                    ExcelQuery.Fail( ex );
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
        /// <param name = "workSheet" >
        /// The workSheet.
        /// </param>
        /// <param name = "workBook" >
        /// The workBook.
        /// </param>
        /// <param name = "excel" >
        /// The excel.
        /// </param>
        protected virtual void Release( Range range, Worksheet workSheet, Workbook workBook,
            App excel )
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject( range );
                Marshal.ReleaseComObject( workSheet );
                workBook.Close();
                Marshal.ReleaseComObject( workBook );
                excel.Quit();
                Marshal.ReleaseComObject( excel );
            }
            catch( Exception ex )
            {
                ExcelQuery.Fail( ex );
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