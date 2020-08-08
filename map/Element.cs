// <copyright file="Element.cs" company="Terry D. Eppler">
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
    using System.Threading;

    public class Element : ElementBase, IElement
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The default
        /// </summary>
        public static readonly IElement Default = new Element( Field.NS );

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Element"/> class.
        /// </summary>
        public Element()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Element"/> class.
        /// </summary>
        /// <param name = "kvp" >
        /// The KVP.
        /// </param>
        public Element( KeyValuePair<string, object> kvp )
        {
            Name = GetName( kvp.Key );
            Field = SetField( Name );
            SetValue( kvp.Value?.ToString() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Element"/> class.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <param name = "value" >
        /// The value.
        /// </param>
        public Element( string name, string value = "" )
        {
            Field = SetField( name );
            Name = GetName( name );
            SetValue( value );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Element"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        public Element( DataRow data, Field field )
        {
            Field = SetField( data, field );
            Name = SetName( data, field );
            Data = SetValue( data, field );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Element"/> class.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "value" >
        /// The value.
        /// </param>
        public Element( Field field, string value = "" )
        {
            Field = SetField( field );
            Name = SetName( Field );
            SetValue( value );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Element"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "value" >
        /// The value.
        /// </param>
        public Element( DataRow data, string value )
        {
            Field = SetField( data, value );
            Name = GetName( data, value );
            Data = SetValue( data, value );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Element"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "column" >
        /// The column.
        /// </param>
        public Element( DataRow data, DataColumn column )
        {
            Field = SetField( column.ColumnName );
            Name = GetName( column.ColumnName );
            Data = SetValue( data, data[ column ].ToString() );
        }

        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected string Initial { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <returns>
        /// </returns>
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

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
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

        /// <summary>
        /// Determines whether the specified element is equal.
        /// </summary>
        /// <param name = "unit" >
        /// The element.
        /// </param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if the specified element is equal; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public override bool IsEqual( IUnit unit )
        {
            if( unit != null )
            {
                try
                {
                    if( unit.GetValue().Equals( Value )
                        && unit.GetName().Equals( Name ) )
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

        /// <summary>
        /// Determines whether the specified primary is equal.
        /// </summary>
        /// <param name = "primary" >
        /// The primary.
        /// </param>
        /// <param name = "secondary" >
        /// The secondary.
        /// </param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if the specified primary is equal; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public static bool IsEqual( IElement primary, IElement secondary )
        {
            if( primary != null
                && primary != Default
                && primary != null
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