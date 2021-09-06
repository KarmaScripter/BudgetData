// <copyright file = "SqlCeQuery.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Windows.Forms;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref = "T:BudgetExecution.Query"/>
    public class SqlCeQuery : Query
    {
        private readonly Provider _provider = Provider.SqlCe;
        
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
        /// <param name = "connectionBuilder" >
        /// The connectionBuilder.
        /// </param>
        /// <param name = "sqlStatement" >
        /// The sqlStatement.
        /// </param>
        public SqlCeQuery( IConnectionBuilder connectionBuilder, ISqlStatement sqlStatement )
            : base( connectionBuilder, sqlStatement )
        {
        }

        /// <summary>
        /// Gets the excel file path.
        /// </summary>
        /// <returns>
        /// </returns>
        private string GetExcelFilePath()
        {
            try
            {
                var _fileName = "";

                using var _fileDialog = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
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
        /// Creates the table from excel file.
        /// </summary>
        /// <param name = "fileName" >
        /// The filePath.
        /// </param>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CreateTableFromExcelFile( string fileName, ref string sheetName )
        {
            if( Verify.Input( fileName )
                && Verify.Input( sheetName ) )
            {
                try
                {
                    using var _dataSet = new DataSet();
                    using var _dataTable = new DataTable();
                    _dataSet.DataSetName = fileName;
                    _dataTable.TableName = sheetName;
                    _dataSet.Tables.Add( _dataTable );
                    var cstring = GetExcelFilePath();

                    if( Verify.Input( cstring ) )
                    {
                        using var _excelQuery = new ExcelQuery( cstring );
                        using var _connection = _excelQuery.GetConnection() as OleDbConnection;
                        _connection?.Open();

                        using var _dataAdapter = _excelQuery.GetAdapter();
                        _dataAdapter.Fill( _dataSet );

                        return _dataTable.Columns.Count > 0
                            ? _dataTable
                            : default( DataTable );
                    }
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
        /// Creates the table from CSV file.
        /// </summary>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CreateTableFromCsvFile( string filePath, ref string sheetName )
        {
            if( Verify.Input( filePath )
                && Verify.Input( sheetName ) )
            {
                try
                {
                    using var _dataSet = new DataSet();
                    using var _dataTable = new DataTable();
                    var _fileName = GetConnectionBuilder().GetFileName();
                    _dataSet.DataSetName = _fileName;
                    _dataTable.TableName = sheetName;
                    _dataSet.Tables.Add( _dataTable );
                    var _cstring = GetExcelFilePath();

                    if( Verify.Input( _cstring ) )
                    {
                        using var _csvQuery = new CsvQuery( _cstring );
                        using var _dataAdapter = _csvQuery.GetAdapter() as OleDbDataAdapter;
                        _dataAdapter?.Fill( _dataSet, sheetName );

                        return _dataTable.Columns.Count > 0
                            ? _dataTable
                            : default( DataTable );
                    }
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
        /// Checks if sheet name exists.
        /// </summary>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <param name = "schemaTable" >
        /// The datatable.
        /// </param>
        /// <returns>
        /// </returns>
        private bool CheckIfSheetNameExists( string sheetName, DataTable schemaTable )
        {
            if( Verify.Input( sheetName ) 
                && Verify.Table( schemaTable ) )
            {
                for( var i = 0; i < schemaTable.Rows.Count; i++ )
                {
                    var _dataRow = schemaTable.Rows[ i ];

                    if( sheetName == _dataRow[ "TABLENAME" ].ToString() )
                    {
                        return true;
                    }
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
