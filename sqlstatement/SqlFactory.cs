// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary> </summary>
    /// <seealso cref = "SqlStatement"/>
    [SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" )]
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
            _commandType = command;
            _connectionBuilder = builder;
            _sqlStatement = new SqlStatement( _connectionBuilder, _commandType );
            _filePath = Path.GetFullPath( _providerPath[ _provider.ToString() ] );
            _fileName = Path.GetFileNameWithoutExtension( _filePath );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "SqlFactory"/>
        /// class.
        /// </summary>
        /// <param name = "filepath" > The filepath. </param>
        /// <param name = "command" > The command. </param>
        public SqlFactory( string filepath, SQL command = SQL.SELECT )
        {
            _connectionBuilder = new ConnectionBuilder( filepath );
            _source = _connectionBuilder.GetSource();
            _provider = _connectionBuilder.GetProvider();
            _commandType = command;
            _sqlStatement = new SqlStatement( _connectionBuilder, _commandType );
            _fileName = _connectionBuilder.GetFileName();
            _filePath = _connectionBuilder.GetFilePath();
        }
    }
}