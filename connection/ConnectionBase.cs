// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

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
        private readonly ConnectionStringSettingsCollection _connector =
            ConfigurationManager.ConnectionStrings;

        /// <summary>
        /// The provider path
        /// </summary>
        private protected readonly NameValueCollection _providerPath = ConfigurationManager.AppSettings;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The file extension
        /// </summary>
        private protected EXT _fileExtension;

        /// <summary>
        /// The file path
        /// </summary>
        private protected string _filePath;

        /// <summary>
        /// The file name
        /// </summary>
        private protected string _fileName;

        /// <summary>
        /// The table name
        /// </summary>
        private protected string _tableName;

        /// <summary>
        /// The connection string
        /// </summary>
        private protected string _connectionString;

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="source">
        /// The source.</param>
        private protected void SetSource( Source source )
        {
            try
            {
                _source = Validate.Source( source )
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
            if( Verify.Input( fileName )
                && File.Exists( fileName )
                && Resource.Sources?.Contains( fileName ) == true )
            {
                try
                {
                    _source = (Source)Enum.Parse( typeof( Source ), fileName );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            if( !Verify.Input( fileName )
                || !File.Exists( fileName )
                || !Resource.Sources?.Contains( fileName ) != true )
            {
                return;
            }

            {
                try
                {
                    _source = Source.External;
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
                _provider = Validate.Provider( provider )
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
                    _provider = extension switch
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
        private protected void SetFilePath( Provider provider )
        {
            if( Validate.Provider( provider ) )
            {
                try
                {
                    _filePath = provider switch
                    {
                        Provider.OleDb => _providerPath[ "OleDb" ],
                        Provider.Access => _providerPath[ "Access" ],
                        Provider.SQLite => _providerPath[ "SQLite" ],
                        Provider.SqlCe => _providerPath[ "SqlCe" ],
                        Provider.SqlServer => _providerPath[ "SqlServer" ],
                        Provider.CSV => _providerPath[ "CSV" ],
                        Provider.Excel => _providerPath[ "Excel" ],
                        Provider.NS => _providerPath[ "Excel" ],
                        _ => _providerPath[ "SQLite" ]
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
        /// <param name="filePath">The filePath.</param>
        private protected void SetFilePath( string filePath )
        {
            try
            {
                _filePath = Verify.Input( filePath ) && File.Exists( filePath )
                    ? Path.GetFullPath( filePath )
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the file extension.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        private protected void SetFileExtension( string filePath )
        {
            if( Verify.Input( filePath ) )
            {
                try
                {
                    var _filext = Path.GetExtension( filePath )?.Trim( '.' )?.ToUpper();

                    _fileExtension = Enum.IsDefined( typeof( EXT ), _filext )
                        ? (EXT)Enum.Parse( typeof( EXT ), _filext )
                        : EXT.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the name of the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private protected void SetFileName( string filePath )
        {
            if( Verify.Input( filePath ) )
            {
                try
                {
                    var _filename = Path.GetFileNameWithoutExtension( filePath );

                    _fileName = Verify.Input( filePath )
                        ? _filename
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the provider path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private protected void SetProviderPath( string filePath )
        {
            if( Verify.Input( filePath )
                && File.Exists( filePath )
                && Path.HasExtension( filePath ) )
            {
                try
                {
                    var _extension = (EXT)Enum.Parse( typeof( EXT ), Path.GetExtension( filePath ) );

                    _filePath = _extension switch
                    {
                        EXT.MDB => ConfigurationManager.AppSettings[ "OleDbFilePath" ],
                        EXT.ACCDB => ConfigurationManager.AppSettings[ "AccessFilePath" ],
                        EXT.DB => ConfigurationManager.AppSettings[ "SQLiteFilePath" ],
                        EXT.SDF => ConfigurationManager.AppSettings[ "SqlCeFilePath" ],
                        EXT.MDF => ConfigurationManager.AppSettings[ "SqlServerFilePath" ],
                        EXT.XLS => ConfigurationManager.AppSettings[ "ExcelFilePath" ].Replace( "{FilePath}", filePath ),
                        EXT.XLSX => ConfigurationManager.AppSettings[ "ExcelFilePath" ].Replace( "{FilePath}", filePath ),
                        EXT.CSV => ConfigurationManager.AppSettings[ "CsvFilePath" ].Replace( "{FilePath}", filePath ),
                        EXT.TXT => ConfigurationManager.AppSettings[ "CsvFilePath" ].Replace( "{FilePath}", filePath ),
                        _ => ConfigurationManager.AppSettings[ "SQLiteFilePath" ]
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the connection string.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private protected void SetConnectionString( Provider provider )
        {
            if( Validate.Provider( provider ) )
            {
                try
                {
                    switch( provider )
                    {
                        case Provider.OleDb:
                        case Provider.Excel:
                        case Provider.CSV:
                        {
                            var _connection = ConfigurationManager.ConnectionStrings[ provider.ToString() ]
                                ?.ConnectionString;

                            _connectionString = Verify.Input( _connection )
                                ? _connection?.Replace( "{FilePath}", _filePath )
                                : string.Empty;

                            break;
                        }

                        case Provider.SQLite:
                        case Provider.Access:
                        case Provider.SqlCe:
                        case Provider.SqlServer:
                        {
                            var _connection = ConfigurationManager.ConnectionStrings[ provider.ToString() ]
                                ?.ConnectionString;

                            _connectionString = Verify.Input( _connection )
                                ? _connection
                                : string.Empty;

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
    }
}