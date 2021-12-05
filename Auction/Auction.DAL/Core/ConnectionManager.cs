using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Auction.DAL.Core
{
    public sealed class ConnectionManager
    {
        private static volatile ConnectionManager instance = null;
        private DbProviderFactory factory = null;
        private string connectionString;

        private ConnectionManager(string connectionString)
        {
            this.factory = DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["provider"]);
            this.connectionString = connectionString;
        }

        public static ConnectionManager Get()
        {
            return Get(null);
        }

        public static ConnectionManager Get(string connectionString)
        {
            if (instance == null)
            {
                lock (typeof(ConnectionManager))
                {
                    if (instance == null)
                    {
                        if (connectionString == null)
                        {
                            connectionString = ConfigurationManager.ConnectionStrings["AUCTION"].ConnectionString;
                        }
                        instance = new ConnectionManager(connectionString);
                    }
                }
            }
            return instance;
        }

        public static void CloseConnections()
        {
            List<int> connectionsToClose = new List<int>();
            DbConnection connection;

            connection = (DbConnection)Get().GetConnection();

            if ((connection != null))
            {
                connection.Close();
            }
        }

        public IDbConnection GetConnection()
        {
            DbConnection connection;
            connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}
