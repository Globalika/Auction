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
        //CRUD
        internal override Photos FillEntity(DbDataReader reader)
        {
            if (reader.HasRows == false)
            {
                return null;
            }
            try
            {
                Photos entity = new Photos();
                entity.Id = Convert.ToUInt64(reader["Id"]);
                entity.Photo_Path = reader["Category"].ToString();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal override List<DbParameter> GetParameters(PhotosFilter filter, string prefix = "")
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
                if (filter.Photo_Path != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Photo_Path", 50, filter.Photo_Path, DbType.String));
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal override List<DbParameter> GetParameters(Photos entity, string prefix = "")
        {
            return GetParameters(EntityToFilter(entity), prefix);
        }
        internal override List<string> GetFilterValues(PhotosFilter entity)
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
            if (entity.Photo_Path != null)
            {
                valuesList.Add("Photo_Path");
            }
            return valuesList;
        }
        internal override List<string> GetEntityValues(Photos entity)
        {
            return GetFilterValues(EntityToFilter(entity));
        }
    }
}
