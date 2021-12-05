using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Auction.DAL.Repositories.Abstract;

namespace Auction.DAL.Repositories.Impl
{
    public class BidsToBuyerRepository: BasicRepository<BidsTobuyer, BidsToBuyerFilter>, IBidsToBuyerRepository
    {
        internal static readonly string tableName = "tblBidsToBuyer";
        public BidsToBuyerRepository() : base(tableName) { }
        //CRUD
        internal override BidsTobuyer FillEntity(DbDataReader reader)
        {
            if (reader.HasRows == false)
            {
                return null;
            }
            try
            {
                BidsTobuyer entity = new BidsTobuyer();
                entity.Id = Convert.ToUInt64(reader["Id"]);
                entity.Bid_ID = Convert.ToUInt64(reader["Bid_ID"]);
                entity.Buyer_ID = Convert.ToUInt64(reader["Buyer_ID"]);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal override List<DbParameter> GetParameters(BidsToBuyerFilter filter, string prefix = "")
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
                if (filter.Bid_ID != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Bid_ID", 50, filter.Bid_ID, DbType.Int64));
                }
                if (filter.Buyer_ID != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Buyer_ID", 50, filter.Buyer_ID, DbType.Int64));
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal override List<DbParameter> GetParameters(BidsTobuyer entity, string prefix = "")
        {
            return GetParameters(EntityToFilter(entity), prefix);
        }
        internal override List<string> GetFilterValues(BidsToBuyerFilter entity)
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
            if (entity.Bid_ID != null)
            {
                valuesList.Add("Bid_ID");
            }
            if (entity.Buyer_ID != null)
            {
                valuesList.Add("Buyer_ID");
            }
            return valuesList;
        }
        internal override List<string> GetEntityValues(BidsTobuyer entity)
        {
            return GetFilterValues(EntityToFilter(entity));
        }
    }
}
