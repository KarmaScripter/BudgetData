// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
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
            ConnectionBuilder = connectionBuilder;
            SetCommandType( commandType );
            Args = null;
            SetCommandText( Args );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlStatement"/> class.
        /// </summary>
        /// <param name="connectionBuilder">The connectionBuilder.</param>
        /// <param name="dict">The dictionary.</param>
        public SqlStatement( IConnectionBuilder connectionBuilder, IDictionary<string, object> dict )
        {
            ConnectionBuilder = connectionBuilder;
            CommandType = SQL.SELECT;
            SetArgs( dict );
            SetCommandText( Args );
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
            ConnectionBuilder = connectionBuilder;
            SetCommandType( commandType );
            SetArgs( dict );
            SetCommandText( Args );
        }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <returns>
        /// SQL
        /// </returns>
        public SQL GetCommandType()
        {
            return SQL.NS;
        }

        /// <summary>
        /// Gets the select statement.
        /// </summary>
        /// <returns></returns>
        public string GetSelectStatement()
        {
            if( Args != null )
            {
                try
                {
                    var _values = string.Empty;

                    foreach( var kvp in Args )
                    {
                        _values += $"{kvp.Key} = '{kvp.Value}' AND ";
                    }

                    _values = _values.TrimEnd( " AND".ToCharArray() );
                    var _table = ConnectionBuilder?.GetTableName();
                    CommandText = $"{SQL.SELECT} * FROM {_table} WHERE {_values};";

                    return Verify.IsInput( CommandText )
                        ? CommandText
                        : default( string );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( string );
                }
            }
            else if( Args == null )
            {
                return $"{SQL.SELECT} * FROM {ConnectionBuilder?.GetTableName()};";
            }

            return default( string );
        }

        /// <summary>
        /// Gets the update statement.
        /// </summary>
        /// <returns></returns>
        public string GetUpdateStatement()
        {
            if( Args != null )
            {
                try
                {
                    var _update = string.Empty;

                    foreach( var kvp in Args )
                    {
                        _update += $" {kvp.Key} = '{kvp.Value}' AND";
                    }

                    var _values = _update.TrimEnd( " AND".ToCharArray() );
                    CommandText = $"{SQL.UPDATE} {ConnectionBuilder?.GetTableName()} SET {_values};";

                    return Verify.IsInput( CommandText )
                        ? CommandText
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
                var _table = ConnectionBuilder?.GetTableName();
                var _columnName = string.Empty;
                var _values = string.Empty;

                foreach( var kvp in Args )
                {
                    _columnName += $"{kvp.Key}, ";
                    _values += $"{kvp.Value}, ";
                }

                var values =
                    $"({_columnName.TrimEnd( ", ".ToCharArray() )}) VALUES ({_values.TrimEnd( ", ".ToCharArray() )})";

                CommandText = $"{SQL.INSERT} INTO {_table} {values};";

                return Verify.IsInput( CommandText )
                    ? CommandText
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
                return Verify.IsMap( Args ) && Verify.IsInput( CommandText )
                    ? CommandText
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