// <copyright file="BuilderBase.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.DataAccess" />
    public abstract class BuilderBase : DataAccess
    {
        /// <summary>
        /// Gets the column ordinals.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetColumnOrdinals()
        {
            try
            {
                var _columns = GetDataTable()?.Columns;
                var _values = new List<int>();

                if( _columns?.Count > 0 )
                {
                    foreach( DataColumn column in _columns )
                    {
                        _values?.Add( column.Ordinal );
                    }
                }

                return _values?.Any() == true
                    ? _values
                    : default( IEnumerable<int> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<int> );
            }
        }

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Field> GetFields()
        {
            try
            {
                var _columns = Record
                    ?.ToDictionary()
                    ?.Keys
                    ?.ToArray();

                if( _columns?.Any() == true )
                {
                    var _fields = _columns
                        ?.Select( e => e.ToEnum<Field>() );

                    return _fields?.Any() == true
                        ? _fields
                        : default( IEnumerable<Field> );
                }
                else
                {
                    return default( IEnumerable<Field> );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<Field> );
            }
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IElement> GetElements()
        {
            try
            {
                var _elements = new List<IElement>();
                var _columns = Record?.Table?.Columns;
                var _fields = Enum.GetNames( typeof( Field ) );

                if( _columns?.Count > 0 )
                {
                    foreach( DataColumn column in _columns )
                    {
                        if( column?.DataType == typeof( string )
                            && _fields?.Contains( column?.ColumnName ) == true )
                        {
                            _elements?.Add( new Element( Record, column?.ColumnName ) );
                        }
                    }

                    return _elements?.Any() == true
                        ? _elements
                        : default( IEnumerable<IElement> );
                }
                else
                {
                    return default( IEnumerable<IElement> );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IElement> );
            }
        }
    }
}