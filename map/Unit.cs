// <copyright file = "Unit.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.UnitBase" />
    /// <seealso cref="BudgetExecution.IUnit" />
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public class Unit : UnitBase, IUnit
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

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

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
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
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public virtual object GetData()
        {
            try
            {
                return Verify.Ref( Data )
                    ? Data
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( Name ) && Verify.Input( Value )
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
