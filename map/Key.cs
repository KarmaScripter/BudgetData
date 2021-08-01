// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.KeyBase" />
    /// <seealso cref="BudgetExecution.IKey" />
    public class Key : KeyBase, IKey
    {
        /// <summary>
        /// The default
        /// </summary>
        public static readonly IKey Default = new Key( PrimaryKey.NS, "-1" );

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        public Key()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="kvp">The KVP.</param>
        public Key( KeyValuePair<string, object> kvp )
        {
            SetName( kvp.Key );
            SetPrimaryKey( _name );
            SetIndex( int.Parse( kvp.Value.ToString() ) );
            _data = _index.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Key( string name, int value = 0 )
        {
            SetPrimaryKey( name );
            SetName( name );
            SetIndex( value );
            _data = _index.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="field">The field.</param>
        public Key( DataRow dataRow, PrimaryKey field )
        {
            SetPrimaryKey( dataRow, field );
            SetName( dataRow, field );
            SetIndex( dataRow, field );
            _data = _index.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        public Key( PrimaryKey field, string value = "0" )
        {
            SetPrimaryKey( field );
            SetName( field );
            SetIndex( int.Parse( value ) );
            _data = _index.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public Key( DataRow dataRow )
        {
            SetPrimaryKey( dataRow );
            SetName( dataRow, _primaryKey );
            SetIndex( dataRow, _primaryKey );
            _data = _index.ToString();
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns></returns>
        public int GetIndex()
        {
            try
            {
                return _index > -1
                    ? _index
                    : (int)PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return (int)PrimaryKey.NS;
            }
        }

        /// <summary>
        /// Gets the primary key.
        /// </summary>
        /// <returns></returns>
        public PrimaryKey GetPrimaryKey()
        {
            try
            {
                return Enum.IsDefined( typeof( PrimaryKey ), _primaryKey )
                    ? _primaryKey
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return PrimaryKey.NS;
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
                return !Validate.PrimaryKey( _primaryKey ) 
                    && _index > -1 
                    && Verify.Input( _name )
                        ? _name + " = " + _index
                        : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Determines whether the specified key is match.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key is match; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch( IKey key )
        {
            if( key != null )
            {
                try
                {
                    return key?.GetIndex() == _index 
                        && key?.GetName()?.Equals( _name ) == true;
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
        public static bool IsMatch( IKey primary, IKey secondary )
        {
            if( primary?.GetIndex()      > -1
                && secondary?.GetIndex() > -1 )
            {
                try
                {
                    return primary?.GetIndex() == secondary?.GetIndex()
                        && primary?.GetName().Equals( secondary?.GetName() ) == true;
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