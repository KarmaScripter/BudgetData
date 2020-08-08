// <copyright file="KeyBase.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "UnitBase"/>
    /// <seealso cref = "IUnit"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class KeyBase : Unit
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        private protected PrimaryKey PrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected int Index { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "name" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        public override string GetName( string name )
        {
            try
            {
                return Verify.Input( name )
                    ? name
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string GetName( DataRow datarow )
        {
            if( datarow != null )
            {
                try
                {
                    var colname = datarow[ 0 ].ToString();
                    var names = datarow?.Table?.GetColumnNames();

                    return Verify.Input( colname ) 
                        && names?.Contains( colname ) == true
                            ? colname
                            : PrimaryKey.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return PrimaryKey.NS.ToString();
                }
            }

            return PrimaryKey.NS.ToString();
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string GetName( PrimaryKey field )
        {
            if( Verify.Field( field ) )
            {
                try
                {
                    return Verify.Field( field )
                        ? field.ToString()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return PrimaryKey.NS.ToString();
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <param name = "index" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string GetName( DataRow datarow, PrimaryKey index )
        {
            if( Verify.Input( datarow?.ItemArray )
                && Verify.Field( index ) )
            {
                try
                {
                    var names = datarow?.Table?.GetColumnNames();

                    return names?.Contains( index.ToString() ) == true
                        ? index.ToString()
                        : PrimaryKey.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return PrimaryKey.NS.ToString();
                }
            }

            return PrimaryKey.NS.ToString();
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "keyname" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected PrimaryKey GetPrimaryKey( string keyname )
        {
            try
            {
                var key = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), keyname );

                return !Enum.IsDefined( typeof( PrimaryKey ), key )
                    ? key
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return PrimaryKey.NS;
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        /// <returns>
        /// </returns>
        private protected PrimaryKey GetPrimaryKey( DataRow datarow )
        {
            if( Verify.Input( datarow[ 0 ]?.ToString() ) )
            {
                try
                {
                    var columns = Enum.GetNames( typeof( PrimaryKey ) );

                    if( columns?.Contains( datarow[ 0 ]?.ToString() ) == true )
                    {
                        var field = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), datarow[ 0 ].ToString() );
                        var names = datarow.Table?.GetColumnNames();

                        return names?.Contains( field.ToString() ) == true
                            ? field
                            : PrimaryKey.NS;
                    }
                    else
                    {
                        return PrimaryKey.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return PrimaryKey.NS;
                }
            }

            return PrimaryKey.NS;
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "keyname" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected PrimaryKey GetPrimaryKey( PrimaryKey keyname )
        {
            try
            {
                return Verify.Field( keyname )
                    ? keyname
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return PrimaryKey.NS;
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "keyname" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected PrimaryKey GetPrimaryKey( DataRow data, PrimaryKey keyname )
        {
            if( Verify.Input( data?.ItemArray )
                && Verify.Field( keyname ) )
            {
                try
                {
                    var names = data?.Table?.GetColumnNames();

                    return names?.Contains( keyname.ToString() ) == true
                        ? keyname
                        : PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return PrimaryKey.NS;
                }
            }

            return PrimaryKey.NS;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "value" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected int GetIndex( int value )
        {
            try
            {
                return value > -1
                    ? value
                    : (int)PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return (int)PrimaryKey.NS;
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "key" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected int GetIndex( DataRow data, PrimaryKey key )
        {
            if( Verify.Input( data?.ItemArray )
                && Verify.PrimaryKey( key ) )
            {
                try
                {
                    var names = data?.Table?.GetColumnNames();

                    return names?.Contains( key.ToString() ) == true
                        ? int.Parse( data[ $"{key}" ].ToString() )
                        : (int)PrimaryKey.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return (int)PrimaryKey.NS;
                }
            }

            return (int)PrimaryKey.NS;
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static new void Fail( Exception ex )
        {
            using var error = new StaticError( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}