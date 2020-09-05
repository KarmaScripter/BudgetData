// // <copyright file = "AccessConnect.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public class AccessConnect
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The connection
        /// </summary>
        private readonly OleDbConnection Connection;

        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessConnect"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public AccessConnect( string path )
        {
            var connectionstring = "provider=microsoft.jet.oledb.4.0;data source="
                + path
                + ";Jet OLEDB:Database Password=h@#%^ein;";

            Connection = new OleDbConnection( connectionstring );
            Connection.Open();
        }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the table names.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetTableNames()
        {
            var names = new List<string>();
            var restrictions = new string[ 4 ];
            restrictions[ 3 ] = "Table";

            //getting names of tables
            var table = Connection.GetSchema( "Tables", restrictions );

            for( var i = 0; i < table.Rows.Count; i++ )
            {
                names.Add( table.Rows[ i ][ 2 ].ToString() );
            }

            return names;
        }

        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public DataTable GetTable( string name )
        {
            var table = new DataTable();
            var adapter = new OleDbDataAdapter( "SELECT * FROM " + name, Connection );
            adapter.Fill( table );
            return table;
        }

        /// <summary>
        /// Gets the column names.
        /// </summary>
        /// <param name="tablename">The tablename.</param>
        /// <returns></returns>
        public List<string> GetColumnNames( string tablename )
        {
            var names = new List<string>();
            using var command = new OleDbCommand( "select * from " + tablename, Connection );
            using var reader = command.ExecuteReader( CommandBehavior.SchemaOnly );
            var table = reader.GetSchemaTable();
            var column = table?.Columns[ "ColumnName" ];

            if( table?.Rows != null )
            {
                foreach( DataRow row in table?.Rows )
                {
                    if( column != null )
                    {
                        names.Add( row[ column ].ToString() );
                    }
                }
            }

            return names;
        }
    }
}
