// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary> </summary>
    /// <seealso cref = "SqlStatement"/>
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class SqlFactory : SqlConfig
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "SqlFactory"/>
        /// class.
        /// </summary>
        /// <param name = "builder" > </param>
        /// <param name = "command" > The command. </param>
        public SqlFactory( IConnectionBuilder builder, SQL command = SQL.SELECT )
        {
            _source = builder.GetSource();
            _provider = builder.GetProvider();
            CommandType = command;
            ConnectionBuilder = builder;
            _sqlStatement = new SqlStatement( ConnectionBuilder, CommandType );
            _filePath = Path.GetFullPath( _providerPath[ _provider.ToString() ] );
            _fileName = Path.GetFileNameWithoutExtension( _filePath );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "SqlFactory"/>
        /// class.
        /// </summary>
        /// <param name = "filePath" > The filePath. </param>
        /// <param name = "command" > The command. </param>
        public SqlFactory( string filePath, SQL command = SQL.SELECT )
        {
            ConnectionBuilder = new ConnectionBuilder( filePath );
            _source = ConnectionBuilder.GetSource();
            _provider = ConnectionBuilder.GetProvider();
            CommandType = command;
            _sqlStatement = new SqlStatement( ConnectionBuilder, CommandType );
            _fileName = ConnectionBuilder.GetFileName();
            _filePath = ConnectionBuilder.GetFilePath();
        }
    }
}