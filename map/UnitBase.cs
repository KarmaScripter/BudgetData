// <copyright file = "UnitBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public abstract class UnitBase
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected object Data { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        private protected string Value { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual void SetName( string name )
        {
            try
            {
                Name = Verify.Input( name )
                    ? name
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual void SetData( object data )
        {
            try
            {
                Data = Verify.Input( data?.ToString() )
                    ? data
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public virtual void SetValue( object data )
        {
            try
            {
                Value = Verify.Input( data?.ToString() )
                    ? data?.ToString()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Determines whether the specified element is equal.
        /// </summary>
        /// <param name = "unit" >
        /// The element.
        /// </param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if the specified element is equal; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public virtual bool IsMatch( IUnit unit )
        {
            if( Verify.Ref( unit ) )
            {
                try
                {
                    return unit.GetName()?.Equals( Name ) == true 
                        && unit.GetValue()?.Equals( Value ) == true;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
