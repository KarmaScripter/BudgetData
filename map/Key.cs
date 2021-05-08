// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************
    /// <summary> </summary>
    /// <seealso cref = "KeyBase"/>
    /// <seealso cref = "IKey"/>
    public class Key : KeyBase, IKey
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary> The default </summary>
        public static readonly IKey Default = new Key( PrimaryKey.NS, "-1" );

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        public Key()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "kvp" > The KVP. </param>
        public Key( KeyValuePair<string, object> kvp )
        {
            SetName( kvp.Key );
            SetPrimaryKey( Name );
            SetIndex( int.Parse( kvp.Value.ToString() ) );
            Data = Index.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "name" > The name. </param>
        /// <param name = "value" > The value. </param>
        public Key( string name, int value = 0 )
        {
            SetPrimaryKey( name );
            SetName( name );
            SetIndex( value );
            Data = Index.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "field" > The field. </param>
        public Key( DataRow data, PrimaryKey field )
        {
            SetPrimaryKey( data, field );
            SetName( data, field );
            SetIndex( data, field );
            Data = Index.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "field" > The field. </param>
        /// <param name = "value" > The value. </param>
        public Key( PrimaryKey field, string value = "0" )
        {
            SetPrimaryKey( field );
            SetName( field );
            SetIndex( int.Parse( value ) );
            Data = Index.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Element"/>
        /// class.
        /// </summary>
        /// <param name = "data" > The data. </param>
        public Key( DataRow data )
        {
            SetPrimaryKey( data );
            SetName( data, PrimaryKey );
            SetIndex( data, PrimaryKey );
            Data = Index.ToString();
        }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the value. </summary>
        /// <returns> </returns>
        public int GetIndex()
        {
            try
            {
                return Index > -1
                    ? Index
                    : (int)PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return (int)PrimaryKey.NS;
            }
        }

        /// <summary> Gets the field. </summary>
        /// <returns> </returns>
        public PrimaryKey GetPrimaryKey()
        {
            try
            {
                return Enum.IsDefined( typeof( PrimaryKey ), PrimaryKey )
                    ? PrimaryKey
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return PrimaryKey.NS;
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
                return !Validate.PrimaryKey( PrimaryKey ) && Index > -1 && Verify.Input( Name )
                    ? Name + " = " + Index
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary> Determines whether the specified element is equal. </summary>
        /// <param name = "key" > The element. </param>
        /// <returns>
        /// <c> true </c>
        /// if the specified element is equal; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public bool IsMatch( IKey key )
        {
            if( key != null )
            {
                try
                {
                    return key?.GetIndex() == Index && key?.GetName()?.Equals( Name ) == true;
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
        public static bool IsMatch( IKey primary, IKey secondary )
        {
            if( primary != null
                && primary.GetIndex() > -1
                && secondary != null
                && secondary.GetIndex() > -1 )
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