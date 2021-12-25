// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
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
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
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
            SetValue( Data );
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public virtual string GetName()
        {
            try
            {
                return Verify.Input( Name )
                    ? Name
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
                return Verify.Input( Value )
                    ? Value
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <returns></returns>
        public virtual object GetData()
        {
            try
            {
                return Verify.Ref( Data )
                    ? Data
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
                return Verify.Input( Name )
                    && Verify.Input( Value )
                        ? Name + " = " + Value
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