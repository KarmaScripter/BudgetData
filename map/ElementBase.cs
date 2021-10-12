// <copyright file="ElementBase.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.Unit" />
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class ElementBase : Unit
    {
        /// <summary>
        /// The field
        /// </summary>
        public Field Field { get; set; }

        /// <summary>
        /// Sets the columnName.
        /// </summary>
        /// <param name = "columnName" > </param>
        public override void SetName( string columnName )
        {
            try
            {
                Name = Verify.Input( columnName )
                    && ( Enum.GetNames( typeof( Field ) )?.Contains( columnName ) == true )
                        ? columnName
                        : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the columnName.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "columnName" > </param>
        private protected void SetName( DataRow dataRow, string columnName )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( columnName )
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
        private protected void SetName( Field field )
        {
            if( Validate.Field( field ) )
            {
                try
                {
                    Name = Validate.Field( field )
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
        private protected void SetName( DataRow dataRow, Field field )
        {
            if( Verify.Row( dataRow )
                && Validate.Field( field ) )
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
        private protected void SetField( string fieldName )
        {
            if( Verify.Input( fieldName )
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
        private protected void SetField( DataRow dataRow, string fieldName )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( fieldName ) )
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
        private protected void SetField( Field field )
        {
            try
            {
                Field = Validate.Field( field )
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
        private protected void SetField( DataRow dataRow, Field field )
        {
            if( Verify.Row( dataRow )
                && Validate.Field( field ) )
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
        private protected void SetValue( string value )
        {
            try
            {
                if( Verify.Input( value ) )
                {
                    Data = value;
                }
                else if( string.IsNullOrEmpty( value ) )
                {
                    Data = Field.NS.ToString();
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
        private protected void SetValue( DataRow dataRow, string columnName )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( columnName )
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
        private protected void SetValue( DataRow dataRow, Field field )
        {
            if( Verify.Row( dataRow )
                && Validate.Field( field ) )
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

        /// <summary>
        /// Sets the dataRow.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "field" > </param>
        private protected void SetData( DataRow dataRow, Field field )
        {
            if( Verify.Row( dataRow )
                && Validate.Field( field ) )
            {
                try
                {
                    Data = Verify.Ref( dataRow[ $"{field}" ] )
                        ? dataRow[ $"{field}" ]
                        : default( object );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the dataRow.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "columnName" > </param>
        private protected void SetData( DataRow dataRow, string columnName )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( columnName ) )
            {
                try
                {
                    Data = Verify.Ref( dataRow[ columnName ] )
                        ? dataRow[ columnName ]
                        : default( object );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the dataRow.
        /// </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "dataColumn" > </param>
        private protected void SetData( DataRow dataRow, DataColumn dataColumn )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( dataColumn ) )
            {
                try
                {
                    Data = Verify.Ref( dataRow[ dataColumn ] )
                        ? dataRow[ dataColumn ]
                        : default( object );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}