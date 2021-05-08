// <copyright file = "Query.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// </summary>
    /// <seealso cref = "IDisposable"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class Query : QueryBase, IQuery
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Query"/> class.
        /// </summary>
        public Query()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Query"/> class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "provider" >
        /// The provider.
        /// </param>
        /// <param name = "commandtype" >
        /// The commandtype.
        /// </param>
        public Query( Source source, Provider provider = Provider.SQLite, SQL commandtype = SQL.SELECT )
        {
            SetConnectionBuilder( source, provider );
            ConnectionFactory = new ConnectionFactory( ConnectionBuilder );
            SqlStatement = new SqlStatement( ConnectionBuilder, commandtype );
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
            Adapter = new AdapterFactory( ConnectionBuilder, SqlStatement )?.GetAdapter();
            IsDisposed = false;
            Args = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Query"/> class.
        /// </summary>
        /// <param name = "source" >
        /// The source data.
        /// </param>
        /// <param name = "provider" >
        /// The provider used.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary of parameters.
        /// </param>
        /// <param name = "commandtype" >
        /// The type of sql command.
        /// </param>
        public Query( Source source, Provider provider, IDictionary<string, object> dict,
            SQL commandtype )
        {
            SetConnectionBuilder( source, provider );
            ConnectionFactory = new ConnectionFactory( ConnectionBuilder );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, commandtype );
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
            Adapter = new AdapterFactory( ConnectionBuilder, SqlStatement )?.GetAdapter();
            IsDisposed = false;
            Args = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Query"/> class.
        /// </summary>
        /// <param name = "connectionbuilder" >
        /// The connectionbuilder.
        /// </param>
        /// <param name = "sqlstatement" >
        /// The sqlstatement.
        /// </param>
        public Query( IConnectionBuilder connectionbuilder, ISqlStatement sqlstatement )
        {
            ConnectionBuilder = connectionbuilder;
            ConnectionFactory = new ConnectionFactory( ConnectionBuilder );
            SqlStatement = sqlstatement;
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
            Adapter = new AdapterFactory( ConnectionBuilder, SqlStatement )?.GetAdapter();
            IsDisposed = false;
            Args = SqlStatement.GetArgs();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Query"/> class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "provider" >
        /// The provider.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public Query( Source source, Provider provider, IDictionary<string, object> dict )
        {
            SetConnectionBuilder( source, provider );
            ConnectionFactory = new ConnectionFactory( ConnectionBuilder );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, SQL.SELECT );
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
            Adapter = new AdapterFactory( ConnectionBuilder, SqlStatement )?.GetAdapter();
            IsDisposed = false;
            Args = SqlStatement?.GetArgs();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Query"/> class.
        /// </summary>
        /// <param name = "fullpath" >
        /// The fullpath.
        /// </param>
        /// <param name = "commandtype" >
        /// The commandtype.
        /// </param>
        public Query( string fullpath, SQL commandtype = SQL.SELECT )
        {
            SetConnectionBuilder( fullpath );
            ConnectionFactory = new ConnectionFactory( ConnectionBuilder );
            SqlStatement = new SqlStatement( ConnectionBuilder, commandtype );
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
            Adapter = new AdapterFactory( ConnectionBuilder, SqlStatement )?.GetAdapter();
            IsDisposed = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Query"/> class.
        /// </summary>
        /// <param name = "fullpath" >
        /// The fullpath.
        /// </param>
        /// <param name = "commandtype" >
        /// The commandtype.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public Query( string fullpath, SQL commandtype, IDictionary<string, object> dict )
        {
            SetConnectionBuilder( fullpath );
            ConnectionFactory = new ConnectionFactory( ConnectionBuilder );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, commandtype );
            CommandBuilder = new CommandBuilder( ConnectionBuilder, SqlStatement );
            Adapter = new AdapterFactory( ConnectionBuilder, SqlStatement )?.GetAdapter();
            IsDisposed = false;
            Args = SqlStatement?.GetArgs();
        }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <inheritdoc/>
        /// <summary>
        /// Sets the data reader.
        /// </summary>
        /// <param name = "command" >
        /// The command.
        /// </param>
        /// <param name = "behavior" >
        /// The behavior.
        /// </param>
        /// <returns>
        /// </returns>
        public DbDataReader GetDataReader( DbCommand command, 
            CommandBehavior behavior = CommandBehavior.CloseConnection )
        {
            if( Command?.Connection != null
                && Verify.Input( command?.CommandText )
                && Enum.IsDefined( typeof( CommandBehavior ), behavior ) )
            {
                try
                {
                    if( command?.Connection?.State != ConnectionState.Open )
                    {
                        command?.Connection?.Open();
                        return command?.ExecuteReader( CommandBehavior.CloseConnection );
                    }

                    if( command?.Connection?.State == ConnectionState.Open )
                    {
                        return command?.ExecuteReader( CommandBehavior.CloseConnection );
                    }
                }
                catch( Exception ex )
                {
                    if( command?.Connection?.State == ConnectionState.Open )
                    {
                        command?.Connection?.Close();
                    }

                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name = "disposing" >
        /// <c>
        /// true
        /// </c>
        /// to release both managed and unmanaged resources;
        /// <c>
        /// false
        /// </c>
        /// to release only unmanaged resources.
        /// </param>
        [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
        protected virtual void Dispose( bool disposing )
        {
            if( ConnectionFactory?.GetConnection() != null )
            {
                try
                {
                    ConnectionFactory?.GetConnection()?.Close();
                    ConnectionFactory?.GetConnection()?.Dispose();
                    IsDisposed = true;
                }
                catch( Exception ex )
                {
                    IsDisposed = false;
                    Fail( ex );
                }
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            try
            {
                Dispose( true );
                GC.SuppressFinalize( this );
            }
            catch( Exception ex )
            {
                IsDisposed = false;
                Fail( ex );
            }
        }
    }
}
