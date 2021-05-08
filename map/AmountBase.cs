// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Linq;

    public abstract class AmountBase : Unit
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary> Gets the value. </summary>
        /// <value> The value. </value>
        private protected double Funding { get; set; }

        /// <summary> Gets the original. </summary>
        /// <value> The original. </value>
        private protected double Initial { get; set; }

        /// <summary> Gets the delta. </summary>
        /// <value> The delta. </value>
        private protected double Delta { get; set; }

        /// <summary> Gets or sets the numeric. </summary>
        /// <value> The numeric. </value>
        private protected Numeric Numeric { get; set; } = Numeric.Amount;

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary> Sets the name. </summary>
        /// <param name = "colname" > The name. </param>
        /// <returns> </returns>
        public override void SetName( string colname )
        {
            if( Verify.Input( colname )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( colname ) == true )
            {
                try
                {
                    Name = Verify.Input( colname )
                        ? colname
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "datarow" > The data. </param>
        /// <param name = "colname" > The name. </param>
        /// <returns> </returns>
        private protected void SetName( DataRow datarow, string colname )
        {
            if( Verify.Row( datarow )
                && Verify.Input( colname )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( colname ) == true )
            {
                try
                {
                    var names = datarow?.Table?.GetColumnNames();

                    Name = names?.Contains( colname ) == true
                        ? colname
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "numeric" > The numeric. </param>
        /// <returns> </returns>
        private protected void SetName( Numeric numeric )
        {
            if( Validate.Numeric( numeric ) )
            {
                try
                {
                    Name = Validate.Numeric( numeric )
                        ? numeric.ToString()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "datarow" > The data. </param>
        /// <param name = "numeric" > The numeric. </param>
        /// <returns> </returns>
        private protected void SetName( DataRow datarow, Numeric numeric )
        {
            if( datarow != null
                && Validate.Numeric( numeric ) )
            {
                try
                {
                    var names = datarow?.Table?.GetColumnNames();

                    Name = names?.Contains( numeric.ToString() ) == true
                        ? numeric.ToString()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the numeric. </summary>
        /// <param name = "name" > The name. </param>
        /// <returns> </returns>
        private protected void SetNumeric( string name )
        {
            if( Verify.Input( name )
                && Enum.GetNames( typeof( Numeric ) )?.Contains( name ) == true )
            {
                try
                {
                    var numeric = (Numeric)Enum.Parse( typeof( Numeric ), name );

                    Numeric = Enum.IsDefined( typeof( Numeric ), numeric )
                        ? numeric
                        : Numeric.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the numeric. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "name" > The name. </param>
        /// <returns> </returns>
        private protected void SetNumeric( DataRow data, string name )
        {
            if( Verify.Row( data )
                && Verify.Input( name ) )
            {
                try
                {
                    var numeric = (Numeric)Enum.Parse( typeof( Numeric ), name );
                    var names = data?.Table?.GetColumnNames();

                    if( names?.Any() == true )
                    {
                        Numeric = names?.Contains( $"{numeric}" ) == true
                            ? numeric
                            : Numeric.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the numeric. </summary>
        /// <param name = "numeric" > The numeric. </param>
        /// <returns> </returns>
        private protected void SetNumeric( Numeric numeric )
        {
            try
            {
                Numeric = Validate.Numeric( numeric )
                    ? numeric
                    : Numeric.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the numeric. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "numeric" > The numeric. </param>
        /// <returns> </returns>
        private protected void SetNumeric( DataRow data, Numeric numeric )
        {
            if( data != null
                && Validate.Numeric( numeric ) )
            {
                try
                {
                    var columns = data.Table.GetColumnNames();

                    Numeric = columns.Contains( numeric.ToString() )
                        ? numeric
                        : Numeric.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the value. </summary>
        /// <param name = "value" > The value. </param>
        /// <returns> </returns>
        private protected void SetValue( string value )
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
                Fail( ex );
            }
        }

        /// <summary> Sets the value. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "value" > The value. </param>
        /// <returns> </returns>
        private protected void SetValue( DataRow data, string value )
        {
            if( data != null
                && Verify.Input( value )
                && Enum.GetNames( typeof( Numeric ) ).Contains( value ) )
            {
                try
                {
                    var columns = data.Table.GetColumnNames();

                    Value = columns.Contains( value )
                        ? data[ value ].ToString()
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the value. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "numeric" > The numeric. </param>
        /// <returns> </returns>
        private protected void SetValue( DataRow data, Numeric numeric )
        {
            if( data != null
                && Validate.Numeric( numeric ) )
            {
                try
                {
                    var columns = data.Table.GetColumnNames();

                    Value = columns.Contains( numeric.ToString() )
                        ? data[ $"{numeric}" ].ToString()
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Gets the value. </summary>
        /// <returns> </returns>
        public double GetFunding()
        {
            try
            {
                return Funding;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return 0.0;
            }
        }

        /// <summary> Gets the amount. </summary>
        /// <returns> </returns>
        public IAmount GetAmount()
        {
            try
            {
                var amount = GetFunding();

                return amount != default
                    ? new Amount( amount )
                    : Amount.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Amount.Default;
            }
        }

        /// <summary> Get Error Dialog. </summary>
        /// <param name = "ex" > The ex. </param>
        private protected static new void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error.SetText();
            error.ShowDialog();
        }
    }
}