//  <copyright file=" <File Name> .cs" company="Terry D. Eppler">
//  Copyright (c) Terry Eppler. All rights reserved.
//  </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.ElementBase" />
    /// <seealso cref="BudgetExecution.IElement" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Element : ElementBase, IElement
    {
        /// <summary>
        /// The initial
        /// </summary>
        public string Initial { get; set; }

        /// <summary>
        /// The default
        /// </summary>
        public static readonly IElement Default = new Element( Field.NS );

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        public Element()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="kvp">The KVP.</param>
        public Element( KeyValuePair<string, object> kvp )
        {
            SetName( kvp.Key );
            SetField( Name );
            SetValue( kvp.Value?.ToString() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Element( string name, string value = "" )
        {
            SetField( name );
            SetName( name );
            SetValue( value );
            SetData( name );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="field">The field.</param>
        public Element( DataRow dataRow, Field field )
        {
            SetField( dataRow, field );
            SetName( dataRow, field );
            SetValue( dataRow, field );
            SetData( dataRow, field );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        public Element( Field field, string value = "" )
        {
            SetField( field );
            SetName( Field );
            SetValue( value );
            SetData( value );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="value">The value.</param>
        public Element( DataRow dataRow, string value )
        {
            SetField( dataRow, value );
            SetName( dataRow, value );
            SetValue( dataRow, value );
            SetData( dataRow, value );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="dataColumn">The Data column.</param>
        public Element( DataRow dataRow, DataColumn dataColumn )
        {
            SetField( dataColumn.ColumnName );
            SetName( dataColumn.ColumnName );
            SetValue( dataRow, dataRow[ dataColumn ].ToString() );
            SetData( dataRow, dataColumn );
        }

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <returns></returns>
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
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( Name )
                    && Verify.Input( Value )
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
        /// Determines whether the specified element is match.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if the specified element is match; otherwise, <c>false</c>.
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

        /// <summary>
        /// Determines whether the specified primary is match.
        /// </summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>
        ///   <c>true</c> if the specified primary is match; otherwise, <c>false</c>.
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