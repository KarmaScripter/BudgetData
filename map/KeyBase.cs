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
    [SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" )]
    public abstract class KeyBase : Unit
    {
        /// <summary> Gets or sets the field. </summary>
        /// <value> The field. </value>
        private protected PrimaryKey _primaryKey;

        /// <summary> Gets or sets the value. </summary>
        /// <value> The value. </value>
        private protected int _index;

        /// <summary> Sets the columnName. </summary>
        /// <param name = "columnName" > </param>
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
        /// <param name = "dataRow" > </param>
        /// <returns> </returns>
        private protected void SetName( DataRow dataRow )
        {
            if( dataRow != null )
            {
                try
                {
                    var _column = dataRow[ 0 ].ToString();
                    var _names = dataRow?.Table?.GetColumnNames();

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
        /// <param name = "field" > </param>
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
        /// <param name = "dataRow" > </param>
        /// <param name = "index" > </param>
        /// <returns> </returns>
        private protected void SetName( DataRow dataRow, PrimaryKey index )
        {
            if( Verify.Input( dataRow?.ItemArray )
                && Validate.Field( index ) )
            {
                try
                {
                    var _names = dataRow?.Table?.GetColumnNames();

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
        /// <param name = "keyName" > </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( string keyName )
        {
            try
            {
                var _key = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), keyName );

                _primaryKey = Enum.IsDefined( typeof( PrimaryKey ), _key )
                    ? _primaryKey
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param name = "dataRow" > </param>
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

                        var _names = dataRow.Table
                            ?.GetColumnNames();

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
        /// <param name = "keyName" > </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( PrimaryKey keyName )
        {
            try
            {
                _primaryKey = Validate.Field( keyName )
                    ? keyName
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param name = "dataRow" > </param>
        /// <param name = "keyName" > </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( DataRow dataRow, PrimaryKey keyName )
        {
            if( Verify.Input( dataRow?.ItemArray )
                && Validate.Field( keyName ) )
            {
                try
                {
                    var _names = dataRow?.Table
                        ?.GetColumnNames();

                    _primaryKey = _names?.Contains( keyName.ToString() ) == true
                        ? keyName
                        : PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the value. </summary>
        /// <param name = "value" > </param>
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
        /// <param name = "dataRow" > </param>
        /// <param name = "key" > </param>
        /// <returns> </returns>
        private protected void SetIndex( DataRow dataRow, PrimaryKey key )
        {
            if( Verify.Input( dataRow?.ItemArray )
                && Validate.PrimaryKey( key ) )
            {
                try
                {
                    var _names = dataRow?.Table
                        ?.GetColumnNames();

                    _index = _names?.Contains( key.ToString() ) == true
                        ? int.Parse( dataRow[ $"{key}" ].ToString() )
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