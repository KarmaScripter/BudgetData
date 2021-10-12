// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.SqlBase" />
    /// <seealso cref="BudgetExecution.IProvider" />
    /// <seealso cref="BudgetExecution.ISource" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class SqlConfig : SqlBase, IProvider, ISource
    {
        /// <summary>
        /// The extension
        /// </summary>
        public EXT _extension = EXT.SQL;

        /// <summary>
        /// The provider path
        /// </summary>
        public NameValueCollection _providerPath = ConfigurationManager.AppSettings;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The SQL statement
        /// </summary>
        private protected ISqlStatement _sqlStatement;

        /// <summary>
        /// The file path
        /// </summary>
        private protected string _filePath;

        /// <summary>
        /// The file name
        /// </summary>
        protected string _fileName;

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns></returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( _source )
                    ? _source
                    : default( Source );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <returns></returns>
        public Provider GetProvider()
        {
            try
            {
                return Validate.Provider( _provider )
                    ? _provider
                    : default( Provider );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Provider );
            }
        }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <returns></returns>
        public SQL GetCommandType()
        {
            try
            {
                return _commandType != SQL.NS
                    ? _commandType
                    : default( SQL );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( SQL );
            }
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetArgs()
        {
            if( _args.Any() )
            {
                try
                {
                    return _args ?? new Dictionary<string, object>();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return new Dictionary<string, object>();
                }
            }

            return new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the connection builder.
        /// </summary>
        /// <returns></returns>
        public IConnectionBuilder GetConnectionBuilder()
        {
            try
            {
                return Verify.Input( _connectionBuilder?.GetConnectionString() )
                    ? _connectionBuilder
                    : default( ConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ConnectionBuilder );
            }
        }

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <returns></returns>
        public string GetCommandText()
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
                return default( string );
            }
        }

        /// <summary>
        /// Gets the script files.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetScriptFiles()
        {
            if( Validate.Provider( _provider )
                && Enum.IsDefined( typeof( SQL ), _commandType ) )
            {
                try
                {
                    var _directory = _providerPath[ $"{_provider}" ] + $@"\{_commandType}";

                    if( Verify.Input( _directory )
                        && Directory.Exists( _directory ) )
                    {
                        var _scriptFiles = Directory.GetFiles( _directory );

                        return _scriptFiles?.Any() == true
                            ? _scriptFiles
                            : default( string[ ] );
                    }

                    return default( IEnumerable<string> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }
    }
}