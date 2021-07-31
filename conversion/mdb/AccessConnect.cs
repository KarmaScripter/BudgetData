// <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Data;
    using System.Linq;

    public class AccessConnect
    {
        private readonly OleDbConnection _connection;

        public AccessConnect( string path )
        {
            var connectionstring = "provider=microsoft.jet.oledb.4.0;data source="
                + path
                + ";Jet OLEDB:Database Password=h@#%^ein;";

            _connection = new OleDbConnection( connectionstring );
            _connection?.Open();
        }

        public IEnumerable<string> GetTableNames()
        {
            var _names = new List<string>();
            var _restrictions = new string[ 4 ];
            _restrictions[ 3 ] = "Table";
            var _schema = _connection.GetSchema( "Tables", _restrictions );

            for( var i = 0; i < _schema.Rows.Count; i++ )
            {
                _names.Add( _schema.Rows[ i ][ 2 ].ToString() );
            }

            return _names;
        }

        public DataTable GetTable( string name )
        {
            try
            {
                var _table = new DataTable();
                var _adapter = new OleDbDataAdapter( "SELECT * FROM " + name, _connection );
                _adapter.Fill( _table );

                return _table.Rows.Count > 0
                    ? _table
                    : default( DataTable );
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex );
                throw;
            }
        }

        public List<string> GetColumnNames( string tablename )
        {
            var _names = new List<string>();
            using var _command = new OleDbCommand( "select * from " + tablename, _connection );
            using var _dataReader = _command.ExecuteReader( CommandBehavior.SchemaOnly );
            var _dataTable = _dataReader.GetSchemaTable();
            var _dataColumn = _dataTable?.Columns[ "ColumnName" ];

            if( _dataTable?.Rows != null )
            {
                foreach( DataRow row in _dataTable?.Rows )
                {
                    if( _dataColumn != null )
                    {
                        _names.Add( row[ _dataColumn ].ToString() );
                    }
                }
            }

            return _names?.Any() == true
                ? _names
                : default( List<string> );
        }
    }
}