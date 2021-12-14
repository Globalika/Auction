using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.DAL.Core
{
    public class DbCommandManager
    {
        private readonly string _tableName;

        public DbCommandManager(string _tableName)
        {
            this._tableName = _tableName;
        }

        public string GetInsertCommand(List<string> entity)
        {
            string command = string.Format("Insert into {0} " +
                "( {1} ) " +
                "values " +
                "( {2} );",
                _tableName,
                entity.Aggregate((a, b) => a + ", " + b),
                string.Format("@" + entity.Aggregate((a, b) => a + ", @" + b)));

            return command;
        }
        public string GetUpdateCommand(List<string> entity, List<string> filter, string prefix = "")
        {
            string values = "";
            string condition = "";
            string command = "";

            if (entity != null && entity.Count > 0)
            {
                values = string.Format("{0}",
                    string.Format(entity[0] + " = @") + entity.Aggregate((a, b) => a + ", " + b + " = @" + b));
            }
            if (filter != null && filter.Count > 0)
            {
                condition = string.Format("Where {0}",
                    string.Format(filter[0] + " = @" + prefix) + filter.Aggregate((a, b) => a + " AND " + b + " = @" + prefix + b));
            }
            else
            {
                throw new Exception("No conditons for \"SET\" querry!");
            }

            command = string.Format("Update {0} " +
                    "Set " +
                    "{1} " +
                    " output inserted.Id " +
                    "{2} " +
                    ";", _tableName, values, condition);

            return command;
        }
        public string GetSellectCommand(List<string> filter)
        {
            string condition = "";
            string command = "";

            if (filter != null && filter.Count > 0)
            {
                condition = string.Format("Where {0}",
                    string.Format(filter[0] + " = @") + filter.Aggregate((a, b) => a + " AND " + b + " = @" + b));
            }

            command = string.Format("select * from {0} {1};", _tableName, condition);

            return command;
        }
        public string GetSellectAllCommand(List<string> filter)
        {
            string condition = "";
            string command = "";

            if (filter != null && filter.Count > 0)
            {
                condition = string.Format("Where {0}",
                    string.Format(filter[0] + " = @") + filter.Aggregate((a, b) => a + " AND " + b + " = @" + b));
            }

            command = string.Format("select * from {0} {1};", _tableName, condition);

            return command;
        }

        public string GetDeleteCommand(List<string> filter)
        {
            string condition = "";
            string command = "";

            if (filter != null && filter.Count > 0)
            {
                condition = string.Format("Where {0}",
                    string.Format(filter[0] + " = @") + filter.Aggregate((a, b) => a + " AND " + b + " = @" + b));
            }

            command = string.Format("Delete from {0} " +
                "output deleted.Id " +
                "{1} ;", _tableName, condition);

            return command;
        }
    }
}
