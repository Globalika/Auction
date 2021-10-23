using System.Data.SqlClient;
using System.IO;

namespace Auction.DAL.Database
{
    public class MigrationManager
    {
        private string conStr;
        public MigrationManager (string coString)
        {
            conStr = coString;
        }
        public bool CreateTables()
        {
            string path = System.IO.Path.GetFullPath(@"..\..\..\Auction.DAL\Database\create_tables.sql");
            string script = File.ReadAllText(path);
            using (SqlConnection conn = new SqlConnection(this.conStr))
            using (SqlCommand command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = script;
                SqlDataReader reader = command.ExecuteReader();
            }
            return true;
        }
        public bool DropTables()
        {
            string path = System.IO.Path.GetFullPath(@"..\..\..\Auction.DAL\Database\drop_tables.sql");
            string script = File.ReadAllText(path);
            using (SqlConnection conn = new SqlConnection(this.conStr))
            using (SqlCommand command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = script;
                SqlDataReader reader = command.ExecuteReader();
            }
            return true;
        }

        public bool ImportStartValues()
        {
            string path = System.IO.Path.GetFullPath(@"..\..\..\Auction.DAL\Database\import_start_values.sql");
            string script = File.ReadAllText(path);
            using (SqlConnection conn = new SqlConnection(this.conStr))
            using (SqlCommand command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = script;
                SqlDataReader reader = command.ExecuteReader();
            }
            return true;
        }
    }
}
