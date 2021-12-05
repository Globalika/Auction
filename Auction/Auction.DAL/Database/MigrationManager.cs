using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Auction.DAL.Core;

namespace Auction.DAL.Database
{
    public class MigrationManager
    {
        DbManager dbManager = new DbManager();

        public bool CreateTables()
        {
            string path = System.IO.Path.GetFullPath(@"..\..\..\Auction.DAL\Database\create_tables.sql");
            string script = File.ReadAllText(path);
            dbManager.ExecuteNonQuery(script);
            return true;
        }
        public bool DropTables()
        {
            string path = System.IO.Path.GetFullPath(@"..\..\..\Auction.DAL\Database\drop_tables.sql");

            string script = File.ReadAllText(path);
            dbManager.ExecuteNonQuery(script);
            return true;
        }

        public bool ImportStartValues()
        {
            string path = System.IO.Path.GetFullPath(@"..\..\..\Auction.DAL\Database\import_start_values.sql");
            string script = File.ReadAllText(path);
            dbManager.ExecuteNonQuery(script);
            return true;
        }
    }
}
