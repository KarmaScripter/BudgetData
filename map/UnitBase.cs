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
        /// The Data
        /// </summary>
        public object Data { get; protected internal set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; protected internal set; }

        /// <summary>
        /// The value
        /// </summary>
        public string Value { get; protected internal set; }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        public virtual void SetName( string columnName )
        {
            try
            {
                Name = Verify.Input( columnName )
                    ? columnName
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the Data.
        /// </summary>
        /// <param name="data">The Data.</param>
        public virtual void SetData( object data )
        {
            try
            {
                Data = Verify.Input( data?.ToString() )
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
        /// <param name="data">The Data.</param>
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
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}