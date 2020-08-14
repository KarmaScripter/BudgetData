// <copyright file = "DataBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

using System.IO;
using OfficeOpenXml;

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

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class DataBuilder : Builder
    {
        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DataBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "provider" >
        /// The provider.
        /// </param>
        public DataBuilder( Source source, Provider provider = Provider.SQLite )
            : base( source, provider )
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "provider" >
        /// The provider.
        /// </param>
        /// <param name = "args" >
        /// The arguments.
        /// </param>
        public DataBuilder( Source source, Provider provider, IDictionary<string, object> args )
            : base( source, provider, args )
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public DataBuilder( Source source, IDictionary<string, object> dict )
            : base( source, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public DataBuilder( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public DataBuilder( DataRow data )
        {
            Record = data;
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        public DateTime GetDate( Field field )
        {
            if( Verify.Row( Record )
                && Verify.Field( field ) )
            {
                try
                {
                    var columns = Record.Table?.GetColumnNames();

                    if( columns?.Contains( $"{field}" ) == true )
                    {
                        var date = Record.GetDate( field );

                        return Verify.DateTime( date )
                            ? date
                            : default;
                    }
                    else
                    {
                        return default;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Loads from excel.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="header">if set to <c>true</c> [header].</param>
        /// <returns></returns>
        public DataTable LoadFromExcel( string path, bool header = true )
        {
            if( Verify.Input( path ) )
            {
                try
                {
                    using var excel = new ExcelPackage();
                    using var stream = File.OpenRead( path );
                    excel.Load( stream );
                    var worksheet = excel.Workbook.Worksheets.First();
                    var table = new DataTable();

                    foreach( var firstrowcell in worksheet.Cells[ 1, 1, 1, worksheet.Dimension.End.Column ] )
                    {
                        table.Columns.Add( header
                            ? firstrowcell.Text
                            : $"Column {firstrowcell.Start.Column}" );
                    }

                    var startrow = header
                        ? 2
                        : 1;

                    for( var rownum = startrow; rownum <= worksheet.Dimension.End.Row; rownum++ )
                    {
                        var range = worksheet.Cells[ rownum, 1, rownum, worksheet.Dimension.End.Column ];
                        var row = table.Rows.Add();

                        foreach( var cell in range )
                        {
                            row[ cell.Start.Column - 1 ] = cell.Text;
                        }
                    }

                    return table;
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
        /// Gets the data.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "filter" >
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> FilterData( Field field, string filter )
        {
            if( Verify.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var query = GetData()
                        ?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        ?.Select( p => p );

                    return query?.Any() == true
                        ? query.ToArray()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }
    }
}
