using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Auction.DAL.Core
{
    public class DbManager
    {
        public DbConnection CreateConnection()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["provider"]);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["AUCTION"].ConnectionString;
            return connection;
        }
        public DbConnection CreateConnection(string connString)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["provider"]);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connString;
            return connection;
        }
        public void CloseConnection(DbConnection connection)
        {
            connection.Close();
        }
        public DbDataAdapter CreateDataAdapter(DbConnection connection)
        {
            return DbProviderFactories.GetFactory(connection).CreateDataAdapter();
        }
        public DbCommandBuilder CreateDbCommandBuilder(DbConnection connection)
        {
            return DbProviderFactories.GetFactory(connection).CreateCommandBuilder();
        }
        public DbParameter CreateDbParameter(DbConnection connection)
        {
            return DbProviderFactories.GetFactory(connection).CreateParameter();
        }
        public DbCommand CreateDbCommand(IDbConnection connection)
        {
            return DbProviderFactories.GetFactory((DbConnection)connection).CreateCommand();
        }
        public DbCommand CreateDbCommand(IDbConnection connection, string commandText)
        {
            var command = CreateDbCommand(connection);
            command.Connection = (DbConnection)connection;
            command.CommandText = commandText;
            return command;
        }
        public DbParameter CreateParameter(string name, object value, DbType dbType)
        {
            return CreateParameter(name, 0, value, dbType, ParameterDirection.Input);
        }
        public DbParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return CreateParameter(name, size, value, dbType, ParameterDirection.Input);
        }
        public DbParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            DbParameter parameter = CreateDbParameter(CreateConnection());
            parameter.DbType = dbType;
            parameter.ParameterName = name;
            parameter.Size = size;
            parameter.Direction = direction;
            parameter.Value = value;
            return parameter;
        }
        public DbDataReader GetDataReader(string commandText, IEnumerable<IDbDataParameter> parameters)
        {
            DbDataReader reader = null;
            var connection = ConnectionManager.Get().GetConnection();

            try
            {
                connection.Open();

                var command = this.CreateDbCommand(connection, commandText);


                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DbDataReader GetDataReader(string commandText)
        {
            DbDataReader reader = null;
            try
            {
                var connection = ConnectionManager.Get().GetConnection();
                connection.Open();

                var command = this.CreateDbCommand(connection, commandText);

                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ExecuteNonQuery(string commandText, IEnumerable<IDbDataParameter> parameters)
        {
            using (var connection = ConnectionManager.Get().GetConnection())
            {
                connection.Open();

                using (var command = this.CreateDbCommand(connection, commandText))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ExecuteNonQuery(string commandText)
        {
            using (var connection = ConnectionManager.Get().GetConnection())
            {
                connection.Open();

                using (var command = this.CreateDbCommand(connection, commandText))
                {
                    command.ExecuteNonQuery();
                }
                ConnectionManager.CloseConnections();
            }
        }
        public object GetScalarValue(string commandText, IEnumerable<IDbDataParameter> parameters = null)
        {
            using (var connection = ConnectionManager.Get().GetConnection())
            {
                connection.Open();

                using (var command = this.CreateDbCommand(connection, commandText))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    return command.ExecuteScalar();
                }
            }
        }
    }
}