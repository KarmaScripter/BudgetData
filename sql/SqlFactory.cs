// <copyright file="ScriptFactory.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// </summary>
    /// <seealso cref = "SqlStatement"/>
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class SqlFactory : SqlConfig
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlFactory"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// </param>
        /// <param name = "command" >
        /// The command.
        /// </param>
        public SqlFactory( IConnectionBuilder builder, SQL command )
        {
            Source = builder.GetSource();
            Provider = builder.GetProvider();
            CommandType = command;
            ConnectionBuilder = builder;
            SqlStatement = new SqlStatement( ConnectionBuilder, CommandType );
            FilePath = Path.GetFullPath( ProviderPath[ Provider.ToString() ] );
            FileName = Path.GetFileNameWithoutExtension( FilePath );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlFactory"/> class.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <param name = "command" >
        /// The command.
        /// </param>
        public SqlFactory( string filepath, SQL command = SQL.SELECT )
        {
            ConnectionBuilder = new ConnectionBuilder( filepath );
            CommandType = command;
            SqlStatement = new SqlStatement( ConnectionBuilder, CommandType );
            FileName = ConnectionBuilder.GetFileName();
            FilePath = ConnectionBuilder.GetFilePath();
        }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the script reader.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetCommandText()
        {
            try
            {
                var script = GetScriptFiles()
                    ?.Where( s => s.Equals( FileName ) )
                    ?.Select( s => s )
                    ?.Single();

                if( Verify.Input( script )
                    && File.Exists( script ) )
                {
                    var scriptreader = File.ReadAllText( script );

                    return Verify.Input( scriptreader )
                        ? scriptreader
                        : string.Empty;
                }

                return string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}