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
        /// <param name = "conectionBuilder" > </param>
        /// <param name = "command" > The command. </param>
        public SqlFactory( IConnectionBuilder conectionBuilder, SQL command = SQL.SELECT )
        {
            Source = conectionBuilder.Source;
            Provider = conectionBuilder.Provider;
            CommandType = command;
            ConnectionBuilder = conectionBuilder;
            SqlStatement = new SqlStatement( ConnectionBuilder, CommandType );
            FilePath = Path.GetFullPath( ProviderPath[ Provider.ToString() ] );
            FileName = Path.GetFileNameWithoutExtension( FilePath );
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
            Source = ConnectionBuilder.Source;
            Provider = ConnectionBuilder.Provider;
            CommandType = command;
            SqlStatement = new SqlStatement( ConnectionBuilder, CommandType );
            FileName = ConnectionBuilder.FileName;
            FilePath = ConnectionBuilder.ProviderPath[ Provider.ToString() ];
        }
    }
}