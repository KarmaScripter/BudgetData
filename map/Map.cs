// <copyright file="Map.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Map : Arg, IMap
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Map"/> class.
        /// </summary>
        public Map()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Map"/> class.
        /// </summary>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public Map( IDictionary<string, object> dict )
        {
            Names = dict?.Keys;
            Data = dict?.Values;
            Input = GetInput( dict );
            Output = GetOutput( Input );
            Count = Output.Count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Map"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Map( DataRow data )
        {
            Names = data.ToDictionary()?.Keys;
            Data = data.ToDictionary()?.Values;
            Input = GetInput( data?.ToDictionary() );
            Output = GetOutput( Input );
            Count = Output.Count;
        }

        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetInput()
        {
            try
            {
                return Input?.Any() == true
                    ? Input
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetOutput()
        {
            try
            {
                return Output?.Any() == true
                    ? Output
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Input.HasPrimaryKey();
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
                    var fields = Enum.GetNames( typeof( Field ) );

                    foreach( var kvp in Input )
                    {
                        if( Verify.Input( kvp.Key )
                            && fields?.Contains( kvp.Key ) == true )
                        {
                            return true;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the primary key.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetKey()
        {
            if( Input?.HasPrimaryKey() == true )
            {
                try
                {
                    var data = Input.GetPrimaryKey();

                    return Verify.Input( data.Key )
                        ? new Key( data )
                        : default( IKey );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the output elements.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IElement> GetElements()
        {
            if( Output?.Any() == true )
            {
                try
                {
                    var output = new List<IElement>();
                    var fields = Enum.GetNames( typeof( Field ) );

                    foreach( var kvp in Output )
                    {
                        if( Verify.Input( kvp.Key )
                            && fields?.Contains( kvp.Key ) == true )
                        {
                            output.Add( new Element( kvp ) );
                        }
                    }

                    return output?.Any() == true
                        ? output
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }
    }
}