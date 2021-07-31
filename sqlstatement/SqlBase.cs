// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class SqlBase
    {
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary> Gets the connection factory. </summary>
        /// <value> The connection factory. </value>
        private protected IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary> Gets the type of the command. </summary>
        /// <value> The type of the command. </value>
        private protected SQL CommandType { get; set; }

        /// <summary> Gets the arguments. </summary>
        /// <value> The arguments. </value>
        private protected IDictionary<string, object> Args { get; set; }

        /// <summary> Gets or sets the command text. </summary>
        /// <value> The command text. </value>
        private protected string CommandText { get; set; }

        // **********************************************************************************************************************
        // *************************************************    METHODS     *****************************************************
        // **********************************************************************************************************************

        /// <summary> Sets the connection builder. </summary>
        /// <param name = "source" > The source. </param>
        /// <param name = "provider" > The provider. </param>
        private protected void SetConnectionBuilder( Source source, Provider provider )
        {
            try
            {
                ConnectionBuilder = Validate.Source( source ) && Validate.Provider( provider )
                    ? new ConnectionBuilder( source, provider )
                    : default( ConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the arguments. </summary>
        /// <param name = "dict" > The dictionary. </param>
        private protected void SetArgs( IDictionary<string, object> dict )
        {
            if( dict?.Any() == true )
            {
                try
                {
                    Args = dict?.Any() == true
                        ? dict
                        : new Dictionary<string, object>();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the type of the command. </summary>
        /// <param name = "commandtype" > The commandtype. </param>
        /// <returns> </returns>
        private protected void SetCommandType( SQL commandtype )
        {
            try
            {
                CommandType = Enum.IsDefined( typeof( SQL ), commandtype )
                    && Enum.GetNames( typeof( SQL ) ).Contains( commandtype.ToString() )
                        ? commandtype
                        : SQL.SELECT;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the select statement. </summary>
        private protected void SetSelectStatement()
        {
            try
            {
                CommandText = Verify.Input( ConnectionBuilder?.GetConnectionString() )
                    ? $"{SQL.SELECT} * FROM {ConnectionBuilder?.GetTableName()};"
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the select statement. </summary>
        /// <param name = "dict" > The dictionary. </param>
        private protected void SetSelectStatement( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var vals = string.Empty;

                    foreach( var kvp in dict )
                    {
                        vals += $"{kvp.Key} = '{kvp.Value}' AND";
                    }

                    var values = vals.TrimEnd( " AND".ToCharArray() );
                    var table = ConnectionBuilder?.GetTableName();
                    CommandText = $"{SQL.SELECT} * FROM {table} WHERE {values};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
            else if( dict == null )
            {
                CommandText = $"{SQL.SELECT} * FROM {ConnectionBuilder?.GetTableName()};";
            }
        }

        /// <summary> Sets the update statement. </summary>
        /// <param name = "dict" > The dictionary. </param>
        private protected void SetUpdateStatement( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var update = string.Empty;

                    foreach( var kvp in dict )
                    {
                        update += $" {kvp.Key} = '{kvp.Value}' AND";
                    }

                    var vals = update.TrimEnd( " AND".ToCharArray() );
                    CommandText = $"{SQL.UPDATE} {ConnectionBuilder?.GetTableName()} SET {vals};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the insert statement. </summary>
        /// <param name = "dict" > The dictionary. </param>
        private protected void SetInsertStatement( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var table = ConnectionBuilder?.GetTableName();
                    var colname = string.Empty;
                    var vals = string.Empty;

                    foreach( var kvp in dict )
                    {
                        colname += $"{kvp.Key}, ";
                        vals += $"{kvp.Value}, ";
                    }

                    var values =
                        $"({colname.TrimEnd( ", ".ToCharArray() )}) VALUES ({vals.TrimEnd( ", ".ToCharArray() )})";

                    CommandText = $"{SQL.INSERT} INTO {table} {values};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the delete statement. </summary>
        /// <param name = "dict" > The dictionary. </param>
        private protected void SetDeleteStatement( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var vals = string.Empty;

                    foreach( var kvp in dict )
                    {
                        vals += $"{kvp.Key} = '{kvp.Value}' AND ";
                    }

                    var values = vals.TrimEnd( " AND".ToCharArray() );
                    var table = ConnectionBuilder?.GetTableName();
                    CommandText = $"{SQL.DELETE} FROM {table} WHERE {values};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
            else if( dict == null )
            {
                CommandText = $"{SQL.DELETE} * FROM {ConnectionBuilder?.GetTableName()};";
            }
        }

        /// <summary> Sets the command text. </summary>
        /// <param name = "sql" > The SQL. </param>
        private protected void SetCommandText( string sql )
        {
            try
            {
                CommandText = Verify.Input( sql )
                    ? sql
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the command text. </summary>
        /// <param name = "command" > </param>
        /// <param name = "dict" > The dictionary. </param>
        public void SetCommandText( IDictionary<string, object> dict, SQL command = SQL.SELECT )
        {
            if( dict == null
                && Verify.Input( ConnectionBuilder?.GetConnectionString() ) )
            {
                SetSelectStatement();
            }
            else if( Verify.Map( dict ) )
            {
                try
                {
                    switch( command )
                    {
                        case SQL.SELECT:
                        {
                            SetSelectStatement( dict );
                            break;
                        }

                        case SQL.UPDATE:
                        {
                            SetUpdateStatement( dict );
                            break;
                        }

                        case SQL.INSERT:
                        {
                            SetInsertStatement( dict );
                            break;
                        }

                        case SQL.DELETE:
                        {
                            SetDeleteStatement( dict );
                            break;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Get Error Dialog. </summary>
        /// <param name = "ex" > The ex. </param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }

        /// <summary> Converts to string. </summary>
        /// <returns>
        /// A
        /// <see cref = "System.String"/>
        /// that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( CommandText )
                    ? CommandText
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