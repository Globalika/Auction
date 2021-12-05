using System;
using System.Collections.Generic;
using System.Data.Common;
using Auction.DAL.Core;
using Auction.DAL.Models.Entities.Abstract;
using Auction.DAL.Models.Filters.Abstract;
using Auction.DAL.Repositories.Abstract;
using Auction.DAL.Models;

namespace Auction.DAL.Repositories
{
    public abstract class BasicRepository<TEntity, TFilter> : IBaseRepository<TEntity, TFilter>
        where TEntity : IBaseEntity, new()
        where TFilter : IFilterable, new()
    {
        internal readonly string _tableName;
        internal DbManager dbManager;
        internal DbCommandManager commandBuilder;

        public BasicRepository(string tableName)
        {
            _tableName = tableName;
            commandBuilder = new DbCommandManager(_tableName);
            dbManager = new DbManager();
        }

        public TEntity Create(TEntity entity)
        {
            TFilter noIndexEntity = EntityToFilter(entity);
            noIndexEntity.Id = null;

            string commandText = commandBuilder.GetInsertCommand(GetFilterValues(noIndexEntity));
            var parameters = GetParameters(noIndexEntity);

            try
            {
                entity.Id = Convert.ToUInt64(dbManager.GetScalarValue(commandText, parameters));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.CloseConnections();
            }
            return entity;
        }

        public TEntity Update(TEntity entity, TFilter filter = default(TFilter))
        {
            TFilter noIndexEntity = EntityToFilter(entity);
            noIndexEntity.Id = null;

            string commandText = commandBuilder.GetUpdateCommand(GetFilterValues(noIndexEntity), GetFilterValues(filter), "Filter");

            var parametersEntity = GetParameters(entity);
            var parametersFilter = GetParameters(filter, "Filter");

            List<DbParameter> parameters = new List<DbParameter>();
            parameters.AddRange(parametersEntity);
            parameters.AddRange(parametersFilter);

            try
            {
                entity.Id = Convert.ToUInt64(dbManager.GetScalarValue(commandText, parameters));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.CloseConnections();
            }
            return entity;
        }

        public bool Delete(TFilter filter = default(TFilter))
        {
            string commandText = commandBuilder.GetDeleteCommand(GetFilterValues(filter));

            var parameters = GetParameters(filter);

            try
            {
                ulong deletedId = Convert.ToUInt64(dbManager.GetScalarValue(commandText, parameters));

                if (deletedId != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.CloseConnections();
            }
        }

        public TEntity Get(TFilter filter = default(TFilter))
        {
            string commandText = commandBuilder.GetSellectCommand(GetFilterValues(filter));
            var parameters = GetParameters(filter);

            using (var reader = dbManager.GetDataReader(commandText, parameters))
            {
                TEntity entity = new TEntity();
                if (reader.IsClosed)
                {
                    return entity;
                }

                reader.Read();
                ConnectionManager.CloseConnections();
                entity = FillEntity(reader);

                return entity;
            }
        }

        public IEnumerable<TEntity> GetAll(TFilter filter = default(TFilter))
        {
            string commandText = commandBuilder.GetSellectAllCommand(GetFilterValues(filter));
            var parameters = GetParameters(filter);

            List<TEntity> entities = new List<TEntity>();
            TEntity entity = new TEntity();

            using (var reader = dbManager.GetDataReader(commandText, parameters))
            {

                if (reader.IsClosed)
                {
                    return entities;
                }

                while (reader.Read())
                {
                    entity = FillEntity(reader);
                    entities.Add(entity);
                }
                ConnectionManager.CloseConnections();
                return entities;
            }
        }
        virtual internal TEntity FillEntity(DbDataReader reader)
        {
            return new TEntity();
        }
        virtual internal List<string> GetFilterValues(TFilter filter)
        {
            return new List<string>();
        }
        virtual internal List<string> GetEntityValues(TEntity entity)
        {
            return new List<string>();
        }
        virtual internal List<DbParameter> GetParameters(TFilter filter, string prefix = "")
        {
            return new List<DbParameter>();
        }
        virtual internal List<DbParameter> GetParameters(TEntity entity, string prefix = "")
        {
            return new List<DbParameter>();
        }
        virtual internal TFilter EntityToFilter(TEntity entity)
        {
            return ObjectsMapper.Get().Map<TEntity, TFilter>(entity);
            //return new TFilter();
        }
    }
}
