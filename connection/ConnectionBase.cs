// <copyright file = "ConnectionBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using static System.Configuration.ConfigurationManager;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class ConnectionBase
    {
        /// <summary>
        /// The connector
        /// </summary>
        public ConnectionStringSettingsCollection Connectors { get; set; } = ConnectionStrings;

        /// <summary>
        /// The provider path
        /// </summary>
        public NameValueCollection ProviderPath { get; set; } = AppSettings;

        /// <summary>
        /// The source
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// The provider
        /// </summary>
        public Provider Provider { get; set; }

        /// <summary>
        /// The file extension
        /// </summary>
        public EXT FileExtension { get; set; }

        /// <summary>
        /// The file path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The table name
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// The connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="source">
        /// The source.</param>
        private protected void SetSource( Source source )
        {
            try
            {
                Source = Verify.Source( source )
                    ? source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private protected void SetSource( string fileName )
        {
            if( Verify.IsInput( fileName )
                && File.Exists( fileName )
                && Resource.Sources?.Contains( fileName ) == true )
            {
                try
                {
                    Source = (Source)Enum.Parse( typeof( Source ), fileName );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            if( !Verify.IsInput( fileName )
                || !File.Exists( fileName )
                || !Resource.Sources?.Contains( fileName ) != true )
            {
                return;
            }

            {
                try
                {
                    Source = Source.External;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private protected void SetProvider( Provider provider )
        {
            try
            {
                Provider = Verify.Provider( provider )
                    && Resource.Providers?.Contains( provider.ToString() ) == true
                        ? (Provider)Enum.Parse( typeof( Provider ), $"{provider}" )
                        : Provider.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="extension">The extension.</param>
        private protected void SetProvider( EXT extension )
        {
            if( Validate.EXT( extension ) )
            {
                try
                {
                    Provider = extension switch
                    {
                        EXT.MDB => Provider.OleDb,
                        EXT.XLS => Provider.OleDb,
                        EXT.XLSX => Provider.Excel,
                        EXT.CSV => Provider.CSV,
                        EXT.SDF => Provider.SqlCe,
                        EXT.DB => Provider.SQLite,
                        EXT.MDF => Provider.SqlServer,
                        EXT.ACCDB => Provider.Access,
                        _ => Provider.SQLite
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private protected string GetFilePath( Provider provider )
        {
            if( Verify.Provider( provider ) )
            {
                try
                {
                    FilePath = provider switch
                    {
                        Provider.OleDb => ProviderPath[ "OleDb" ],
                        Provider.Access => ProviderPath[ "Access" ],
                        Provider.SQLite => ProviderPath[ "SQLite" ],
                        Provider.SqlCe => ProviderPath[ "SqlCe" ],
                        Provider.SqlServer => ProviderPath[ "SqlServer" ],
                        Provider.CSV => ProviderPath[ "CSV" ],
                        Provider.Excel => ProviderPath[ "Excel" ],
                        Provider.NS => ProviderPath[ "Excel" ],
                        _ => ProviderPath[ "SQLite" ]
                    };

                    return !string.IsNullOrEmpty( FilePath )
                        ? FilePath
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        private protected string GetFilePath( string filePath )
        {
            try
            {
                return Verify.IsInput( filePath ) 
                    && File.Exists( filePath )
                        ? Path.GetFullPath( filePath )
                        : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Sets the file extension.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        private protected string GetFileExtension( string filePath )
        {
            if( Verify.IsInput( filePath ) )
            {
                try
                {
                    var _fileExtension = Path.GetExtension( filePath )
                            ?.Trim( '.' )
                            ?.ToUpper();

                    FileExtension = Enum.IsDefined( typeof( EXT ), _fileExtension )
                        ? (EXT)Enum.Parse( typeof( EXT ), _fileExtension )
                        : EXT.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the name of the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private protected string GetFileName( string filePath )
        {
            if( Verify.IsInput( filePath ) )
            {
                try
                {
                    var _filename = Path.GetFileNameWithoutExtension( filePath );

                    return !string.IsNullOrEmpty( _filename )
                        ? _filename
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the provider path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private protected string GetProviderPath( string filePath )
        {
            if( Verify.IsInput( filePath )
                && File.Exists( filePath )
                && Path.HasExtension( filePath ) )
            {
                try
                {
                    var _extension = Path.GetExtension( filePath );
                    var _provider =  (EXT)Enum.Parse( typeof( EXT ), _extension );

                    return _provider switch
                    {
                        EXT.MDB => AppSettings[ "OleDbFilePath" ],
                        EXT.ACCDB => AppSettings[ "AccessFilePath" ],
                        EXT.DB => AppSettings[ "SQLiteFilePath" ],
                        EXT.SDF => AppSettings[ "SqlCeFilePath" ],
                        EXT.MDF => AppSettings[ "SqlServerFilePath" ],
                        EXT.XLS => AppSettings[ "ExcelFilePath" ].Replace( "{FilePath}", filePath ),
                        EXT.XLSX => AppSettings[ "ExcelFilePath" ].Replace( "{FilePath}", filePath ),
                        EXT.CSV => AppSettings[ "CsvFilePath" ].Replace( "{FilePath}", filePath ),
                        EXT.TXT => AppSettings[ "CsvFilePath" ].Replace( "{FilePath}", filePath ),
                        _ => AppSettings[ "SQLiteFilePath" ]
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the connection string.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private protected string GetConnectionString( Provider provider )
        {
            if( Verify.Provider( provider ) )
            {
                try
                {
                    switch( provider )
                    {
                        case Provider.OleDb:
                        case Provider.Excel:
                        case Provider.CSV:
                        {
                            var _connection = ConnectionStrings[ provider.ToString() ]?.ConnectionString;

                            return Verify.IsInput( _connection )
                                ? _connection?.Replace( "{FilePath}", FilePath )
                                : string.Empty;
                        }

                        case Provider.SQLite:
                        case Provider.Access:
                        case Provider.SqlCe:
                        case Provider.SqlServer:
                        {
                            var _connection = ConnectionStrings[ provider.ToString() ]
                                              ?.ConnectionString;

                            return Verify.IsInput( _connection )
                                ? _connection
                                : string.Empty;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( );
            _error?.ShowDialog();
        }
    }
}