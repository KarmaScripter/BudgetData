// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" )]
    public abstract class SqlBase
    {
        /// <summary>
        /// The connection builder
        /// </summary>
        private protected IConnectionBuilder _connectionBuilder;

        /// <summary>
        /// The command type
        /// </summary>
        private protected SQL _commandType;

        /// <summary>
        /// The arguments
        /// </summary>
        private protected IDictionary<string, object> _args;

        /// <summary>
        /// The command text
        /// </summary>
        private protected string _commandText;

        /// <summary>
        /// Sets the connection builder.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        private protected void SetConnectionBuilder( Source source, Provider provider )
        {
            try
            {
                _connectionBuilder = Validate.Source( source ) && Validate.Provider( provider )
                    ? new ConnectionBuilder( source, provider )
                    : default( ConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        private protected void SetArgs( IDictionary<string, object> dict )
        {
            if( dict?.Any() == true )
            {
                try
                {
                    _args = dict?.Any() == true
                        ? dict
                        : new Dictionary<string, object>();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the type of the command.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        private protected void SetCommandType( SQL commandType )
        {
            try
            {
                _commandType = Enum.IsDefined( typeof( SQL ), commandType )
                    && Enum.GetNames( typeof( SQL ) ).Contains( commandType.ToString() )
                        ? commandType
                        : SQL.SELECT;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the select statement.
        /// </summary>
        private protected void SetSelectStatement()
        {
            try
            {
                _commandText = Verify.Input( _connectionBuilder?.GetConnectionString() )
                    ? $"{SQL.SELECT} * FROM {_connectionBuilder?.GetTableName()};"
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the select statement.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
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
                    var table = _connectionBuilder?.GetTableName();
                    _commandText = $"{SQL.SELECT} * FROM {table} WHERE {values};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
            else if( dict == null )
            {
                _commandText = $"{SQL.SELECT} * FROM {_connectionBuilder?.GetTableName()};";
            }
        }

        /// <summary>
        /// Sets the update statement.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
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
                    _commandText = $"{SQL.UPDATE} {_connectionBuilder?.GetTableName()} SET {vals};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the insert statement.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        private protected void SetInsertStatement( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var _table = _connectionBuilder?.GetTableName();
                    var _column = string.Empty;
                    var _values = string.Empty;

                    foreach( var kvp in dict )
                    {
                        _column += $"{kvp.Key}, ";
                        _values += $"{kvp.Value}, ";
                    }

                    var values =
                        $"({_column.TrimEnd( ", ".ToCharArray() )}) VALUES ({_values.TrimEnd( ", ".ToCharArray() )})";

                    _commandText = $"{SQL.INSERT} INTO {_table} {values};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the delete statement.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        private protected void SetDeleteStatement( IDictionary<string, object> dict )
        {
            if( Verify.Map( dict ) )
            {
                try
                {
                    var _columns = string.Empty;

                    foreach( var kvp in dict )
                    {
                        _columns += $"{kvp.Key} = '{kvp.Value}' AND ";
                    }

                    var _values = _columns.TrimEnd( " AND".ToCharArray() );
                    var _table = _connectionBuilder?.GetTableName();
                    _commandText = $"{SQL.DELETE} FROM {_table} WHERE {_values};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
            else if( dict == null )
            {
                _commandText = $"{SQL.DELETE} * FROM {_connectionBuilder?.GetTableName()};";
            }
        }

        /// <summary>
        /// Sets the command text.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        private protected void SetCommandText( string sql )
        {
            try
            {
                _commandText = Verify.Input( sql )
                    ? sql
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the command text.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <param name="commandType">Type of the command.</param>
        public void SetCommandText( IDictionary<string, object> dict, SQL commandType = SQL.SELECT )
        {
            if( dict == null
                && Verify.Input( _connectionBuilder?.GetConnectionString() ) )
            {
                SetSelectStatement();
            }
            else if( Verify.Map( dict ) )
            {
                try
                {
                    switch( commandType )
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

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( _commandText )
                    ? _commandText
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