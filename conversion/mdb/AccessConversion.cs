// <copyright file = "AccessConversion.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System.Diagnostics.CodeAnalysis;
    using System;
    using System.Data.SQLite;

    // ***************************************************************************************************************************
    // ****************************************************  CONSTRUCTORS ********************************************************
    // ***************************************************************************************************************************

    /// <summary>
    /// 
    /// </summary>
    [SuppressMessage( "ReSharper", "UnusedMethodReturnValue.Global" )]
    public class AccessConversion
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The connection
        /// </summary>
        private readonly SQLiteConnection _connection;

        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessConversion"/> class.
        /// </summary>
        public AccessConversion()
        {
            SQLiteConnection.CreateFile( "MyDatabase.sqlite" );
            _connection = new SQLiteConnection( "Data Source=MyDatabase.sqlite;Version=3;" );
            _connection.Open();
        }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public int CreateTable( string name )
        {
            var sql = "CREATE TABLE " + name + " (word varchar(200), image text)";
            var cmd = new SQLiteCommand( sql, _connection );
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Inserts the row.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="image">The image.</param>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        public int InsertRow( string word, string image, string table )
        {
            var sql = "INSERT INTO " + table + " (word,image) VALUES ( @word, @image )";
            var cmd = new SQLiteCommand( sql, _connection );
            cmd.Parameters.AddWithValue( "@word", word );
            cmd.Parameters.AddWithValue( "@image", image );
            return cmd.ExecuteNonQuery();
        }
    }
}