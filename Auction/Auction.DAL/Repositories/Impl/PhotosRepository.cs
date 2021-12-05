using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Auction.DAL.Repositories.Abstract;

namespace Auction.DAL.Repositories.Impl
{
    public class PhotosRepository: BasicRepository<Photos, PhotosFilter>, IPhotosRepository
    {
        internal static readonly string tableName = "tblPhotos";
        public PhotosRepository() : base(tableName) { }
    }
}
