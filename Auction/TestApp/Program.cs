using Auction.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Repositories.Impl;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MigrationManager migrationManager = new MigrationManager();
            migrationManager.DropTables();
            migrationManager.CreateTables();
            migrationManager.ImportStartValues();

            ItemsRepository gg = new ItemsRepository();
            foreach(var hh in gg.GetAll())
            {
                Console.WriteLine(hh.Id);
            }

        }
    }
}
