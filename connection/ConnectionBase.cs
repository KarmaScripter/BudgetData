// <copyright file = "ConnectionBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class ConnectionBase
    {
        // ***************************************************************************************************************************
        // *********************************************      FIELDS    **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The connector
        /// </summary>
        private protected readonly ConnectionStringSettingsCollection Connector =
            ConfigurationManager.ConnectionStrings;

        /// <summary>
        /// The provider path
        /// </summary>
        private protected readonly NameValueCollection ProviderPath = ConfigurationManager.AppSettings;

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected Source Source { get; set; }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        private protected Provider Provider { get; set; }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        /// <value>
        /// The file extension.
        /// </value>
        private protected EXT FileExtension { get; set; }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        private protected string FilePath { get; set; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        private protected string FileName { get; set; }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        private protected string TableName { get; set; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        private protected string ConnectionString { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        private protected Source GetSource( Source source )
        {
            try
            {
                return Verify.Source( source )
                    ? source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        private protected Source GetSource( string filename )
        {
            if( Verify.Input( filename )
                && File.Exists( filename )
                && Resource.Sources?.Contains( filename ) == true )
            {
                try
                {
                    return (Source)Enum.Parse( typeof( Source ), filename );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Source.NS;
                }
            }

            if( Verify.Input( filename )
                && File.Exists( filename )
                && !Resource.Sources?.Contains( filename ) == true )
            {
                try
                {
                    return Source.External;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Source.NS;
                }
            }

            return Source.NS;
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private protected Provider GetProvider( Provider provider )
        {
            if( Verify.Provider( provider ) )
            {
                try
                {
                    return Resource.Providers?.Contains( provider.ToString() ) == true
                        ? (Provider)Enum.Parse( typeof( Provider ), $"{provider}" )
                        : Provider.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return Provider.NS;
                }
            }

            return Provider.NS;
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns></returns>
        private protected Provider GetProvider( EXT extension )
        {
            if( Verify.EXT( extension ) )
            {
                try
                {
                    return extension switch
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
                    return Provider.NS;
                }
            }

            return Provider.NS;
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private protected string GetFilePath( Provider provider )
        {
            if( Verify.Provider( provider ) )
            {
                try
                {
                    return provider switch
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
        /// Sets the file path.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        private protected string GetFilePath( string filepath )
        {
            try
            {
                return Verify.Input( filepath ) && File.Exists( filepath )
                    ? Path.GetFullPath( filepath )
                    : default;
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
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        private protected EXT GetFileExtension( string filepath )
        {
            if( Verify.Input( filepath ) )
            {
                try
                {
                    var filext = Path.GetExtension( filepath )?.Trim( '.' )?.ToUpper();
                    var ext = (EXT)Enum.Parse( typeof( EXT ), filext );

                    return Verify.EXT( ext )
                        ? ext
                        : EXT.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return EXT.NS;
                }
            }

            return EXT.NS;
        }

        /// <summary>
        /// Sets the name of the file.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        private protected string GetFileName( string filepath )
        {
            if( Verify.Input( filepath ) )
            {
                try
                {
                    var filename = Path.GetFileNameWithoutExtension( filepath );

                    return Verify.Input( filepath )
                        ? filename
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
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        private protected string GetProviderPath( string filepath )
        {
            if( Verify.Input( filepath )
                && File.Exists( filepath )
                && Path.HasExtension( filepath ) )
            {
                try
                {
                    var ext = (EXT)Enum.Parse( typeof( EXT ), Path.GetExtension( filepath ) );

                    return ext switch
                    {
                        EXT.MDB => ConfigurationManager.AppSettings[ "OleDbFilePath" ],
                        EXT.ACCDB => ConfigurationManager.AppSettings[ "AccessFilePath" ],
                        EXT.DB => ConfigurationManager.AppSettings[ "SQLiteFilePath" ],
                        EXT.SDF => ConfigurationManager.AppSettings[ "SqlCeFilePath" ],
                        EXT.MDF => ConfigurationManager.AppSettings[ "SqlServerFilePath" ],
                        EXT.XLS => ConfigurationManager.AppSettings[ "ExcelFilePath" ]
                            .Replace( "{FilePath}", filepath ),
                        EXT.XLSX => ConfigurationManager.AppSettings[ "ExcelFilePath" ]
                            .Replace( "{FilePath}", filepath ),
                        EXT.CSV => ConfigurationManager.AppSettings[ "CsvFilePath" ]
                            .Replace( "{FilePath}", filepath ),
                        EXT.TXT => ConfigurationManager.AppSettings[ "CsvFilePath" ]
                            .Replace( "{FilePath}", filepath ),
                        _ => ConfigurationManager.AppSettings[ "SQLiteFilePath" ]
                    };
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
        /// Sets the connection string.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
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
                            var connection = ConfigurationManager.ConnectionStrings[ provider.ToString() ]
                                ?.ConnectionString;

                            return Verify.Input( connection )
                                ? connection?.Replace( "{FilePath}", FilePath )
                                : string.Empty;
                        }

                        case Provider.SQLite:
                        case Provider.Access:
                        case Provider.SqlCe:
                        case Provider.SqlServer:
                        {
                            var connection = ConfigurationManager.ConnectionStrings[ provider.ToString() ]
                                ?.ConnectionString;

                            return Verify.Input( connection )
                                ? connection
                                : string.Empty;
                        }
                    }
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
    }
}
