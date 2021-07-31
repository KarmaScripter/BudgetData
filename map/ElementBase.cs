// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
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
        private protected Field _field;

        /// <summary>
        /// Sets the columnName.
        /// </summary>
        /// <param columnName="columnName">The columnName.</param>
        public override void SetName( string columnName )
        {
            try
            {
                _name = Verify.Input( columnName )
                    && Enum.GetNames( typeof( Field ) )?.Contains( columnName ) == true
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
        /// <param columnName="dataRow">The dataRow.</param>
        /// <param columnName="columnName">The columnName.</param>
        private protected void SetName( DataRow dataRow, string columnName )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( columnName )
                && Enum.GetNames( typeof( Field ) )?.Contains( columnName ) == true )
            {
                try
                {
                    var _columnNames = dataRow.Table
                        ?.GetColumnNames();

                    _name = _columnNames?.Contains( columnName ) == true
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
        /// <param columnName="field">The field.</param>
        private protected void SetName( Field field )
        {
            if( Validate.Field( field ) )
            {
                try
                {
                    _name = Validate.Field( field )
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
        /// <param columnName="dataRow">The dataRow.</param>
        /// <param columnName="field">The field.</param>
        private protected void SetName( DataRow dataRow, Field field )
        {
            if( Verify.Row( dataRow )
                && Validate.Field( field ) )
            {
                try
                {
                    var _columnNames = dataRow.Table?.GetColumnNames();

                    _name = _columnNames?.Contains( field.ToString() ) == true
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
        /// <param columnName="fieldName">Name of the field.</param>
        private protected void SetField( string fieldName )
        {
            if( Verify.Input( fieldName )
                && Enum.GetNames( typeof( Field ) )?.Contains( fieldName ) == true )
            {
                try
                {
                    _field = (Field)Enum.Parse( typeof( Field ), fieldName );

                    _field = !Enum.IsDefined( typeof( Field ), _field )
                        ? _field
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
        /// <param columnName="dataRow">The dataRow.</param>
        /// <param columnName="fieldName">The fieldName.</param>
        private protected void SetField( DataRow dataRow, string fieldName )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( fieldName ) )
            {
                try
                {
                    _field = (Field)Enum.Parse( typeof( Field ), fieldName );
                    var _columnNames = dataRow.Table?.GetColumnNames();

                    if( _columnNames?.Any() == true
                        && _columnNames.Contains( $"{_field}" ) )
                    {
                        _field = Enum.GetNames( typeof( Field ) )?.Contains( $"{_field}" ) == true
                            ? _field
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
        /// <param columnName="field">The field.</param>
        private protected void SetField( Field field )
        {
            try
            {
                _field = Validate.Field( field )
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
        /// <param columnName="dataRow">The dataRow.</param>
        /// <param columnName="field">The field.</param>
        private protected void SetField( DataRow dataRow, Field field )
        {
            if( Verify.Row( dataRow )
                && Validate.Field( field ) )
            {
                try
                {
                    var _columnNames = dataRow.Table?.GetColumnNames();

                    _field = _columnNames?.Contains( field.ToString() ) == true
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
        /// <param columnName="value">The value.</param>
        private protected void SetValue( string value )
        {
            try
            {
                if( Verify.Input( value ) )
                {
                    _data = value;
                }
                else if( string.IsNullOrEmpty( value ) )
                {
                    _data = Field.NS.ToString();
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
        /// <param columnName="data">The dataRow.</param>
        /// <param columnName="colname">The columnName.</param>
        private protected void SetValue( DataRow data, string colname )
        {
            if( Verify.Row( data )
                && Verify.Input( colname )
                && Enum.GetNames( typeof( Field ) ).Contains( colname ) )
            {
                try
                {
                    var _columnNames = data.Table?.GetColumnNames();

                    _value = _columnNames?.Contains( colname ) == true
                        ? data[ colname ]?.ToString()
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
        /// <param columnName="data">The dataRow.</param>
        /// <param columnName="field">The field.</param>
        private protected void SetValue( DataRow data, Field field )
        {
            if( Verify.Row( data )
                && Validate.Field( field ) )
            {
                try
                {
                    var _columnNames = data.Table?.GetColumnNames();

                    _value = _columnNames?.Contains( field.ToString() ) == true
                        ? data[ $"{field}" ]?.ToString()
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
        /// <param columnName="data">The dataRow.</param>
        /// <param columnName="field">The field.</param>
        private protected void SetData( DataRow data, Field field )
        {
            if( Verify.Row( data )
                && Validate.Field( field ) )
            {
                try
                {
                    _data = Verify.Ref( data[ $"{field}" ] )
                        ? data[ $"{field}" ]
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
        /// <param columnName="data">The dataRow.</param>
        /// <param columnName="colname">The columnName.</param>
        private protected void SetData( DataRow data, string colname )
        {
            if( Verify.Row( data )
                && Verify.Input( colname ) )
            {
                try
                {
                    _data = Verify.Ref( data[ colname ] )
                        ? data[ colname ]
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
        /// <param columnName="data">The dataRow.</param>
        /// <param columnName="column">The column.</param>
        private protected void SetData( DataRow data, DataColumn column )
        {
            if( Verify.Row( data )
                && Verify.Input( column ) )
            {
                try
                {
                    _data = Verify.Ref( data[ column ] )
                        ? data[ column ]
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