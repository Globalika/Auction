using Auction.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auction.FormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MigrationManager migration = new MigrationManager();
            migration.DropTables();
            migration.CreateTables();
            migration.ImportStartValues();
            migration.AddTriggers();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ItemsManagerFrom());
        }
    }
}
