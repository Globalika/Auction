using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Auction.DAL.Repositories.Abstract;

namespace Auction.DAL.Repositories.Impl
{
    public class BuyersRepository: BasicRepository<Buyers, BuyersFilter>, IBuyersRepository
    {
        internal static readonly string tableName = "tblBuyers";
        public BuyersRepository() : base(tableName) { }
        //CRUD
        internal override Buyers FillEntity(DbDataReader reader)
        {
            if (reader.HasRows == false)
            {
                return null;
            }
            try
            {
                Buyers entity = new Buyers();
                entity.Id = Convert.ToUInt64(reader["Id"]);
                entity.Buyers_Email = reader["Buyers_Email"].ToString();
                entity.Buyers_Password = reader["Buyers_Password"].ToString();
                entity.Buyers_Username = reader["Buyers_Username"].ToString();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal override List<DbParameter> GetParameters(BuyersFilter filter, string prefix = "")
        {
            if (filter == null)
            {
                return new List<DbParameter>();
            }
            try
            {
                prefix = "@" + prefix;
                List<DbParameter> parameters = new List<DbParameter>();
                if (filter.Id != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Id", filter.Id, DbType.Int64));
                }
                if (filter.Buyers_Email != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Buyers_Email", 50, filter.Buyers_Email, DbType.String));
                }
                if (filter.Buyers_Password != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Buyers_Password", 50, filter.Buyers_Password, DbType.String));
                }
                if (filter.Buyers_Username != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Buyers_Username", 50, filter.Buyers_Username, DbType.String));
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal override List<DbParameter> GetParameters(Buyers entity, string prefix = "")
        {
            return GetParameters(EntityToFilter(entity), prefix);
        }
        internal override List<string> GetFilterValues(BuyersFilter entity)
        {
            if (entity == null)
            {
                return new List<string>();
            }
            List<string> valuesList = new List<string>();

            if (entity.Id != null)
            {
                valuesList.Add("Id");
            }
            if (entity.Buyers_Email != null)
            {
                valuesList.Add("Buyers_Email");
            }
            if (entity.Buyers_Password != null)
            {
                valuesList.Add("Buyers_Password");
            }
            if (entity.Buyers_Username != null)
            {
                valuesList.Add("Buyers_Username");
            }
            return valuesList;
        }
        internal override List<string> GetEntityValues(Buyers entity)
        {
            return GetFilterValues(EntityToFilter(entity));
        }
    }
}
