// <copyright file = "ConnectionBuilder.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
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
    public class ConnectionBuilder : ConnectionBase, ISource, IProvider, IConnectionBuilder
    {
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
            SetSource( source );
            SetProvider( provider );
            SetFilePath( _provider );
            SetFileName( _filePath );
            SetFileExtension( _filePath );
            _tableName = _source.ToString();
            SetConnectionString( _provider );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ConnectionBuilder" />
        /// class.
        /// </summary>
        /// <param name="fullPath">The fullPath.</param>
        public ConnectionBuilder( string fullPath )
        {
            _source = Source.External;
            SetFilePath( fullPath );
            SetFileName( _filePath );
            SetFileExtension( _filePath );
            SetProvider( _fileExtension );
            _tableName = _fileName;
            SetConnectionString( _provider );
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
            _source = Source.External;
            SetFilePath( fullPath );
            SetFileName( _filePath );
            SetFileExtension( _filePath );
            SetProvider( provider );
            _tableName = _fileName;
            SetConnectionString( _provider );
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns></returns>
        public string GetFilePath()
        {
            try
            {
                return Verify.Input( _filePath ) 
                    && File.Exists( _filePath )
                        ? Path.GetFullPath( _filePath )
                        : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        /// <returns></returns>
        public EXT GetFileExtension()
        {
            try
            {
                return Validate.EXT( _fileExtension )
                    ? _fileExtension
                    : EXT.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return EXT.NS;
            }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns></returns>
        public string GetFileName()
        {
            try
            {
                return Verify.Input( _filePath ) && File.Exists( _filePath )
                    ? Path.GetFullPath( _filePath )
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the provider path.
        /// </summary>
        /// <returns></returns>
        public string GetProviderPath()
        {
            try
            {
                return Verify.Input( _filePath )
                    ? Path.GetFullPath( _filePath )
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            try
            {
                return Verify.Input( _connectionString )
                    ? _connectionString
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <returns></returns>
        public string GetTableName()
        {
            try
            {
                return Verify.Input( _tableName )
                    ? _tableName
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
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
        /// Gets the source.
        /// </summary>
        /// <returns></returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( _source )
                    ? _source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }
    }
}