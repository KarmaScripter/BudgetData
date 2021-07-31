// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary> </summary>
    /// <seealso cref = "IAmount"/>
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class Amount : AmountBase, IAmount
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary> The default </summary>
        public static readonly IAmount Default = new Amount( Numeric.NS, 0.0 );

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Amount"/>
        /// class.
        /// </summary>
        public Amount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Amount"/>
        /// class.
        /// </summary>
        /// <param name = "numeric" > The numeric. </param>
        /// <param name = "value" > The value. </param>
        public Amount( Numeric numeric = Numeric.Amount, double value = 0.0 )
        {
            _data = value;
            _funding = value;
            _numeric = numeric;
            _name = _numeric.ToString();
            _initial = _funding;
            _delta = _initial - _funding;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Amount"/>
        /// class.
        /// </summary>
        /// <param name = "value" > The value. </param>
        /// <param name = "numeric" > The numeric. </param>
        public Amount( double value = 0, Numeric numeric = Numeric.Amount )
        {
            _data = value;
            _funding = value;
            _numeric = numeric;
            _name = _numeric.ToString();
            _initial = _funding;
            _delta = _initial - _funding;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Amount"/>
        /// class.
        /// </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "numeric" > The numeric. </param>
        public Amount( DataRow data, Numeric numeric = Numeric.Amount )
        {
            _funding = double.Parse( data[ $"{numeric}" ].ToString() );
            _data = _funding.ToString();
            _numeric = numeric;
            _name = _numeric.ToString();
            _initial = _funding;
            _delta = _initial - _funding;
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary> Gets the original. </summary>
        /// <returns> </returns>
        public double GetOriginal()
        {
            try
            {
                return _initial > 0
                    ? _initial
                    : Default.GetFunding();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return 0;
            }
        }

        /// <summary> Gets the change. </summary>
        /// <returns> </returns>
        public double GetDelta()
        {
            try
            {
                return _delta != 0
                    ? _delta
                    : Default.GetFunding();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Default.GetFunding();
            }
        }

        /// <summary> Gets the numeric. </summary>
        /// <returns> </returns>
        public Numeric GetNumeric()
        {
            try
            {
                return Enum.IsDefined( typeof( Numeric ), _numeric )
                    ? _numeric
                    : Numeric.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Numeric );
            }
        }

        /// <summary> Increases the specified amount. </summary>
        /// <param name = "amount" > The amount. </param>
        public void Increase( double amount )
        {
            try
            {
                _delta = amount;
                _funding += _delta;

                if( _initial != _funding )
                {
                    //unfinished
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Decreases the specified amount. </summary>
        /// <param name = "amount" > The amount. </param>
        public void Decrease( double amount )
        {
            try
            {
                _delta = amount;

                if( _funding > amount )
                {
                    _funding -= amount;
                }

                if( _initial != _funding )
                {
                    // Unfinished
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Converts to string. </summary>
        /// <returns>
        /// A
        /// <see cref = "string"/>
        /// that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( _data?.ToString() )
                    ? _data?.ToString()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary> Determines whether the specified element is equal. </summary>
        /// <param name = "amount" > The element. </param>
        /// <returns>
        /// <c> true </c>
        /// if the specified element is equal; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public bool IsEqual( IAmount amount )
        {
            if( amount != null
                && amount.GetFunding() != Default.GetFunding() )
            {
                try
                {
                    if( amount?.GetFunding() == _funding
                        && amount?.GetName()?.Equals( _name ) == true )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary> Determines whether the specified primary is equal. </summary>
        /// <param name = "first" > The primary. </param>
        /// <param name = "second" > The secondary. </param>
        /// <returns>
        /// <c> true </c>
        /// if the specified primary is equal; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsEqual( IAmount first, IAmount second )
        {
            if( first != null
                && first != Default
                && first != null
                && second != Default )
            {
                try
                {
                    if( first?.GetFunding().Equals( second?.GetFunding() ) == true
                        && first?.GetName()?.Equals( second?.GetName() ) == true )
                    {
                        return true;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }

        // **************************************************************************************************************************
        // ********************************************      EVENTS     *************************************************************
        // **************************************************************************************************************************

        /// <summary> Called when [changed]. </summary>
        /// <param name = "sender" > The sender. </param>
        /// <param name = "e" >
        /// The
        /// <see cref = "EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnChanged( object sender, EventArgs e )
        {
            try
            {
                using var msg = new Message( "Not Yet Implemented" );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }
    }
}