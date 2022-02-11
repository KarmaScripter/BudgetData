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
    public abstract class SqlConfig : SqlBase
    {
        /// <summary>
        /// The extension
        /// </summary>
        public readonly EXT Extension = EXT.SQL;

        /// <summary>
        /// The provider path
        /// </summary>
        public NameValueCollection ProviderPath { get; set; } = ConfigurationManager.AppSettings;

        /// <summary>
        /// The source
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// The provider
        /// </summary>
        public Provider Provider { get; set; }

        /// <summary>
        /// The SQL statement
        /// </summary>
        public ISqlStatement SqlStatement { get; set; }

        /// <summary>
        /// The file path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The file name
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the connection builder.
        /// </summary>
        /// <returns></returns>
        public IConnectionBuilder GetConnectionBuilder()
        {
            try
            {
                return Verify.IsInput( ConnectionBuilder?.ConnectionString )
                    ? ConnectionBuilder
                    : default( ConnectionBuilder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ConnectionBuilder );
            }
        }
        
        /// <summary>
        /// Gets the script files.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetScriptFiles()
        {
            if( Validate.IsProvider( Provider )
                && Enum.IsDefined( typeof( SQL ), CommandType ) )
            {
                try
                {
                    var _directory = ProviderPath[ $"{Provider}" ] + $@"\{CommandType}";

                    if( Verify.IsInput( _directory )
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