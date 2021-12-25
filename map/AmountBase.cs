// // <copyright file = "AmountBase.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.Unit" />
    public abstract class AmountBase : Unit
    {
        /// <summary>
        /// The funding
        /// </summary>
        public double Funding { get; set; }

        /// <summary>
        /// The initial
        /// </summary>
        public double Initial { get; set; }

        /// <summary>
        /// The delta
        /// </summary>
        public double Delta { get; set; }

        /// <summary>
        /// The numeric
        /// </summary>
        public Numeric Numeric { get; set; } = Numeric.Amount;

        /// <summary>
        /// Gets the ColumnName.
        /// </summary>
        /// <param name="columnName"></param>
        public override void SetName( string columnName )
        {
            if( Verify.Input( columnName )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( columnName ) == true )
            {
                try
                {
                    Name = Verify.Input( columnName )
                        ? columnName
                        : default( string );
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="columnName">Name of the column.</param>
        public void SetName( DataRow dataRow, string columnName )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( columnName )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( columnName ) == true )
            {
                try
                {
                    var _names = dataRow?.Table?.GetColumnNames();

                    Name = _names?.Contains( columnName ) == true
                        ? columnName
                        : default( string );
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="numeric">The numeric.</param>
        public void SetName( Numeric numeric )
        {
            if( Validate.Numeric( numeric ) )
            {
                try
                {
                    Name = Validate.Numeric( numeric )
                        ? numeric.ToString()
                        : default( string );
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="numeric">The numeric.</param>
        private protected void SetName( DataRow dataRow, Numeric numeric )
        {
            if( dataRow != null
                && Validate.Numeric( numeric ) )
            {
                try
                {
                    var _columnNames = dataRow?.Table?.GetColumnNames();

                    Name = _columnNames?.Contains( numeric.ToString() ) == true
                        ? numeric.ToString()
                        : default( string );
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        public void SetNumeric( string columnName )
        {
            if( Verify.Input( columnName )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( columnName ) == true )
            {
                try
                {
                    var _columnValue = (Numeric)Enum.Parse( typeof( Numeric ), columnName );

                    Numeric = Enum.IsDefined( typeof( Numeric ), _columnValue )
                        ? _columnValue
                        : Numeric.NS;
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="columnName">Name of the column.</param>
        public void SetNumeric( DataRow dataRow, string columnName )
        {
            if( Verify.Row( dataRow )
                && Verify.Input( columnName ) )
            {
                try
                {
                    var _columnValue = (Numeric)Enum.Parse( typeof( Numeric ), columnName );

                    var _names = dataRow?.Table?.GetColumnNames();

                    if( _names?.Any() == true )
                    {
                        Numeric = _names?.Contains( $"{_columnValue}" ) == true
                            ? _columnValue
                            : Numeric.NS;
                    }
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name="numeric">The numeric.</param>
        public void SetNumeric( Numeric numeric )
        {
            try
            {
                Numeric = Validate.Numeric( numeric )
                    ? numeric
                    : Numeric.NS;
            }
            catch( Exception ex )
            {
                AmountBase.Fail( ex );
            }
        }

        /// <summary>
        /// Sets the numeric.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="numeric">The numeric.</param>
        public void SetNumeric( DataRow dataRow, Numeric numeric )
        {
            if( dataRow != null
                && Validate.Numeric( numeric ) )
            {
                try
                {
                    var _names = dataRow.Table?.GetColumnNames();

                    if( _names?.Any() == true )
                    {
                        Numeric = _names.Contains( numeric.ToString() )
                            ? numeric
                            : Numeric.NS;
                    }
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetValue( string value )
        {
            try
            {
                if( Verify.Input( value )
                    && Enum.GetNames( typeof( Numeric ) ).Contains( value ) )
                {
                    Value = value;
                }
            }
            catch( Exception ex )
            {
                AmountBase.Fail( ex );
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="columnName">Name of the column.</param>
        public void SetValue( DataRow dataRow, string columnName )
        {
            if( dataRow != null
                && Verify.Input( columnName )
                && Enum.GetNames( typeof( Numeric ) ).Contains( columnName ) )
            {
                try
                {
                    var _names = dataRow.Table?.GetColumnNames();

                    Value = _names.Contains( columnName )
                        ? dataRow[ columnName ].ToString()
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="dataRow">The Data row.</param>
        /// <param name="numeric">The numeric.</param>
        public void SetValue( DataRow dataRow, Numeric numeric )
        {
            if( dataRow != null
                && Validate.Numeric( numeric ) )
            {
                try
                {
                    var _names = dataRow.Table?.GetColumnNames();

                    if( _names?.Any() == true )
                    {
                        Value = _names.Contains( numeric.ToString() )
                            ? dataRow[ $"{numeric}" ].ToString()
                            : string.Empty;
                    }
                }
                catch( Exception ex )
                {
                    AmountBase.Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the funding.
        /// </summary>
        /// <returns></returns>
        public virtual double GetFunding()
        {
            try
            {
                return Funding;
            }
            catch( Exception ex )
            {
                AmountBase.Fail( ex );
                return 0.0;
            }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns></returns>
        public virtual IAmount GetAmount()
        {
            try
            {
                var _amount = GetFunding();

                return _amount != default( double )
                    ? new Amount( _amount )
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                AmountBase.Fail( ex );
                return Amount.Default;
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static new void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error.ShowDialog();
        }
    }
}