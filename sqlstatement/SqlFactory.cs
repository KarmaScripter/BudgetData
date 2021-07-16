// // <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary> </summary>
    /// <seealso cref = "SqlStatement"/>
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class SqlFactory : SqlConfig
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "SqlFactory"/>
        /// class.
        /// </summary>
        /// <param name = "builder" > </param>
        /// <param name = "command" > The command. </param>
        public SqlFactory( IConnectionBuilder builder, SQL command = SQL.SELECT )
        {
            Source = builder.GetSource();
            Provider = builder.GetProvider();
            CommandType = command;
            ConnectionBuilder = builder;
            SqlStatement = new SqlStatement( ConnectionBuilder, CommandType );
            FilePath = Path.GetFullPath( providerPath[ Provider.ToString() ] );
            FileName = Path.GetFileNameWithoutExtension( FilePath );
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
            ConnectionBuilder = new ConnectionBuilder( filepath );
            Source = ConnectionBuilder.GetSource();
            Provider = ConnectionBuilder.GetProvider();
            CommandType = command;
            SqlStatement = new SqlStatement( ConnectionBuilder, CommandType );
            FileName = ConnectionBuilder.GetFileName();
            FilePath = ConnectionBuilder.GetFilePath();
        }
    }
}