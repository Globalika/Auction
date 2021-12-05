using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Auction.DAL.Repositories.Abstract;

namespace Auction.DAL.Repositories.Impl
{
    public class SellersRepository: BasicRepository<Sellers, SellersFilter>, ISellersRepository
    {
        internal static readonly string tableName = "tblSellers";
        public SellersRepository() : base(tableName) { }
        //CRUD
        internal override Sellers FillEntity(DbDataReader reader)
        {
            if (reader.HasRows == false)
            {
                return null;
            }
            try
            {
                Sellers entity = new Sellers();
                entity.Id = Convert.ToUInt64(reader["Id"]);
                entity.Sellers_Email = reader["Sellers_Email"].ToString();
                entity.Sellers_Password = reader["Sellers_Password"].ToString();
                entity.Sellers_Username = reader["Sellers_Username"].ToString();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal override List<DbParameter> GetParameters(SellersFilter filter, string prefix = "")
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
                if (filter.Sellers_Email != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Sellers_Email", 50, filter.Sellers_Email, DbType.String));
                }
                if (filter.Sellers_Password != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Sellers_Password", 50, filter.Sellers_Password, DbType.String));
                }
                if (filter.Sellers_Username != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Sellers_Username", 50, filter.Sellers_Username, DbType.String));
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal override List<DbParameter> GetParameters(Sellers entity, string prefix = "")
        {
            return GetParameters(EntityToFilter(entity), prefix);
        }
        internal override List<string> GetFilterValues(SellersFilter entity)
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
            if (entity.Sellers_Email != null)
            {
                valuesList.Add("Sellers_Email");
            }
            if (entity.Sellers_Password != null)
            {
                valuesList.Add("Sellers_Password");
            }
            if (entity.Sellers_Username != null)
            {
                valuesList.Add("Sellers_Username");
            }
            return valuesList;
        }
        internal override List<string> GetEntityValues(Sellers entity)
        {
            return GetFilterValues(EntityToFilter(entity));
        }
    }
}
