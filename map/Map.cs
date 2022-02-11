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
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; }

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
            Input = dict;
            Output = Input;
            Names = dict.Keys;
            Values = dict.Values;
            Count = Output.Count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="data">The Data.</param>
        public Map( DataRow data )
        {
            Input = data?.ToDictionary();
            Output = Input;
            Names = GetNames();
            Values = GetValues();
            Count = Output.Count;
        }

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetInput()
        {
            try
            {
                return Input?.Any() == true
                    ? Input
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
                return Output?.Any() == true
                    ? Output
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
                return Input?.HasPrimaryKey() == true;
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
            if( Input?.Any() == true )
            {
                try
                {
                    var _fields = Enum.GetNames( typeof( Field ) );

                    foreach( var kvp in Input )
                    {
                        if( Verify.IsInput( kvp.Key )
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
            if( Input?.HasPrimaryKey() == true )
            {
                try
                {
                    var _data = Input.GetPrimaryKey();

                    return Verify.IsInput( _data.Key )
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
            if( Output?.Any() == true )
            {
                try
                {
                    var _output = new List<IElement>();
                    var _fields = Enum.GetNames( typeof( Field ) );

                    foreach( var kvp in Output )
                    {
                        if( Verify.IsInput( kvp.Key )
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