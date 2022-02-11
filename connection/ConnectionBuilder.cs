// <copyright file = "ConnectionBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.ConnectionBase" />
    /// <seealso cref="BudgetExecution.ISource" />
    /// <seealso cref="BudgetExecution.IProvider" />
    /// <seealso cref="BudgetExecution.IConnectionBuilder" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class ConnectionBuilder : ConnectionBase, IConnectionBuilder
    {
        /// <summary>
        /// The provider path
        /// </summary>
        public new NameValueCollection ProviderPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ConnectionBuilder" />
        /// class.
        /// </summary>
        public ConnectionBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ConnectionBuilder" />
        /// class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        public ConnectionBuilder( Source source, Provider provider = Provider.SQLite )
        {
            Source = source;
            Provider = provider;
            FilePath = GetFilePath( Provider );
            FileName = Path.GetFileNameWithoutExtension( FilePath );
            ProviderPath = ConfigurationManager.AppSettings;
            FileExtension = (EXT)Enum.Parse( typeof( EXT ), Path.GetExtension( FilePath ) ?? string.Empty );
            TableName = Source.ToString(); 
            ConnectionString = GetConnectionString( Provider );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ConnectionBuilder" />
        /// class.
        /// </summary>
        /// <param name="fullPath">The fullPath.</param>
        public ConnectionBuilder( string fullPath )
        {
            Source = Source.External;
            FilePath = fullPath;
            FileName = Path.GetFileNameWithoutExtension( FilePath );
            FileExtension = (EXT)Enum.Parse( typeof( EXT ), Path.GetExtension( FilePath ) ?? string.Empty );
            Provider = (Provider)Enum.Parse( typeof( Provider ), GetProviderPath( FilePath ) );
            ProviderPath = ConfigurationManager.AppSettings;
            TableName = FileName;
            ConnectionString = GetConnectionString( Provider );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ConnectionBuilder" />
        /// class.
        /// </summary>
        /// <param name="fullPath">The fullPath.</param>
        /// <param name="provider">The provider.</param>
        public ConnectionBuilder( string fullPath, Provider provider = Provider.SQLite )
        {
            Source = Source.External;
            Provider = provider;
            FilePath = fullPath;
            FileName = Path.GetFileNameWithoutExtension( fullPath );
            ProviderPath = ConfigurationManager.AppSettings;
            FileExtension = (EXT)Enum.Parse( typeof( EXT ), Path.GetExtension( fullPath ) ?? string.Empty );
            TableName = Source.ToString();
            ConnectionString = GetConnectionString( Provider );
        }
    }
}