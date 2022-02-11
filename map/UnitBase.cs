//  <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
//  </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using VisualPlus.Extensibility;

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
        public object Data { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Determines whether the specified unit is match.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>
        ///   <c>true</c> if the specified unit is match; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsMatch( IDataUnit unit )
        {
            if( Verify.IsRef( unit ) )
            {
                try
                {
                    return unit.GetName()?.Equals( Name )   == true
                        && unit.Value.Equals( Value ) == true;
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