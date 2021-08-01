// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.SqlConfig" />
    /// <seealso cref="BudgetExecution.ISqlStatement" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class SqlStatement : SqlConfig, ISqlStatement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlStatement"/> class.
        /// </summary>
        public SqlStatement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlStatement"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connectionBuilder.</param>
        /// <param name="commandType">The commandType.</param>
        public SqlStatement( IConnectionBuilder connectionBuilder, SQL commandType = SQL.SELECT )
        {
            _connectionBuilder = connectionBuilder;
            SetCommandType( commandType );
            _args = null;
            SetCommandText( _args );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlStatement"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connectionBuilder.</param>
        /// <param name="dict">The dictionary.</param>
        public SqlStatement( IConnectionBuilder connectionBuilder, IDictionary<string, object> dict )
        {
            _connectionBuilder = connectionBuilder;
            _commandType = SQL.SELECT;
            _args = dict;
            _commandText = GetCommandText();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlStatement"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connectionBuilder.</param>
        /// <param name="dict">The dictionary.</param>
        /// <param name="commandType">Type of the commandType.</param>
        public SqlStatement( IConnectionBuilder connectionBuilder, IDictionary<string, object> dict,
            SQL commandType = SQL.SELECT )
        {
            _connectionBuilder = connectionBuilder;
            SetCommandType( commandType );
            SetArgs( dict );
            _commandText = GetCommandText();
        }

        /// <summary>
        /// Gets the select statement.
        /// </summary>
        /// <returns></returns>
        public string GetSelectStatement()
        {
            if( _args != null )
            {
                try
                {
                    var _values = string.Empty;

                    foreach( var kvp in _args )
                    {
                        _values += $"{kvp.Key} = '{kvp.Value}' AND ";
                    }

                    _values = _values.TrimEnd( " AND".ToCharArray() );
                    var _table = _connectionBuilder?.GetTableName();
                    _commandText = $"{SQL.SELECT} * FROM {_table} WHERE {_values};";

                    return Verify.Input( _commandText )
                        ? _commandText
                        : default( string );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( string );
                }
            }
            else if( _args == null )
            {
                return $"{SQL.SELECT} * FROM {_connectionBuilder?.GetTableName()};";
            }

            return default( string );
        }

        /// <summary>
        /// Gets the update statement.
        /// </summary>
        /// <returns></returns>
        public string GetUpdateStatement()
        {
            if( _args != null )
            {
                try
                {
                    var _update = string.Empty;

                    foreach( var kvp in _args )
                    {
                        _update += $" {kvp.Key} = '{kvp.Value}' AND";
                    }

                    var _values = _update.TrimEnd( " AND".ToCharArray() );
                    _commandText = $"{SQL.UPDATE} {_connectionBuilder?.GetTableName()} SET {_values};";

                    return Verify.Input( _commandText )
                        ? _commandText
                        : default( string );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( string );
                }
            }

            return default( string );
        }

        /// <summary>
        /// Gets the insert statement.
        /// </summary>
        /// <returns></returns>
        public string GetInsertStatement()
        {
            try
            {
                var _table = _connectionBuilder?.GetTableName();
                var _columnName = string.Empty;
                var _values = string.Empty;

                foreach( var kvp in _args )
                {
                    _columnName += $"{kvp.Key}, ";
                    _values += $"{kvp.Value}, ";
                }

                var values =
                    $"({_columnName.TrimEnd( ", ".ToCharArray() )}) VALUES ({_values.TrimEnd( ", ".ToCharArray() )})";

                _commandText = $"{SQL.INSERT} INTO {_table} {values};";

                return Verify.Input( _commandText )
                    ? _commandText
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the delete statement.
        /// </summary>
        /// <returns></returns>
        public string GetDeleteStatement()
        {
            try
            {
                return Verify.Map( _args ) && Verify.Input( _commandText )
                    ? _commandText
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }
    }
}