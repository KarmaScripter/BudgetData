// <copyright file = "ElementBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
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

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class ElementBase : Unit
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary> Gets the field. </summary>
        /// <value> The field. </value>
        private protected Field Field { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary> Sets the name. </summary>
        /// <param name = "colname" > The name. </param>
        /// <returns> </returns>
        public override void SetName( string colname )
        {
            try
            {
                Name = Verify.Input( colname )
                    && Enum.GetNames( typeof( Field ) )?.Contains( colname ) == true
                        ? colname
                        : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "colname" > The name. </param>
        /// <returns> </returns>
        private protected void SetName( DataRow data, string colname )
        {
            if( Verify.Row( data )
                && Verify.Input( colname )
                && Enum.GetNames( typeof( Field ) )
                       ?.Contains( colname ) == true )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    Name = names?.Contains( colname ) == true
                        ? colname
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "field" > The field. </param>
        /// <returns> </returns>
        private protected void SetName( Field field )
        {
            if( Verify.Field( field ) )
            {
                try
                {
                    Name = Verify.Field( field )
                        ? field.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the name. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "field" > The field. </param>
        /// <returns> </returns>
        private protected void SetName( DataRow data, Field field )
        {
            if( Verify.Row( data )
                && Verify.Field( field ) )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    Name = names?.Contains( field.ToString() ) == true
                        ? field.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param name = "fieldname" > The name. </param>
        /// <returns> </returns>
        private protected void SetField( string fieldname )
        {
            if( Verify.Input( fieldname )
                && Enum.GetNames( typeof( Field ) )?.Contains( fieldname ) == true )
            {
                try
                {
                    var field = (Field)Enum.Parse( typeof( Field ), fieldname );

                    Field = !Enum.IsDefined( typeof( Field ), field )
                        ? field
                        : Field.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "fieldname" > The name. </param>
        /// <returns> </returns>
        private protected void SetField( DataRow data, string fieldname )
        {
            if( Verify.Row( data )
                && Verify.Input( fieldname ) )
            {
                try
                {
                    var field = (Field)Enum.Parse( typeof( Field ), fieldname );
                    var names = data.Table?.GetColumnNames();

                    if( names?.Any() == true
                        && names.Contains( $"{field}" ) )
                    {
                        Field = Enum.GetNames( typeof( Field ) )?.Contains( $"{field}" ) == true
                            ? field
                            : Field.NS;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param name = "field" > The field. </param>
        /// <returns> </returns>
        private protected void SetField( Field field )
        {
            try
            {
                Field = Verify.Field( field )
                    ? field
                    : Field.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the field. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "field" > The field. </param>
        /// <returns> </returns>
        private protected void SetField( DataRow data, Field field )
        {
            if( Verify.Row( data )
                && Verify.Field( field ) )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    Field = names?.Contains( field.ToString() ) == true
                        ? field
                        : Field.NS;
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

        /// <summary> Sets the value. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "colname" > The value. </param>
        /// <returns> </returns>
        private protected void SetValue( DataRow data, string colname )
        {
            if( Verify.Row( data )
                && Verify.Input( colname )
                && Enum.GetNames( typeof( Field ) ).Contains( colname ) )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    Value = names?.Contains( colname ) == true
                        ? data[ colname ]?.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the value. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "field" > The field. </param>
        /// <returns> </returns>
        private protected void SetValue( DataRow data, Field field )
        {
            if( Verify.Row( data )
                && Verify.Field( field ) )
            {
                try
                {
                    var names = data.Table?.GetColumnNames();

                    Value = names?.Contains( field.ToString() ) == true
                        ? data[ $"{field}" ]?.ToString()
                        : Field.NS.ToString();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the data. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "field" > The field. </param>
        private protected void SetData( DataRow data, Field field )
        {
            if( Verify.Row( data )
                && Verify.Field( field ) )
            {
                try
                {
                    Data = Verify.Ref( data[ $"{field}" ] )
                        ? data[ $"{field}" ]
                        : default( object );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the data. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "colname" > The colname. </param>
        private protected void SetData( DataRow data, string colname )
        {
            if( Verify.Row( data )
                && Verify.Input( colname ) )
            {
                try
                {
                    Data = Verify.Ref( data[ colname ] )
                        ? data[ colname ]
                        : default( object );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the data. </summary>
        /// <param name = "data" > The data. </param>
        /// <param name = "column" > The column. </param>
        private protected void SetData( DataRow data, DataColumn column )
        {
            if( Verify.Row( data )
                && Verify.Input( column ) )
            {
                try
                {
                    Data = Verify.Ref( data[ column ] )
                        ? data[ column ]
                        : default( object );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}