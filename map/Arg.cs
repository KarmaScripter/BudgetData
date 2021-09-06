// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.UnitBase" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnassignedGetOnlyAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class Arg : UnitBase
    {
        /// <summary>
        /// The values
        /// </summary>
        private protected IEnumerable<string> _values;

        /// <summary>
        /// The names
        /// </summary>
        private protected IEnumerable<string> _names;

        /// <summary>
        /// The input
        /// </summary>
        private protected IDictionary<string, object> _input;

        /// <summary>
        /// The output
        /// </summary>
        private protected IDictionary<string, object> _output;

        /// <summary>
        /// Sets the input.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        private protected void SetInput( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>();
                    var _fields = Enum.GetNames( typeof( Field ) );

                    foreach( var kvp in dict )
                    {
                        if( Verify.Input( kvp.Key )
                            && _fields?.Contains( kvp.Key ) == true )
                        {
                            _dictionary?.Add( kvp.Key, kvp.Value );
                        }
                    }

                    _input = _dictionary?.Any() == true
                        ? _dictionary
                        : default( Dictionary<string, object> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the output.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        private protected void SetOutput( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>();

                    if( _values?.Any() == true )
                    {
                        var data = _values.ToArray();

                        foreach( var kvp in dict )
                        {
                            for( var i = 0; i < data.Length; i++ )
                            {
                                if( kvp.Key.Contains( data[ i ] ) )
                                {
                                    _dictionary?.Add( kvp.Key, kvp.Value );
                                }
                            }
                        }

                        _output = _dictionary?.Any() == true
                            ? _dictionary
                            : default( Dictionary<string, object> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetValues()
        {
            if( _output?.Any() == true )
            {
                try
                {
                    var _array = _output?.Values?.ToArray();
                    var _enumerable = _array?.Select( o => o.ToString() );
                    var _fields = Enum.GetNames( typeof( Field ) );
                    var _list = new List<string>();

                    if( _enumerable?.Any() == true
                        && _fields?.Any() == true )
                    {
                        foreach( var value in _enumerable )
                        {
                            if( Verify.Input( value )
                                && _fields.Contains( value ) )
                            {
                                _list.Add( value );
                            }
                        }
                    }

                    return _enumerable?.Any() == true
                        ? _enumerable
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

        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetNames()
        {
            if( _output?.Any() == true )
            {
                try
                {
                    var _keys = _output?.Keys;
                    var _fields = Enum.GetNames( typeof( Field ) );
                    var _list = new List<string>();

                    if( _keys?.Any() == true )
                    {
                        foreach( var key in _keys )
                        {
                            if( Verify.Input( key )
                                && _fields.Contains( key ) )
                            {
                                _list.Add( key );
                            }
                        }
                    }

                    return _list?.Any() == true
                        ? _list
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