//  <copyright file=" <File Name> .cs" company="Terry D. Eppler">
//  Copyright (c) Terry Eppler. All rights reserved.
//  </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.IElement" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Element : DataUnit
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey ID { get; set; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <returns>
        /// </returns>
        public string Code { get; set; }

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
            Field = (Field)Enum.Parse( typeof( Field ), kvp.Key );
            Name = kvp.Key;
            Value = kvp.Value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Element( string name, string value = "" )
        {
            Field = (Field)Enum.Parse( typeof( Field ), name );
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="field">The field.</param>
        public Element( DataRow dataRow, Field field )
        {
            Field = field;
            Name = field.ToString();
            Value = dataRow[ field.ToString() ];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        public Element( Field field, string value = "" )
        {
            Field = field;
            Name = field.ToString();
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="value">The value.</param>
        public Element( DataRow dataRow, string value )
        {
            Name = dataRow[ value ].ToString();
            Value = dataRow[ value ];
            Field = (Field)Enum.Parse( typeof( Field ), Name );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="dataColumn">The Data column.</param>
        public Element( DataRow dataRow, DataColumn dataColumn )
        {
            Field = (Field)Enum.Parse( typeof( Field ), dataColumn.ColumnName );
            Name = dataColumn.ColumnName;
            Value = dataRow[ dataColumn ];
        }

        /// <summary>
        /// Determines whether the specified element is match.
        /// </summary>
        /// <param name="dataUnit">The element.</param>
        /// <returns>
        ///   <c>true</c> if the specified element is match; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsMatch( IDataUnit dataUnit )
        {
            if( Verify.IsRef( dataUnit ) )
            {
                try
                {
                    if( dataUnit.Value?.Equals( Value ) == true )
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
            if( Verify.IsElement( primary )
                && Verify.IsElement( secondary ) )
            {
                try
                {
                    if( primary.Value.Equals( secondary.Value )
                        && primary.Name.Equals( secondary.Name ) )
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
        /// Sets the columnName.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "columnName" > </param>
        private protected virtual void SetName( DataRow dataRow, string columnName )
        {
            if( Verify.IsRow( dataRow )
                && Verify.IsInput( columnName )
                && Enum.GetNames( typeof( Field ) )?.Contains( columnName ) == true )
            {
                try
                {
                    var _names = dataRow.Table
                        ?.GetColumnNames();

                    Name = _names?.Contains( columnName ) == true
                        ? columnName
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the columnName.
        /// </summary>
        /// <param name = "field" > </param>
        private protected virtual void SetName( Field field )
        {
            if( Validate.IsField( field ) )
            {
                try
                {
                    Name = Validate.IsField( field )
                        ? field.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the columnName.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "field" > </param>
        private protected virtual void SetName( DataRow dataRow, Field field )
        {
            if( Verify.IsRow( dataRow )
                && Validate.IsField( field ) )
            {
                try
                {
                    var _columnNames = dataRow.Table
                        ?.GetColumnNames();

                    Name = _columnNames?.Contains( field.ToString() ) == true
                        ? field.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "fieldName" > </param>
        private protected virtual void SetField( string fieldName )
        {
            if( Verify.IsInput( fieldName )
                && Enum.GetNames( typeof( Field ) )?.Contains( fieldName ) == true )
            {
                try
                {
                    var _input = (Field)Enum.Parse( typeof( Field ), fieldName );

                    Field = !Enum.IsDefined( typeof( Field ), _input )
                        ? Field
                        : Field.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "fieldName" > </param>
        private protected virtual void SetField( DataRow dataRow, string fieldName )
        {
            if( Verify.IsRow( dataRow )
                && Verify.IsInput( fieldName ) )
            {
                try
                {
                    var _input = (Field)Enum.Parse( typeof( Field ), fieldName );
                    var _names = dataRow.Table?.GetColumnNames();

                    if( _names?.Any() == true
                        && _names?.Contains( $"{_input}" ) == true )
                    {
                        Field = Enum.GetNames( typeof( Field ) )?.Contains( $"{_input}" ) == true
                            ? _input
                            : Field.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "field" > </param>
        private protected virtual void SetField( Field field )
        {
            try
            {
                Field = Validate.IsField( field )
                    ? field
                    : Field.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "field" > </param>
        private protected virtual void SetField( DataRow dataRow, Field field )
        {
            if( Verify.IsRow( dataRow )
                && Validate.IsField( field ) )
            {
                try
                {
                    var _names = dataRow.Table
                        ?.GetColumnNames();

                    Field = _names?.Contains( field.ToString() ) == true
                        ? field
                        : Field.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "value" > </param>
        private protected virtual void SetValue( object value )
        {
            try
            {
                if( Verify.IsInput( value ) )
                {
                    Value = value;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "columnName" > </param>
        private protected virtual void SetValue( DataRow dataRow, string columnName )
        {
            if( Verify.IsRow( dataRow )
                && Verify.IsInput( columnName )
                && Enum.GetNames( typeof( Field ) ).Contains( columnName ) )
            {
                try
                {
                    var _names = dataRow.Table
                        ?.GetColumnNames();

                    Value = _names?.Contains( columnName ) == true
                        ? dataRow[ columnName ]?.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "field" > </param>
        private protected virtual void SetValue( DataRow dataRow, Field field )
        {
            if( Verify.IsRow( dataRow )
                && Validate.IsField( field ) )
            {
                try
                {
                    var _names = dataRow.Table
                        ?.GetColumnNames();

                    Value = _names?.Contains( field.ToString() ) == true
                        ? dataRow[ $"{field}" ]?.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}