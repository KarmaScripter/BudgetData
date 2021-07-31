// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.UnitBase" />
    /// <seealso cref="BudgetExecution.IUnit" />
    [SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public class Unit : UnitBase, IUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        public Unit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="kvp">The KVP.</param>
        public Unit( KeyValuePair<string, object> kvp )
        {
            SetName( kvp.Key );
            SetData( kvp.Value );
            SetValue( _data );
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public virtual string GetName()
        {
            try
            {
                return Verify.Input( _name )
                    ? _name
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        public virtual string GetValue()
        {
            try
            {
                return Verify.Input( _value )
                    ? _value
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public virtual object GetData()
        {
            try
            {
                return Verify.Ref( _data )
                    ? _data
                    : default( object );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( object );
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
                return Verify.Input( _name ) 
                    && Verify.Input( _value )
                        ? _name + " = " + _value
                        : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }
    }
}