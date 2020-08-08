// <copyright file="ElementBase.cs" company="Terry D. Eppler">
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
    using System.Linq;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class ElementBase : Unit
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        private protected Field Field { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "colname" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        public override string GetName( string colname )
        {
            if( Verify.Input( colname )
                && Enum.GetNames( typeof( Field ) )?.Contains( colname ) == true )
            {
                try
                {
                    return Verify.Input( colname )
                        ? colname
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return Field.NS.ToString();
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "colname" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string GetName( DataRow data, string colname )
        {
            if( data != null
                && Verify.Input( colname )
                && Enum.GetNames( typeof( Field ) )?.Contains( colname ) == true )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    return names?.Contains( colname ) == true
                        ? colname
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Field.NS.ToString();
                }
            }

            return Field.NS.ToString();
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( Field field )
        {
            if( Verify.Field( field ) )
            {
                try
                {
                    return Verify.Field( field )
                        ? field.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Field.NS.ToString();
                }
            }

            return Field.NS.ToString();
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetName( DataRow data, Field field )
        {
            if( data != null
                && Verify.Field( field ) )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    return names?.Contains( field.ToString() ) == true
                        ? field.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Field.NS.ToString();
                }
            }

            return Field.NS.ToString();
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "fieldname" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Field SetField( string fieldname )
        {
            if( Verify.Input( fieldname )
                && Enum.GetNames( typeof( Field ) )?.Contains( fieldname ) == true )
            {
                try
                {
                    var field = (Field)Enum.Parse( typeof( Field ), fieldname );

                    return !Enum.IsDefined( typeof( Field ), field )
                        ? field
                        : Field.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Field.NS;
                }
            }

            return Field.NS;
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "fieldname" >
        /// The name.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Field SetField( DataRow data, string fieldname )
        {
            if( data != null
                && Verify.Input( fieldname ) )
            {
                try
                {
                    var field = (Field)Enum.Parse( typeof( Field ), fieldname );
                    var names = data.Table?.GetColumnNames();

                    if( names?.Any() == true
                        && names.Contains( $"{field}" ) )
                    {
                        return Enum.GetNames( typeof( Field ) )?.Contains( $"{field}" ) == true
                            ? field
                            : Field.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Field.NS;
                }
            }

            return Field.NS;
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Field SetField( Field field )
        {
            try
            {
                return Verify.Field( field )
                    ? field
                    : Field.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Field.NS;
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected Field SetField( DataRow data, Field field )
        {
            if( data != null
                && Verify.Field( field ) )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    return names?.Contains( field.ToString() ) == true
                        ? field
                        : Field.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Field.NS;
                }
            }

            return Field.NS;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "value" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected void SetValue( string value )
        {
            try
            {
                if( Verify.Input( value ) )
                {
                    Data = value;
                }
                else if( string.IsNullOrEmpty( value ) )
                {
                    Data = Field.NS.ToString();
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "colname" >
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetValue( DataRow data, string colname )
        {
            if( data != null
                && Verify.Input( colname )
                && Enum.GetNames( typeof( Field ) ).Contains( colname ) )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    return names?.Contains( colname ) == true
                        ? data[ colname ]?.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Field.NS.ToString();
                }
            }

            return Field.NS.ToString();
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <returns>
        /// </returns>
        private protected string SetValue( DataRow data, Field field )
        {
            if( data != null
                && Verify.Field( field ) )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    return names?.Contains( field.ToString() ) == true
                        ? data[ $"{field}" ]?.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Field.NS.ToString();
                }
            }

            return Field.NS.ToString();
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static new void Fail( Exception ex )
        {
            using var error = new StaticError( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}