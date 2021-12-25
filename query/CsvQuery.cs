// <copyright file = "CsvQuery.cs" company = "Terry D. Eppler">
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
    using System.Windows.Forms;
    using OfficeOpenXml;
    using DataTable = System.Data.DataTable;

    /// <summary>
    /// </summary>
    /// <seealso cref = "Query"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class CsvQuery : Query
    {
        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        public Provider Provider { get; } = Provider.CSV;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        public CsvQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        /// <param name = "command" >
        /// The command.
        /// </param>
        public CsvQuery( string filePath, SQL command = SQL.SELECT )
            : base( filePath, command )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public CsvQuery( string filePath, IDictionary<string, object> dict )
            : base( filePath, SQL.SELECT, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        /// <param name = "command" >
        /// The command.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public CsvQuery( string filePath, SQL command, IDictionary<string, object> dict = null )
            : base( filePath, command, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "CsvQuery"/> class.
        /// </summary>
        /// <param name = "connectionBuilder" >
        /// The connectionBuilder.
        /// </param>
        /// <param name = "sqlStatement" >
        /// The sqlStatement.
        /// </param>
        public CsvQuery( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
            : base( connectionBuilder, sqlStatement )
        {
        }
        
        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name = "workBook" >
        /// The workBook.
        /// </param>
        public void SaveFile( ExcelPackage workBook )
        {
            if( workBook != null )
            {
                try
                {
                    using var _fileDialog = new SaveFileDialog
                    {
                        Filter = "CSV files (*.csv)|*.csv",
                        FilterIndex = 1
                    };

                    if( _fileDialog.ShowDialog() == DialogResult.OK )
                    {
                        workBook.SaveAs( new FileInfo( _fileDialog.FileName ) );
                        const string _msg = "Save Successful!";
                        using var _message = new Message( _msg );
                        _message?.ShowDialog();
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// CSVs the import.
        /// </summary>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CsvImport( ref string sheetName )
        {
            if( Verify.Input( sheetName )
                && Verify.Input( sheetName ) )
            {
                try
                {
                    using var _dataSet = new DataSet();
                    var _sql = "SELECT * FROM [" + sheetName + "]";

                    var _connectionString =
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( sheetName )};"
                        + "Extended Properties='Text;HDR=YES;FMT=Delimited'";

                    using var _connection = new OleDbConnection( _connectionString );
                    var _schema = _connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( Verify.Input( sheetName ) )
                    {
                        if( !SheetExists( sheetName, _schema ) )
                        {
                            var _msg = $"{sheetName} in {sheetName} Does Not Exist!";
                            using var _message = new Message( _msg );
                            _message?.ShowDialog();
                        }
                    }
                    else
                    {
                        sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var _dataAdapter = new OleDbDataAdapter( _sql, _connection );
                    _dataAdapter.Fill( _dataSet );
                    return _dataSet.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// CSVs the import.
        /// </summary>
        /// <param name = "fileName" >
        /// The fileName.
        /// </param>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CsvImport( string fileName, ref string sheetName )
        {
            if( Verify.Input( fileName )
                && Verify.Input( sheetName ) )
            {
                try
                {
                    using var _dataSet = new DataSet();
                    var _sql = "SELECT * FROM [" + sheetName + "]";

                    var _connectionString =
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( fileName )};Extended Properties='Text;HDR=YES;FMT=Delimited'";

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
                    _dataAdapter.Fill( _dataSet );
                    return _dataSet.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// CSVs the export.
        /// </summary>
        /// <param name = "table" >
        /// The table.
        /// </param>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        public void CsvExport( DataTable table, string filePath )
        {
            if( table?.Columns.Count > 0 
                && table.Rows.Count > 0 
                && Verify.Input( filePath ) )
            {
                try
                {
                    using var _excelPackage = CreateCsvFile( filePath );
                    var _withoutExtension = Path.GetFileNameWithoutExtension( filePath );
                    var _excelWorksheet = _excelPackage.Workbook.Worksheets.Add( _withoutExtension );
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
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// CSVs the export.
        /// </summary>
        /// <param name = "dataGrid" >
        /// The dataGrid.
        /// </param>
        public void CsvExport( DataGridView dataGrid )
        {
            if( dataGrid?.DataSource != null )
            {
                try
                {
                    var _filePath = GetConnectionBuilder().GetFilePath();
                    using var _excelPackage = new ExcelPackage( new FileInfo( _filePath ) );
                    var _excelWorkbook = _excelPackage.Workbook;
                    var _excelWorksheet = _excelWorkbook.Worksheets[ 1 ];
                    var _rows = _excelWorksheet.SelectedRange.Rows;
                    var _columns = _excelWorksheet.SelectedRange.Columns;
                    dataGrid.ColumnCount = _columns;
                    dataGrid.RowCount = _rows;

                    for( var i = 1; i <= _rows; i++ )
                    {
                        for( var j = 1; j <= _columns; j++ )
                        {
                            if( _excelWorksheet.Cells[ i, j ] != null
                                && _excelWorksheet.Cells[ i, j ].Value != null )
                            {
                                dataGrid.Rows[ i - 1 ].Cells[ j - 1 ].Value =
                                    _excelWorksheet.Cells[ i, j ].Value.ToString();
                            }
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
        /// Creates the CSV file.
        /// </summary>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        /// <returns>
        /// </returns>
        public ExcelPackage CreateCsvFile( string filePath )
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
                    Fail( ex );
                    return default( ExcelPackage );
                }
            }

            return default( ExcelPackage );
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
                var _fileName = "";

                using var _fileDialog = new OpenFileDialog
                {
                    Title = "CSV File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( _fileDialog.ShowDialog() == DialogResult.OK )
                {
                    _fileName = _fileDialog.FileName;
                }

                return _fileName;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Sheets the exists.
        /// </summary>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <param name = "dataTable" >
        /// The dataTable.
        /// </param>
        /// <returns>
        /// </returns>
        private bool SheetExists( string sheetName, DataTable dataTable )
        {
            if( Verify.Input( sheetName ) 
                && dataTable?.Columns.Count > 0 
                && dataTable.Rows.Count > 0 )
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
                    Fail( ex );
                }
            }

            return false;
        }
    }
}
