// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    // ***************************************************************************************************************************
    // *********************************************   CONSTRUCTORS **************************************************************
    // ***************************************************************************************************************************

    /// <summary> </summary>
    /// <seealso cref = "IDataAccess"/>
    [ SuppressMessage( "ReSharper", "ImplicitlyCapturedClosure" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" ) ]
    public abstract class DataAccess : DataConfig
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the query. </summary>
        /// <returns> </returns>
        public IQuery GetQuery()
        {
            try
            {
                return Query ?? new Query( ConnectionBuilder, SqlStatement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IQuery );
            }
        }

        /// <summary> Gets the data. </summary>
        /// <returns> </returns>
        public IEnumerable<DataRow> GetData()
        {
            try
            {
                var data = GetDataTable()?.AsEnumerable();

                return Verify.Rows( data )
                    ? data
                    : default( EnumerableRowCollection<DataRow> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<DataRow> );
            }
        }

        /// <summary> Gets the data table. </summary>
        /// <returns> </returns>
        public DataTable GetDataTable()
        {
            if( Validate.Source( Source ) )
            {
                try
                {
                    R6 = new DataSet( $"{Source}" )
                    {
                        DataSetName = $"{Source}"
                    };

                    var datatable = new DataTable( $"{Source}" );
                    datatable.TableName = $"{Source}";
                    R6.Tables.Add( datatable );
                    var adapter = Query?.GetAdapter();
                    adapter?.Fill( R6, datatable.TableName );
                    SetColumnCaptions( datatable );

                    return datatable?.Rows?.Count > 0
                        ? datatable
                        : default( DataTable );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary> Gets the data set. </summary>
        /// <returns> </returns>
        public DataSet GetDataSet()
        {
            if( Enum.IsDefined( typeof( Source ), Source ) )
            {
                try
                {
                    R6 = new DataSet( "R6" )
                    {
                        DataSetName = "R6"
                    };

                    var datatable = new DataTable( $"{Source}" );
                    datatable.TableName = $"{Source}";
                    R6.Tables.Add( datatable );
                    var adapter = Query?.GetAdapter();
                    adapter?.Fill( R6, datatable?.TableName );
                    SetColumnCaptions( datatable );

                    return datatable?.Rows?.Count > 0
                        ? R6
                        : default( DataSet );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataSet );
                }
            }

            return default( DataSet );
        }

        /// <summary> Sets the column captions. </summary>
        /// <param name = "datatable" > The datatable. </param>
        public void SetColumnCaptions( DataTable datatable )
        {
            if( Verify.Table( datatable ) )
            {
                try
                {
                    foreach( DataColumn column in datatable.Columns )
                    {
                        if( column?.ColumnName?.Length < 5 )
                        {
                            var caption = column.ColumnName.ToUpper();
                            column.Caption = caption;
                            continue;
                        }

                        if( column?.ColumnName?.Length >= 5 )
                        {
                            column.Caption = column.ColumnName.SplitPascal();
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Gets the column schema. </summary>
        /// <returns> </returns>
        public DataColumnCollection GetColumnSchema()
        {
            try
            {
                var table = GetDataTable();
                SetColumnCaptions( table );

                R6 = new DataSet( $"{Source}" )
                {
                    DataSetName = $"{Source}"
                };

                var datatable = new DataTable( $"{Source}" );
                datatable.TableName = $"{Source}";
                R6.Tables.Add( datatable );
                using var adapter = Query?.GetAdapter();
                adapter?.Fill( R6, datatable.TableName );
                SetColumnCaptions( datatable );

                return table.Columns.Count > 0
                    ? table.Columns
                    : default( DataColumnCollection );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataColumnCollection );
            }
        }

        /// <summary> Gets the primary keys. </summary>
        /// <param name = "data" > The data. </param>
        /// <returns> </returns>
        public IEnumerable<int> GetPrimaryIndexes( IEnumerable<DataRow> data )
        {
            if( Verify.Input( data )
                && data?.HasPrimaryKey() == true )
            {
                try
                {
                    var table = data?.CopyToDataTable();
                    var list = table?.GetPrimaryKeyValues();

                    return list?.Any() == true
                        ? list.ToArray()
                        : default( IEnumerable<int> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<int> );
                }
            }

            return default( IEnumerable<int> );
        }

        /// <summary> Gets the column ordinals. </summary>
        /// <param name = "data" > The data. </param>
        /// <returns> </returns>
        public IEnumerable<int> GetColumnOrdinals( IEnumerable<DataColumn> data )
        {
            if( Verify.Sequence( data ) )
            {
                try
                {
                    var list = data.ToList();
                    var values = new List<int>();

                    if( list?.Any() == true )
                    {
                        foreach( var column in list )
                        {
                            values.Add( column.Ordinal );
                        }
                    }

                    return values?.Any() == true
                        ? values.ToArray()
                        : default( int[ ] );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<int> );
                }
            }

            return default( IEnumerable<int> );
        }
    }
}