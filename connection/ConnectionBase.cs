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

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public abstract class ConnectionBase
    {
        /// <summary>
        /// The connector
        /// </summary>
        public virtual ConnectionStringSettingsCollection Connectors { get; set; } = ConfigurationManager.ConnectionStrings;

        /// <summary>
        /// The provider path
        /// </summary>
        public virtual NameValueCollection AppSettings { get; set; } = ConfigurationManager.AppSettings;

        /// <summary>
        /// The source
        /// </summary>
        public virtual Source Source { get; set; }

        /// <summary>
        /// The provider
        /// </summary>
        public virtual Provider Provider { get; set; }

        /// <summary>
        /// The file extension
        /// </summary>
        public virtual EXT FileExtension { get; set; }

        /// <summary>
        /// The file path
        /// </summary>
        public virtual string FilePath { get; set; }

        /// <summary>
        /// The file name
        /// </summary>
        public virtual string FileName { get; set; }

        /// <summary>
        /// The table name
        /// </summary>
        public virtual string TableName { get; set; }

        /// <summary>
        /// The connection string
        /// </summary>
        public virtual string ConnectionString { get; set; }
        
        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public virtual string GetFilePath( Provider provider )
        {
            if( Validate.IsProvider( provider ) )
            {
                try
                {
                    FilePath = provider switch
                    {
                        Provider.OleDb => AppSettings[ "OleDb" ],
                        Provider.Access => AppSettings[ "Access" ],
                        Provider.SQLite => AppSettings[ "SQLite" ],
                        Provider.SqlCe => AppSettings[ "SqlCe" ],
                        Provider.SqlServer => AppSettings[ "SqlServer" ],
                        Provider.CSV => AppSettings[ "CSV" ],
                        Provider.Excel => AppSettings[ "Excel" ],
                        Provider.NS => AppSettings[ "Excel" ],
                        _ => AppSettings[ "SQLite" ]
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
        public virtual string GetFilePath( string filePath )
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
        public virtual string GetConnectionString( Provider provider )
        {
            if( Validate.IsProvider( provider ) )
            {
                try
                {
                    switch( provider )
                    {
                        case Provider.OleDb:
                        case Provider.Excel:
                        case Provider.CSV:
                        {
                            var _connection = Connectors[ provider.ToString() ]?.ConnectionString;

                            return Verify.IsInput( _connection )
                                ? _connection?.Replace( "{FilePath}", FilePath )
                                : string.Empty;
                        }

                        case Provider.SQLite:
                        case Provider.Access:
                        case Provider.SqlCe:
                        case Provider.SqlServer:
                        {
                            var _connection = Connectors[ provider.ToString() ]?.ConnectionString;

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
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}