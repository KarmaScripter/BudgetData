// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary> </summary>
    /// <seealso cref = "UnitBase"/>
    /// <seealso cref = "IUnit"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class KeyBase : Unit
    {
        /// <summary> Gets or sets the field. </summary>
        /// <value> The field. </value>
        private protected PrimaryKey _primaryKey;

        /// <summary> Gets or sets the value. </summary>
        /// <value> The value. </value>
        private protected int _index;

        /// <summary> Sets the columnName. </summary>
        /// <param columnName = "columnName" > The columnName. </param>
        /// <returns> </returns>
        public override void SetName( string columnName )
        {
            try
            {
                _name = Verify.Input( columnName )
                    ? columnName
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the columnName. </summary>
        /// <param columnName = "datarow" > The data. </param>
        /// <returns> </returns>
        private protected void SetName( DataRow datarow )
        {
            if( datarow != null )
            {
                try
                {
                    var _column = datarow[ 0 ].ToString();
                    var _names = datarow?.Table?.GetColumnNames();

                    _name = Verify.Input( _column ) && _names?.Contains( _column ) == true
                        ? _column
                        : PrimaryKey.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the columnName. </summary>
        /// <param columnName = "field" > The field. </param>
        /// <returns> </returns>
        private protected void SetName( PrimaryKey field )
        {
            if( Validate.Field( field ) )
            {
                try
                {
                    _name = Validate.Field( field )
                        ? field.ToString()
                        : default( string );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the columnName. </summary>
        /// <param columnName = "datarow" > The data. </param>
        /// <param columnName = "index" > The field. </param>
        /// <returns> </returns>
        private protected void SetName( DataRow datarow, PrimaryKey index )
        {
            if( Verify.Input( datarow?.ItemArray )
                && Validate.Field( index ) )
            {
                try
                {
                    var _names = datarow?.Table?.GetColumnNames();

                    _name = _names?.Contains( index.ToString() ) == true
                        ? index.ToString()
                        : PrimaryKey.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param columnName = "keyName" > The columnName. </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( string keyName )
        {
            try
            {
                var _primaryKey = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), keyName );

                this._primaryKey = Enum.IsDefined( typeof( PrimaryKey ), _primaryKey )
                    ? _primaryKey
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param columnName = "dataRow" > The data. </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( DataRow dataRow )
        {
            if( Verify.Row( dataRow ) )
            {
                try
                {
                    var _columns = Enum.GetNames( typeof( PrimaryKey ) );

                    if( _columns?.Contains( dataRow[ 0 ]?.ToString() ) == true )
                    {
                        var _field = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), dataRow[ 0 ].ToString() );
                        var _names = dataRow.Table?.GetColumnNames();

                        _primaryKey = _names?.Contains( _field.ToString() ) == true
                            ? _field
                            : PrimaryKey.NS;
                    }
                    else
                    {
                        _primaryKey = PrimaryKey.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param columnName = "keyname" > The field. </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( PrimaryKey keyname )
        {
            try
            {
                _primaryKey = Validate.Field( keyname )
                    ? keyname
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param columnName = "data" > The data. </param>
        /// <param columnName = "keyname" > The field. </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( DataRow data, PrimaryKey keyname )
        {
            if( Verify.Input( data?.ItemArray )
                && Validate.Field( keyname ) )
            {
                try
                {
                    var _names = data?.Table?.GetColumnNames();

                    _primaryKey = _names?.Contains( keyname.ToString() ) == true
                        ? keyname
                        : PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the value. </summary>
        /// <param columnName = "value" > The value. </param>
        /// <returns> </returns>
        private protected void SetIndex( int value )
        {
            try
            {
                _index = value > -1
                    ? value
                    : (int)PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the value. </summary>
        /// <param columnName = "data" > The data. </param>
        /// <param columnName = "key" > The field. </param>
        /// <returns> </returns>
        private protected void SetIndex( DataRow data, PrimaryKey key )
        {
            if( Verify.Input( data?.ItemArray )
                && Validate.PrimaryKey( key ) )
            {
                try
                {
                    var _names = data?.Table?.GetColumnNames();

                    _index = _names?.Contains( key.ToString() ) == true
                        ? int.Parse( data[ $"{key}" ].ToString() )
                        : (int)PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}