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
    }
}
