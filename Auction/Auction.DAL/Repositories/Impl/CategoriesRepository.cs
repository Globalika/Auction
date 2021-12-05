using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Auction.DAL.Repositories.Abstract;

namespace Auction.DAL.Repositories.Impl
{
    public class CategoriesRepository: BasicRepository<Categories, CategoriesFilter>, ICategoriesRepository
    {
        internal static readonly string tableName = "tblCategories";
        public CategoriesRepository() : base(tableName) { }
        //CRUD
        internal override Categories FillEntity(DbDataReader reader)
        {
            if (reader.HasRows == false)
            {
                return null;
            }
            try
            {
                Categories entity = new Categories();
                entity.Id = Convert.ToUInt64(reader["Id"]);
                entity.Category = reader["Category"].ToString();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal override List<DbParameter> GetParameters(CategoriesFilter filter, string prefix = "")
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
                if (filter.Category != null)
                {
                    parameters.Add(dbManager.CreateParameter(prefix + "Category", 50, filter.Category, DbType.String));
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal override List<DbParameter> GetParameters(Categories entity, string prefix = "")
        {
            return GetParameters(EntityToFilter(entity), prefix);
        }
        internal override List<string> GetFilterValues(CategoriesFilter entity)
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
            if (entity.Category != null)
            {
                valuesList.Add("Category");
            }
            return valuesList;
        }
        internal override List<string> GetEntityValues(Categories entity)
        {
            return GetFilterValues(EntityToFilter(entity));
        }
    }
}
