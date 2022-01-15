// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.IKey" />
    public class Key : IKey
    {
        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <value>
        /// The default.
        /// </value>
        public static IKey Default { get; } = new Key( PrimaryKey.NS, "-1" );

        /// <summary>
        /// Gets or sets the primary key.
        /// </summary>
        /// <value>
        /// The primary key.
        /// </value>
        public PrimaryKey PrimaryKey { get; set; }

        /// <summary>
        /// Gets the index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; set; }

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
            PrimaryKey = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), kvp.Key );
            Index = int.Parse( kvp.Value.ToString() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Key( string name, int value = 0 )
        {
            PrimaryKey = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), name );
            Index = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="field">The field.</param>
        public Key( DataRow dataRow, PrimaryKey field )
        {
            PrimaryKey = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), field.ToString() );
            Index = (int)dataRow[ field.ToString() ];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        public Key( PrimaryKey field, string value = "0" )
        {
            PrimaryKey = field;
            Index = int.Parse( value );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public Key( DataRow dataRow )
        {
            PrimaryKey = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), dataRow[ 0 ].ToString() );
            Index = int.Parse( dataRow[ 0 ].ToString() );
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
                return !Validate.PrimaryKey( PrimaryKey )
                    && Index > -1
                    && Verify.IsInput( Name )
                        ? Name + " = " + Index
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
                    return key?.Index == Index
                        && key?.Name?.Equals( Name ) == true;
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
            if( primary?.Index > -1
                && secondary?.Index > -1 )
            {
                try
                {
                    return primary?.Index == secondary?.Index
                        && primary?.Name?.Equals( secondary?.Name ) == true;
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
        /// Sets the primary key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        private protected void SetPrimaryKey( string keyName )
        {
            if( Verify.IsInput( keyName ) )
            {
                try
                {
                    var _key = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), keyName );

                    PrimaryKey = Enum.IsDefined( typeof( PrimaryKey ), _key )
                        ? PrimaryKey
                        : PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        private protected void SetPrimaryKey( DataRow dataRow )
        {
            if( Verify.IsRow( dataRow ) )
            {
                try
                {
                    var _columns = Enum.GetNames( typeof( PrimaryKey ) );

                    if( _columns?.Contains( dataRow[ 0 ]?.ToString() ) == true )
                    {
                        var _field = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), dataRow[ 0 ].ToString() );

                        var _names = dataRow.Table
                            ?.GetColumnNames();

                        PrimaryKey = _names?.Contains( _field.ToString() ) == true
                            ? _field
                            : PrimaryKey.NS;
                    }
                    else
                    {
                        PrimaryKey = PrimaryKey.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        private protected void SetPrimaryKey( PrimaryKey keyName )
        {
            try
            {
                PrimaryKey = Verify.Field( keyName )
                    ? keyName
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="keyName">Name of the key.</param>
        private protected void SetPrimaryKey( DataRow dataRow, PrimaryKey keyName )
        {
            if( Verify.IsRow( dataRow )
                && Verify.Field( keyName ) )
            {
                try
                {
                    var _names = dataRow.Table
                        ?.GetColumnNames();

                    PrimaryKey = _names?.Contains( keyName.ToString() ) == true
                        ? keyName
                        : PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the index.
        /// </summary>
        /// <param name="value">The value.</param>
        private protected void SetIndex( int value )
        {
            try
            {
                Index = value > -1
                    ? value
                    : (int)PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the index.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="key">The key.</param>
        private protected void SetIndex( DataRow dataRow, PrimaryKey key )
        {
            if( Verify.IsInput( dataRow?.ItemArray )
                && Validate.PrimaryKey( key ) )
            {
                try
                {
                    var _names = dataRow?.Table
                        ?.GetColumnNames();

                    Index = _names?.Contains( key.ToString() ) == true
                        ? int.Parse( dataRow[ $"{key}" ].ToString() )
                        : (int)PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( );
            _error?.ShowDialog();
        }
    }
}