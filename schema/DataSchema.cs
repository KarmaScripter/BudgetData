// <copyright file="DataSchema.cs" company="Terry D. Eppler">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IDataSchema"/>
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    public class DataSchema : ISource, IDataSchema
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "DataSchema"/> class.
        /// </summary>
        public DataSchema()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "DataSchema"/> class.
        /// </summary>
        /// <param name = "table" >
        /// The Table.
        /// </param>
        public DataSchema( DataTable table )
        {
            Name = table?.TableName;
            Data = table?.AsEnumerable();
            IsSource = Resource.Sources.Contains( Name );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "DataSchema"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public DataSchema( IEnumerable<DataRow> data )
        {
            Name = data?.CopyToDataTable()?.TableName;
            Data = data;
            IsSource = Resource.Sources.Contains( Name );
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the name of the Table.
        /// </summary>
        /// <value>
        /// The name of the Table.
        /// </value>
        private string Name { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private IEnumerable<DataRow> Data { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is source.
        /// </summary>
        /// <value>
        /// <c>
        /// true
        /// </c>
        /// if this instance is source; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </value>
        [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
        public bool IsSource { get; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the column names.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<string> GetColumnNames()
        {
            try
            {
                var list = new List<string>();
                var table = Data?.CopyToDataTable();

                if( table?.Columns != null )
                {
                    foreach( DataColumn datacolumn in table?.Columns )
                    {
                        list.Add( datacolumn.ColumnName );
                    }
                }

                return list?.Any() == true
                    ? list
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the column captions.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<string> GetColumnCaptions()
        {
            try
            {
                var schema = Data?.CopyToDataTable()?.Columns;
                var list = new List<string>();

                if( schema != null )
                {
                    foreach( DataColumn caption in schema )
                    {
                        if( Verify.Input( caption.Caption ) )
                        {
                            list.Add( caption.Caption );
                        }
                        else if( Verify.Input( caption.ColumnName ) )
                        {
                            list.Add( caption.ColumnName.SplitPascal() );
                        }
                    }
                }

                return list?.Any() == true
                    ? list
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the column ordinals.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<int> GetColumnOrdinals()
        {
            try
            {
                var schema = Data?.CopyToDataTable()?.Columns;
                var list = new List<int>();

                if( schema != null )
                {
                    foreach( DataColumn column in schema )
                    {
                        list.Add( column.Ordinal );
                    }
                }

                return list?.Any() == true
                    ? list
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the column types.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<Type> GetColumnTypes()
        {
            try
            {
                var list = new List<Type>();
                var table = Data?.CopyToDataTable();

                if( table?.Columns != null )
                {
                    foreach( DataColumn datacolumn in table?.Columns )
                    {
                        list.Add( datacolumn.DataType );
                    }
                }

                return list?.Any() == true
                    ? list
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the primary keys.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<int> GetPrimaryKeyValues()
        {
            try
            {
                var list = new List<int>();
                var table = Data?.CopyToDataTable();

                if( table?.Rows != null )
                {
                    foreach( DataRow datarow in table?.Rows )
                    {
                        if( datarow.HasPrimaryKey() )
                        {
                            var key = datarow.GetPrimaryKey().ToArray();
                            list.Add( (int)key[ 0 ].Value );
                        }
                    }
                }

                return list?.Any() == true
                    ? list
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the primary key columns.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataColumn> GetPrimaryKeyColumn()
        {
            try
            {
                var columns = Data?.CopyToDataTable()?.PrimaryKey;

                return columns?.Any() == true
                    ? columns.ToArray()
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the column schema.
        /// </summary>
        /// <returns>
        /// </returns>
        public DataColumnCollection GetColumnSchema()
        {
            try
            {
                return Verify.Rows( Data )
                    ? Data?.CopyToDataTable()?.Columns
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the schema table.
        /// </summary>
        /// <returns>
        /// </returns>
        public DataTable GetSchemaTable()
        {
            try
            {
                var datareader = new DataTableReader( Data.CopyToDataTable() );
                return datareader?.GetSchemaTable();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the data Table.
        /// </summary>
        /// <returns>
        /// </returns>
        public DataTable GetDataTable()
        {
            try
            {
                return Verify.Rows( Data )
                    ? Data?.CopyToDataTable()
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the name of the Table.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetTableName()
        {
            try
            {
                return Verify.Input( Name )
                    ? Name
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> GetData()
        {
            try
            {
                return Verify.Rows( Data )
                    ? Data
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Input( Name ) && IsSource
                    ? (Source)Enum.Parse( typeof( Source ), Name )
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}