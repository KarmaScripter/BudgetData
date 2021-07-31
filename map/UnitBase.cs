//  <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
//  </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public abstract class UnitBase
    {
        /// <summary>
        /// The data
        /// </summary>
        private protected object _data;

        /// <summary>
        /// The name
        /// </summary>
        private protected string _name;

        /// <summary>
        /// The value
        /// </summary>
        private protected string _value;

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        public virtual void SetName( string columnName )
        {
            try
            {
                _name = Verify.Input( columnName )
                    ? columnName
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="data">The data.</param>
        public virtual void SetData( object data )
        {
            try
            {
                _data = Verify.Input( data?.ToString() )
                    ? data
                    : default( object );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="data">The data.</param>
        public virtual void SetValue( object data )
        {
            try
            {
                _value = Verify.Input( data?.ToString() )
                    ? data?.ToString()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Determines whether the specified unit is match.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>
        ///   <c>true</c> if the specified unit is match; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsMatch( IUnit unit )
        {
            if( Verify.Ref( unit ) )
            {
                try
                {
                    return unit.GetName()?.Equals( _name )   == true
                        && unit.GetValue()?.Equals( _value ) == true;
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
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}