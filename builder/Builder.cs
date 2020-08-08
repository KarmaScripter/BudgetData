// <copyright file="Builder.cs" company="Terry D. Eppler">
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
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuilderBase" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="IBuilder" />
    [ SuppressMessage( "ReSharper", "ImplicitlyCapturedClosure" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Builder : BuilderBase, IBuilder
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder" /> class.
        /// </summary>
        public Builder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        public Builder( Source source, Provider provider = Provider.SQLite )
        {
            Source = source;
            Provider = provider;
            ConnectionBuilder = new ConnectionBuilder( source, provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, SQL.SELECT );
            Query = GetQuery( ConnectionBuilder, SqlStatement );
            ProgramElements = GetSeries( GetDataTable() );
            Record = GetData()?.FirstOrDefault();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="dict">The dictionary.</param>
        public Builder( Source source, Provider provider, IDictionary<string, object> dict )
        {
            Source = source;
            Provider = provider;
            ConnectionBuilder = new ConnectionBuilder( source, provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, SQL.SELECT );
            Query = GetQuery( ConnectionBuilder, SqlStatement );
            ProgramElements = GetSeries( GetDataTable() );
            Record = GetData()?.FirstOrDefault();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="dict">The dictionary.</param>
        public Builder( Source source, IDictionary<string, object> dict )
        {
            Source = source;
            Provider = Provider.SQLite;
            ConnectionBuilder = new ConnectionBuilder( Source, Provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, SQL.SELECT );
            Query = GetQuery( ConnectionBuilder, SqlStatement );
            ProgramElements = GetSeries( GetDataTable() );
            Record = GetData()?.FirstOrDefault();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public Builder( IQuery query )
        {
            Query = query;
            Source = ConnectionBuilder.GetSource();
            Provider = ConnectionBuilder.GetProvider();
            ConnectionBuilder = Query.GetConnectionBuilder();
            SqlStatement = Query.GetSqlStatement();
            ProgramElements = GetSeries( GetDataTable() );
            Record = GetData().FirstOrDefault();
            Args = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the program elements.
        /// </summary>
        /// <value>
        /// The program elements.
        /// </value>
        public IDictionary<string, IEnumerable<string>> ProgramElements { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the unique field values.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetValues( IEnumerable<DataRow> data, string column )
        {
            if( Verify.Input( data )
                && Verify.Input( column ) )
            {
                try
                {
                    var query = data
                        ?.Select( p => p.Field<string>( column ) )
                        ?.Distinct();

                    return query?.Any() == true
                        ? query
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

        /// <summary>
        /// Gets the unique field values.
        /// </summary>
        /// <param name="data">The table.</param>
        /// <param name="field">The column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetValues( IEnumerable<DataRow> data, Field field, string filter )
        {
            if( Verify.Input( data )
                && Verify.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var query = data
                        ?.Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        ?.Select( p => p.Field<string>( $"{field}" ) )
                        ?.Distinct();

                    return query?.Any() == true
                        ? query
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

        /// <summary>
        /// Gets the program elements.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static IDictionary<string, IEnumerable<string>> GetSeries( DataTable data )
        {
            if( Verify.Table( data ) )
            {
                try
                {
                    var dict = new Dictionary<string, IEnumerable<string>>();
                    var columns = data.Columns;

                    for( var i = 0; i < columns?.Count; i++ )
                    {
                        if( Verify.Input( columns[ i ]?.ColumnName ) 
                            && columns[ i ]?.DataType == typeof( string ) )
                        {
                            dict?.Add( columns[ i ]?.ColumnName,
                                GetValues( data?.AsEnumerable(), columns[ i ]?.ColumnName ) );
                        }
                    }

                    return dict?.Any() == true
                        ? dict
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

        /// <summary>
        /// Gets the schema table.
        /// </summary>
        /// <param name="datatable">The datatable.</param>
        /// <returns></returns>
        public static DataTable GetSchemaTable( DataTable datatable )
        {
            if( Verify.Table( datatable ) )
            {
                try
                {
                    using var reader = new DataTableReader( datatable );
                    var table = reader?.GetSchemaTable();

                    return table?.Rows?.Count > 0
                        ? table
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

        /// <summary>
        /// Gets the program elements.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static IDictionary<string, IEnumerable<string>> GetSeries( IEnumerable<DataRow> data,
            Field field, string filter )
        {
            if( Verify.Input( data )
                && Verify.Field( field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var datatable = data.CopyToDataTable();
                    var columns = datatable?.Columns;
                    var dict = new Dictionary<string, IEnumerable<string>>();
                    var values = GetValues( data, field, filter );

                    if( values?.Any() == true )
                    {
                        for( var i = 0; i < columns?.Count; i++ )
                        {
                            var name = columns[ i ].ColumnName;

                            if( Verify.Input( name ) 
                                && columns[ i ]?.DataType == typeof( string ) ) 
                            {
                                dict.Add( columns[ i ].ColumnName, values );
                            }
                        }

                        return dict?.Any() == true
                            ? dict
                            : default;
                    }

                    return default;
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
        /// Gets the data builder.
        /// </summary>
        /// <returns></returns>
        public IBuilder GetBuilder()
        {
            try
            {
                return Query != null
                    ? MemberwiseClone() as Builder
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Filters the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static IEnumerable<DataRow> FilterData( IEnumerable<DataRow> data, Field field, string filter )
        {
            if( Verify.Input( data )
                && Verify.Input( filter )
                && Verify.Field( field ) )
            {
                try
                {
                    var query = data
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