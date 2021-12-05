using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Auction.DAL.Repositories.Abstract;

namespace Auction.DAL.Repositories.Impl
{
    public class ItemsRepository: BasicRepository<Items, ItemsFilter>, IItemsRepository
    {
        internal static readonly string tableName = "tblItems";
        public ItemsRepository() : base(tableName) { }
        //CRUD
        internal override Items FillEntity(DbDataReader reader)
        {
            if (reader.HasRows == false)
            {
                return null;
            }
            try
            {
                Items entity = new Items();
                entity.Id = Convert.ToUInt64(reader["Id"]);
                entity.Seller_ID = Convert.ToUInt64(reader["Seller_ID"]);
                entity.Category_ID = Convert.ToUInt64(reader["Category_ID"]);
                entity.Start_Bid = Convert.ToInt32(reader["Start_Bid"]);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal override List<DbParameter> GetParameters(ItemsFilter filter, string prefix = "")
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
                if (filter.Seller_ID != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Seller_ID", 50, filter.Seller_ID, DbType.Int64));
                }
                if (filter.Category_ID != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Category_ID", 50, filter.Category_ID, DbType.Int64));
                }
                if (filter.Start_Bid != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Start_Bid", 50, filter.Start_Bid, DbType.Int32));
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal override List<DbParameter> GetParameters(Items entity, string prefix = "")
        {
            return GetParameters(EntityToFilter(entity), prefix);
        }
        internal override List<string> GetFilterValues(ItemsFilter entity)
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
            if (entity.Seller_ID != null)
            {
                valuesList.Add("Seller_ID");
            }
            if (entity.Category_ID != null)
            {
                valuesList.Add("Category_ID");
            }
            if (entity.Start_Bid != null)
            {
                valuesList.Add("Start_Bid");
            }
            return valuesList;
        }
        internal override List<string> GetEntityValues(Items entity)
        {
            return GetFilterValues(EntityToFilter(entity));
        }
    }
}
