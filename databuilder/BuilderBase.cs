// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public abstract class BuilderBase : DataAccess
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the column ordinals. </summary>
        /// <returns> </returns>
        public IEnumerable<int> GetColumnOrdinals()
        {
            try
            {
                var columns = GetDataTable()?.Columns;
                var values = new List<int>();

                if( columns?.Count > 0 )
                {
                    foreach( DataColumn column in columns )
                    {
                        values?.Add( column.Ordinal );
                    }
                }

                return values?.Any() == true
                    ? values
                    : default( IEnumerable<int> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary> Gets the data elements. </summary>
        /// <returns> </returns>
        public IEnumerable<Field> GetFields()
        {
            try
            {
                var columns = Record?.ToDictionary()?.Keys?.ToArray();

                if( columns?.Any() == true )
                {
                    var elements = columns?.Select( e => e.ToEnum<Field>() );

                    return elements?.Any() == true
                        ? elements
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

        /// <summary> Gets the data elements. </summary>
        /// <returns> </returns>
        public IEnumerable<IElement> GetElements()
        {
            try
            {
                var list = new List<IElement>();
                var columns = Record?.Table?.Columns;
                var fields = Enum.GetNames( typeof( Field ) );

                if( columns?.Count > 0 )
                {
                    foreach( DataColumn column in columns )
                    {
                        if( column?.DataType == typeof( string )
                            && fields?.Contains( column?.ColumnName ) == true )
                        {
                            list?.Add( new Element( Record, column?.ColumnName ) );
                        }
                    }

                    return list?.Any() == true
                        ? list
                        : default( IEnumerable<IElement> );
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
    }
}