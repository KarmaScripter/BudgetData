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
            SetFilePath( provider );
            SetFileName( FilePath );
            SetFileExtension( FilePath );
            TableName = source.ToString();
            SetConnectionString( provider );
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
            SetFilePath( fullPath );
            SetFileName( fullPath );
            SetFileExtension( fullPath );
            SetProvider( FileExtension );
            TableName = FileName;
            SetConnectionString( Provider );
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
            SetFilePath( fullPath );
            SetFileName( fullPath );
            SetFileExtension( fullPath );
            SetProvider( provider );
            TableName = FileName;
            SetConnectionString( provider );
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns></returns>
        public string GetFilePath()
        {
            try
            {
                return Verify.Input( FilePath ) 
                    && File.Exists( FilePath )
                        ? Path.GetFullPath( FilePath )
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
                return Validate.EXT( FileExtension )
                    ? FileExtension
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
                return Verify.Input( FilePath ) 
                    && File.Exists( FilePath )
                        ? Path.GetFullPath( FilePath )
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
                return Verify.Input( FilePath )
                    ? Path.GetFullPath( FilePath )
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
                return Verify.Input( ConnectionString )
                    ? ConnectionString
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
                return Verify.Input( TableName )
                    ? TableName
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
                return Validate.Provider( Provider )
                    ? Provider
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
                return Validate.Source( Source )
                    ? Source
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