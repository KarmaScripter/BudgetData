// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

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

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public abstract class ConnectionBase
    {
        // ***************************************************************************************************************************
        // *********************************************      FIELDS    **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The connector contains the available connection strings defined within the
        /// App.Config file
        /// </summary>
        private readonly ConnectionStringSettingsCollection _connector =
            ConfigurationManager.ConnectionStrings;

        /// <summary>
        /// The name value collection containing the file paths to the applications data
        /// providers.
        /// </summary>
        private protected readonly NameValueCollection _providerPath = ConfigurationManager.AppSettings;

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary> Represents the source table in the database </summary>
        /// <value> The source. </value>
        private protected Source Source { get; set; }

        /// <summary> Represents the data provider. </summary>
        /// <value> The provider. </value>
        private protected Provider Provider { get; set; }

        /// <summary> Represents the file extension. </summary>
        /// <value> The file extension. </value>
        private protected EXT FileExtension { get; set; }

        /// <summary> Represents the path to the data file. </summary>
        /// <value> The file path. </value>
        private protected string FilePath { get; set; }

        /// <summary> Represents the name of the selected file. </summary>
        /// <value> The name of the file. </value>
        private protected string FileName { get; set; }

        /// <summary> The name of the data table. </summary>
        /// <value> The name of the table. </value>
        private protected string TableName { get; set; }

        /// <summary> Gets the connection string. </summary>
        /// <value> The connection string. </value>
        private protected string ConnectionString { get; set; }

        private protected ConnectionStringSettingsCollection Connector
        {
            get
            {
                return _connector;
            }
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary> Sets the source. </summary>
        /// <param name = "source" > The source. </param>
        /// <returns> </returns>
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

        /// <summary> Sets the source. </summary>
        /// <param name = "filename" > The filename. </param>
        /// <returns> </returns>
        private protected void SetSource( string filename )
        {
            if( Verify.Input( filename )
                && File.Exists( filename )
                && Resource.Sources
                    ?.Contains( filename ) == true )
            {
                try
                {
                    Source = (Source)Enum.Parse( typeof( Source ), filename );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            if( !Verify.Input( filename )
                || !File.Exists( filename )
                || !Resource.Sources?.Contains( filename ) != true )
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
                    ConnectionBase.Fail( ex );
                }
            }
        }

        /// <summary> Sets the provider. </summary>
        /// <param name = "provider" > The provider. </param>
        /// <returns> </returns>
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

        /// <summary> Sets the provider. </summary>
        /// <param name = "extension" > The extension. </param>
        /// <returns> </returns>
        private protected void SetProvider( EXT extension )
        {
            if( Verify.EXT( extension ) )
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

        /// <summary> Sets the file path. </summary>
        /// <param name = "provider" > The provider. </param>
        /// <returns> </returns>
        private protected void SetFilePath( Provider provider )
        {
            if( Verify.Provider( provider ) )
            {
                try
                {
                    FilePath = provider switch
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

        /// <summary> Sets the file path. </summary>
        /// <param name = "filepath" > The filepath. </param>
        /// <returns> </returns>
        private protected void SetFilePath( string filepath )
        {
            try
            {
                FilePath = Verify.Input( filepath ) && File.Exists( filepath )
                    ? Path.GetFullPath( filepath )
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary> Sets the file extension. </summary>
        /// <param name = "filepath" > The filepath. </param>
        /// <returns> </returns>
        private protected void SetFileExtension( string filepath )
        {
            if( Verify.Input( filepath ) )
            {
                try
                {
                    var filext = Path.GetExtension( filepath )?.Trim( '.' )?.ToUpper();

                    FileExtension = Enum.IsDefined( typeof( EXT ), filext )
                        ? (EXT)Enum.Parse( typeof( EXT ), filext )
                        : EXT.NS;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the name of the file. </summary>
        /// <param name = "filepath" > The filepath. </param>
        /// <returns> </returns>
        private protected void SetFileName( string filepath )
        {
            if( Verify.Input( filepath ) )
            {
                try
                {
                    var filename = Path.GetFileNameWithoutExtension( filepath );

                    FileName = Verify.Input( filepath )
                        ? filename
                        : string.Empty;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary> Sets the provider path. </summary>
        /// <param name = "filepath" > The filepath. </param>
        /// <returns> </returns>
        private protected void SetProviderPath( string filepath )
        {
            if( Verify.Input( filepath )
                && File.Exists( filepath )
                && Path.HasExtension( filepath ) )
            {
                try
                {
                    var ext = (EXT)Enum.Parse( typeof( EXT ), Path.GetExtension( filepath ) );

                    FilePath = ext switch
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
                }
            }
        }

        /// <summary> Sets the connection string. </summary>
        /// <param name = "provider" > The provider. </param>
        /// <returns> </returns>
        private protected void SetConnectionString( Provider provider )
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

                            ConnectionString = Verify.Input( connection )
                                ? connection?.Replace( "{FilePath}", FilePath )
                                : string.Empty;

                            break;
                        }

                        case Provider.SQLite:
                        case Provider.Access:
                        case Provider.SqlCe:
                        case Provider.SqlServer:
                        {
                            var connection = ConfigurationManager.ConnectionStrings[ provider.ToString() ]
                                ?.ConnectionString;

                            ConnectionString = Verify.Input( connection )
                                ? connection
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

        /// <summary> Get Error Dialog. </summary>
        /// <param name = "ex" > The ex. </param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}