// <copyright file="{ClassName}.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public abstract class SqlBase
    {
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the connection factory.
        /// </summary>
        /// <value>
        /// The connection factory.
        /// </value>
        private protected IConnectionBuilder ConnectionBuilder { get; set; }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <value>
        /// The type of the command.
        /// </value>
        private protected SQL CommandType { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// Gets or sets the command text.
        /// </summary>
        /// <value>
        /// The command text.
        /// </value>
        private protected string CommandText { get; set; }

        // **********************************************************************************************************************
        // *************************************************    METHODS     *****************************************************
        // **********************************************************************************************************************

        /// <inheritdoc/>
        /// <summary>
        /// Gets the connection manager.
        /// </summary>
        /// <returns>
        /// </returns>
        public IConnectionBuilder GetConnectionBuilder()
        {
            try
            {
                return ConnectionBuilder ?? default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the type of the command.
        /// </summary>
        /// <param name = "commandtype" >
        /// The commandtype.
        /// </param>
        /// <returns>
        /// </returns>
        private protected static SQL GetCommandType( SQL commandtype )
        {
            try
            {
                return Enum.IsDefined( typeof( SQL ), commandtype )
                    && Enum.GetNames( typeof( SQL ) ).Contains( commandtype.ToString() )
                        ? commandtype
                        : SQL.SELECT;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <returns>
        /// SQL
        /// </returns>
        public SQL GetCommandType()
        {
            try
            {
                return CommandType != SQL.NS
                    ? CommandType
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
        /// Gets the arguments.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetArgs()
        {
            if( Args.Any() )
            {
                try
                {
                    return Args ?? new Dictionary<string, object>();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
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