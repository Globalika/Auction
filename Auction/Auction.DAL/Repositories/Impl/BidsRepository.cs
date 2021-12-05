using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Auction.DAL.Repositories.Abstract;

namespace Auction.DAL.Repositories.Impl
{
    public class BidsRepository : BasicRepository<Bids, BidsFilter>, IBidsRepository
    {
        internal static readonly string tableName = "tblBids";
        public BidsRepository() : base(tableName) { }
        //CRUD
        internal override Bids FillEntity(DbDataReader reader)
        {
            if (reader.HasRows == false)
            {
                return null;
            }
            try
            {
                Bids entity = new Bids();
                entity.Id = Convert.ToUInt64(reader["Id"]);
                entity.Bid_Item_ID = Convert.ToUInt64(reader["Bid_Item_ID"]);
                entity.Bid_Buyer_ID = Convert.ToUInt64(reader["Bid_Buyer_ID"]);
                entity.BidAmount = Convert.ToInt32(reader["BidAmount"]);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal override List<DbParameter> GetParameters(BidsFilter filter, string prefix = "")
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
                if (filter.Bid_Item_ID != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Bid_Item_ID", 50, filter.Bid_Item_ID, DbType.Int64));
                }
                if (filter.Bid_Buyer_ID != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Bid_Buyer_ID", 50, filter.Bid_Buyer_ID, DbType.Int64));
                }
                if (filter.BidAmount != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "BidAmount", 50, filter.BidAmount, DbType.Int32));
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal override List<DbParameter> GetParameters(Bids entity, string prefix = "")
        {
            return GetParameters(EntityToFilter(entity), prefix);
        }
        internal override List<string> GetFilterValues(BidsFilter entity)
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
            if (entity.Bid_Item_ID != null)
            {
                valuesList.Add("Bid_Item_ID");
            }
            if (entity.Bid_Buyer_ID != null)
            {
                valuesList.Add("Bid_Buyer_ID");
            }
            if (entity.BidAmount != null)
            {
                valuesList.Add("BidAmount");
            }
            return valuesList;
        }
        internal override List<string> GetEntityValues(Bids entity)
        {
            return GetFilterValues(EntityToFilter(entity));
        }
    }
}
