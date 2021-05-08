// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class SqlConfig : SqlBase, IProvider, ISource
    {
        // ***************************************************************************************************************************
        // *********************************************      FIELDS    **************************************************************
        // ***************************************************************************************************************************

        private protected readonly EXT Extension = EXT.SQL;

        /// <summary> The provider path </summary>
        private protected readonly NameValueCollection ProviderPath = ConfigurationManager.AppSettings;

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary> Gets the source. </summary>
        /// <value> The source. </value>
        private protected Source Source { get; set; }

        /// <summary> Gets the provider. </summary>
        /// <value> The provider. </value>
        private protected Provider Provider { get; set; }

        /// <summary> Gets the SQL statement. </summary>
        /// <value> The SQL statement. </value>
        private protected ISqlStatement SqlStatement { get; set; }

        /// <summary> Gets the file path. </summary>
        /// <value> The file path. </value>
        private protected string FilePath { get; set; }

        /// <summary> Gets the name of the file. </summary>
        /// <value> The name of the file. </value>
        protected string FileName { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary> Gets the source. </summary>
        /// <returns> </returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( Source )
                    ? Source
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary> Gets the provider. </summary>
        /// <returns> </returns>
        public Provider GetProvider()
        {
            try
            {
                return Validate.Provider( Provider )
                    ? Provider
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <inheritdoc/>
        /// <summary> Gets the type of the command. </summary>
        /// <returns> SQL </returns>
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
        /// <summary> Gets the arguments. </summary>
        /// <returns> </returns>
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
                    return new Dictionary<string, object>();
                }
            }

            return new Dictionary<string, object>();
        }

        /// <inheritdoc/>
        /// <summary> Gets the connection manager. </summary>
        /// <returns> </returns>
        public IConnectionBuilder GetConnectionBuilder()
        {
            try
            {
                return Verify.Input( ConnectionBuilder?.GetConnectionString() )
                    ? ConnectionBuilder
                    : default( ConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ConnectionBuilder );
            }
        }

        /// <summary> Gets the command text. </summary>
        /// <returns> </returns>
        public string GetCommandText()
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
                return default;
            }
        }

        /// <summary> Gets the script files. </summary>
        /// <returns> </returns>
        public IEnumerable<string> GetScriptFiles()
        {
            if( Validate.Provider( Provider )
                && Enum.IsDefined( typeof( SQL ), CommandType ) )
            {
                try
                {
                    var directory = ProviderPath[ $"{Provider}" ] + $@"\{CommandType}";

                    if( Verify.Input( directory )
                        && Directory.Exists( directory ) )
                    {
                        var scriptfiles = Directory.GetFiles( directory );

                        return scriptfiles?.Any() == true
                            ? scriptfiles
                            : default;
                    }

                    return default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }
    }
}