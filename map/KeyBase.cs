// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

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
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary> Gets or sets the field. </summary>
        /// <value> The field. </value>
        private protected PrimaryKey PrimaryKey { get; set; }

        /// <summary> Gets or sets the value. </summary>
        /// <value> The value. </value>
        private protected int Index { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary> Sets the name. </summary>
        /// <param name = "name" > The name. </param>
        /// <returns> </returns>
        public override void SetName( string name )
        {
            try
            {
                Name = Verify.Input( name )
                    ? name
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "datarow" > The data. </param>
        /// <returns> </returns>
        private protected void SetName( DataRow datarow )
        {
            if( datarow != null )
            {
                try
                {
                    var colname = datarow[ 0 ].ToString();
                    var names = datarow?.Table?.GetColumnNames();

                    Name = Verify.Input( colname ) && names?.Contains( colname ) == true
                        ? colname
                        : PrimaryKey.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "field" > The field. </param>
        /// <returns> </returns>
        private protected void SetName( PrimaryKey field )
        {
            if( Validate.Field( field ) )
            {
                try
                {
                    Name = Validate.Field( field )
                        ? field.ToString()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "datarow" > The data. </param>
        /// <param name = "index" > The field. </param>
        /// <returns> </returns>
        private protected void SetName( DataRow datarow, PrimaryKey index )
        {
            if( Verify.Input( datarow?.ItemArray )
                && Validate.Field( index ) )
            {
                try
                {
                    var names = datarow?.Table?.GetColumnNames();

                    Name = names?.Contains( index.ToString() ) == true
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
        /// <param name = "keyname" > The name. </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( string keyname )
        {
            try
            {
                var key = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), keyname );

                PrimaryKey = Enum.IsDefined( typeof( PrimaryKey ), key )
                    ? key
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param name = "datarow" > The data. </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( DataRow datarow )
        {
            if( Verify.Row( datarow ) )
            {
                try
                {
                    var columns = Enum.GetNames( typeof( PrimaryKey ) );

                    if( columns?.Contains( datarow[ 0 ]?.ToString() ) == true )
                    {
                        var field = (PrimaryKey)Enum.Parse( typeof( PrimaryKey ), datarow[ 0 ].ToString() );
                        var names = datarow.Table?.GetColumnNames();

                        PrimaryKey = names?.Contains( field.ToString() ) == true
                            ? field
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

        /// <summary> Sets the field. </summary>
        /// <param name = "keyname" > The field. </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( PrimaryKey keyname )
        {
            try
            {
                PrimaryKey = Validate.Field( keyname )
                    ? keyname
                    : PrimaryKey.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "keyname" > The field. </param>
        /// <returns> </returns>
        private protected void SetPrimaryKey( DataRow data, PrimaryKey keyname )
        {
            if( Verify.Input( data?.ItemArray )
                && Validate.Field( keyname ) )
            {
                try
                {
                    var names = data?.Table?.GetColumnNames();

                    PrimaryKey = names?.Contains( keyname.ToString() ) == true
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
        /// <param name = "value" > The value. </param>
        /// <returns> </returns>
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

        /// <summary> Sets the value. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "key" > The field. </param>
        /// <returns> </returns>
        private protected void SetIndex( DataRow data, PrimaryKey key )
        {
            if( Verify.Input( data?.ItemArray )
                && Validate.PrimaryKey( key ) )
            {
                try
                {
                    var names = data?.Table?.GetColumnNames();

                    Index = names?.Contains( key.ToString() ) == true
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