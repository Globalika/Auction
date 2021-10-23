using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Database;

namespace Auction.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            string coString = "Data Source=localhost;Initial Catalog=AUCTION;Integrated Security=True";
            MigrationManager migrationManager = new MigrationManager(coString);
            migrationManager.DropTables();
            migrationManager.CreateTables();
            migrationManager.ImportStartValues();

        }
    }
}
