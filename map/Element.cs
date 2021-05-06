// <copyright file = "Element.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
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

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Element : ElementBase, IElement
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        /// <summary> The default </summary>
        public static readonly IElement Default = new Element( Field.NS );

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        public Element()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "kvp" > The KVP. </param>
        public Element( KeyValuePair<string, object> kvp )
        {
            SetName( kvp.Key );
            SetField( Name );
            SetValue( kvp.Value?.ToString() );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "name" > The name. </param>
        /// <param name = "value" > The value. </param>
        public Element( string name, string value = "" )
        {
            SetField( name );
            SetName( name );
            SetValue( value );
            SetData( name );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "field" > The field. </param>
        public Element( DataRow data, Field field )
        {
            SetField( data, field );
            SetName( data, field );
            SetValue( data, field );
            SetData( data, field );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "field" > The field. </param>
        /// <param name = "value" > The value. </param>
        public Element( Field field, string value = "" )
        {
            SetField( field );
            SetName( Field );
            SetValue( value );
            SetData( value );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "value" > The value. </param>
        public Element( DataRow data, string value )
        {
            SetField( data, value );
            SetName( data, value );
            SetValue( data, value );
            SetData( data, value );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "column" > The column. </param>
        public Element( DataRow data, DataColumn column )
        {
            SetField( column.ColumnName );
            SetName( column.ColumnName );
            SetValue( data, data[ column ].ToString() );
            SetData( data, column );
        }

        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the value. </summary>
        /// <value> The value. </value>
        private protected string Initial { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary> Gets the field. </summary>
        /// <returns> </returns>
        public Field GetField()
        {
            try
            {
                return Enum.IsDefined( typeof( Field ), Field )
                    ? Field
                    : Field.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Field.NS;
            }
        }

        /// <summary> Converts to string. </summary>
        /// <returns>
        /// A
        /// <see cref = "string"/>
        /// that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( Name ) && Verify.Input( Value )
                    ? $"{Name} = {Value}"
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary> Determines whether the specified element is equal. </summary>
        /// <param name = "element" > </param>
        /// <returns>
        /// <c> true </c>
        /// if the specified element is equal; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public bool IsMatch( IElement element )
        {
            if( Verify.Ref( element ) )
            {
                try
                {
                    if( element.GetValue()?.Equals( Value ) == true
                        && element.GetName()?.Equals( Name ) == true )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary> Determines whether the specified primary is equal. </summary>
        /// <param name = "primary" > The primary. </param>
        /// <param name = "secondary" > The secondary. </param>
        /// <returns>
        /// <c> true </c>
        /// if the specified primary is equal; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsMatch( IElement primary, IElement secondary )
        {
            if( Verify.Element( primary )
                && primary != Default
                && Verify.Element( secondary )
                && secondary != Default )
            {
                try
                {
                    if( primary.GetValue().Equals( secondary.GetValue() )
                        && primary.GetName() == secondary.GetName() )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }
    }
}