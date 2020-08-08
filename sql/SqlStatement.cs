// <copyright file="SqlStatement.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref = "T:BudgetExecution.ISqlStatement"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class SqlStatement : SqlBase, ISqlStatement
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlStatement"/> class.
        /// </summary>
        public SqlStatement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlStatement"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The manager.
        /// </param>
        /// <param name = "commandtype" >
        /// The commandtype.
        /// </param>
        public SqlStatement( IConnectionBuilder builder, SQL commandtype = SQL.SELECT )
        {
            ConnectionBuilder = builder;
            CommandType = GetCommandType( commandtype );
            CommandText = GetCommandText();
            Args = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlStatement"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The manager.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public SqlStatement( IConnectionBuilder builder, IDictionary<string, object> dict )
        {
            ConnectionBuilder = builder;
            CommandType = SQL.SELECT;
            Args = dict;
            CommandText = GetCommandText();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlStatement"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The manager.
        /// </param>
        /// <param name = "commandtype" >
        /// The commandtype.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public SqlStatement( IConnectionBuilder builder, IDictionary<string, object> dict, SQL commandtype = SQL.SELECT )
        {
            ConnectionBuilder = builder;
            CommandType = GetCommandType( commandtype );
            Args = dict;
            CommandText = GetCommandText();
        }

        // **********************************************************************************************************************
        // *************************************************    METHODS     *****************************************************
        // **********************************************************************************************************************

        /// <inheritdoc/>
        /// <summary>
        /// Gets the select statement.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetSelectStatement()
        {
            if( Args != null )
            {
                try
                {
                    var vals = string.Empty;

                    foreach( var kvp in Args )
                    {
                        vals += $"{kvp.Key} = '{kvp.Value}' AND ";
                    }

                    var values = vals.TrimEnd( " AND".ToCharArray() );
                    var table = ConnectionBuilder?.GetTableName();
                    CommandText = $"{SQL.SELECT} * FROM {table} WHERE {values};";

                    return Verify.Input( CommandText )
                        ? CommandText
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }
            else if( Args == null )
            {
                return $"{SQL.SELECT} * FROM {ConnectionBuilder?.GetTableName()};";
            }

            return default;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the update statement.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetUpdateStatement()
        {
            if( Args != null )
            {
                try
                {
                    var update = string.Empty;

                    foreach( var kvp in Args )
                    {
                        update += $" {kvp.Key} = '{kvp.Value}' AND";
                    }

                    var vals = update.TrimEnd( " AND".ToCharArray() );
                    CommandText = $"{SQL.UPDATE} {ConnectionBuilder?.GetTableName()} SET {vals};";

                    return Verify.Input( CommandText )
                        ? CommandText
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the insert statement.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetInsertStatement()
        {
            try
            {
                var table = ConnectionBuilder?.GetTableName();
                var colname = string.Empty;
                var vals = string.Empty;

                foreach( var kvp in Args )
                {
                    colname += $"{kvp.Key}, ";
                    vals += $"{kvp.Value}, ";
                }

                var values =
                    $"({colname.TrimEnd( ", ".ToCharArray() )}) VALUES ({vals.TrimEnd( ", ".ToCharArray() )})";

                CommandText = $"{SQL.INSERT} INTO {table} {values};";

                return Verify.Input( CommandText )
                    ? CommandText
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the delete statement.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetDeleteStatement()
        {
            try
            {
                var vals = string.Empty;

                foreach( var kvp in Args )
                {
                    vals += $"{kvp.Key} = '{kvp.Value}' AND ";
                }

                var values = vals.TrimEnd( " AND".ToCharArray() );
                var table = ConnectionBuilder?.GetTableName();
                CommandText = $"{SQL.DELETE} FROM {table} WHERE {values};";

                return Verify.Input( CommandText )
                    ? CommandText
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetCommandText()
        {
            try
            {
                return CommandType switch
                {
                    SQL.SELECT => GetSelectStatement(),
                    SQL.INSERT => GetInsertStatement(),
                    SQL.UPDATE => GetUpdateStatement(),
                    SQL.DELETE => GetDeleteStatement(),
                    _ => GetSelectStatement()
                };
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}