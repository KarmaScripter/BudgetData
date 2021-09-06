namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.Arg" />
    /// <seealso cref="BudgetExecution.IMap" />
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    public class Map : Arg, IMap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        public Map()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        public Map( IDictionary<string, object> dict )
        {
            SetInput( dict );
            SetOutput( _input );
            SetData( dict );
            _names = GetNames();
            _values = GetValues();
            Count = _output.Count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public Map( DataRow data )
        {
            SetInput( data?.ToDictionary() );
            SetOutput( _input );
            SetData( data );
            _names = GetNames();
            _values = GetValues();
            Count = _output.Count;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; }

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetInput()
        {
            try
            {
                return _input?.Any() == true
                    ? _input
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetOutput()
        {
            try
            {
                return _output?.Any() == true
                    ? _output
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Determines whether [has primary key].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has primary key]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasPrimaryKey()
        {
            try
            {
                return _input?.HasPrimaryKey() == true;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// Determines whether this instance has elements.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has elements; otherwise, <c>false</c>.
        /// </returns>
        public bool HasElements()
        {
            if( _input?.Any() == true )
            {
                try
                {
                    var _fields = Enum.GetNames( typeof( Field ) );

                    foreach( var kvp in _input )
                    {
                        if( Verify.Input( kvp.Key )
                            && _fields?.Contains( kvp.Key ) == true )
                        {
                            return true;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( bool );
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns></returns>
        public IKey GetKey()
        {
            if( _input?.HasPrimaryKey() == true )
            {
                try
                {
                    var _data = _input.GetPrimaryKey();

                    return Verify.Input( _data.Key )
                        ? new Key( _data )
                        : default( IKey );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IKey );
                }
            }

            return default( IKey );
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IElement> GetElements()
        {
            if( _output?.Any() == true )
            {
                try
                {
                    var _output = new List<IElement>();
                    var _fields = Enum.GetNames( typeof( Field ) );

                    foreach( var kvp in base._output )
                    {
                        if( Verify.Input( kvp.Key )
                            && _fields?.Contains( kvp.Key ) == true )
                        {
                            _output.Add( new Element( kvp ) );
                        }
                    }

                    return _output?.Any() == true
                        ? _output
                        : default( List<IElement> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<IElement> );
                }
            }

            return default( IEnumerable<IElement> );
        }
    }
}