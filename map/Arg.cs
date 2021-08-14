// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary> </summary>
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" )]
    [SuppressMessage( "ReSharper", "UnassignedGetOnlyAutoProperty" )]
    [SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" )]
    [SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" )]
    public abstract class Arg : UnitBase
    {
        // ***************************************************************************************************************************
        // ************************************************  PROPERTIES **************************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets or sets the elements. </summary>
        /// <value> The elements. </value>
        private protected IEnumerable<string> Values { get; set; }

        /// <summary> Gets or sets the keys. </summary>
        /// <value> The keys. </value>
        private protected IEnumerable<string> Names { get; set; }

        /// <summary> Gets or sets the input. </summary>
        /// <value> The input. </value>
        private protected IDictionary<string, object> Input { get; set; }

        /// <summary> Gets or sets the output. </summary>
        /// <value> The output. </value>
        private protected IDictionary<string, object> Output { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary> Sets the input. </summary>
        /// <param name = "dict" > The dictionary. </param>
        /// <returns> </returns>
        private protected void SetInput( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var args = new Dictionary<string, object>();
                    var fields = Enum.GetNames( typeof( Field ) );

                    foreach( var kvp in dict )
                    {
                        if( Verify.Input( kvp.Key )
                            && fields?.Contains( kvp.Key ) == true )
                        {
                            args?.Add( kvp.Key, kvp.Value );
                        }
                    }

                    Input = args?.Any() == true
                        ? args
                        : default( Dictionary<string, object> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the output. </summary>
        /// <param name = "dict" > The dictionary. </param>
        /// <returns> </returns>
        private protected void SetOutput( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var args = new Dictionary<string, object>();

                    if( Values?.Any() == true )
                    {
                        var data = Values.ToArray();

                        foreach( var kvp in dict )
                        {
                            for( var i = 0; i < data.Length; i++ )
                            {
                                if( kvp.Key.Contains( data[ i ] ) )
                                {
                                    args?.Add( kvp.Key, kvp.Value );
                                }
                            }
                        }

                        Output = args?.Any() == true
                            ? args
                            : default( Dictionary<string, object> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Gets the values. </summary>
        /// <returns> </returns>
        public IEnumerable<string> GetValues()
        {
            if( Output?.Any() == true )
            {
                try
                {
                    var data = Output?.Values?.ToArray();
                    var values = data?.Select( o => o.ToString() );
                    var fields = Enum.GetNames( typeof( Field ) );
                    var list = new List<string>();

                    if( values?.Any() == true
                        && fields?.Any() == true )
                    {
                        foreach( var value in values )
                        {
                            if( Verify.Input( value )
                                && fields.Contains( value ) )
                            {
                                list.Add( value );
                            }
                        }
                    }

                    return values?.Any() == true
                        ? values
                        : default( IEnumerable<string> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }

        /// <summary> Gets the output values. </summary>
        /// <returns> </returns>
        public IEnumerable<string> GetNames()
        {
            if( Output?.Any() == true )
            {
                try
                {
                    var keys = Output?.Keys;
                    var fields = Enum.GetNames( typeof( Field ) );
                    var list = new List<string>();

                    if( keys?.Any() == true )
                    {
                        foreach( var key in keys )
                        {
                            if( Verify.Input( key )
                                && fields.Contains( key ) )
                            {
                                list.Add( key );
                            }
                        }
                    }

                    return list?.Any() == true
                        ? list
                        : default( List<string> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }
    }
}