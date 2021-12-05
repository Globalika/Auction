using System.Collections.Generic;

namespace Auction.DAL.Repositories.Abstract
{
    public interface IBaseRepository<TEntity, TFilter>
    {
        TEntity Get(TFilter filter = default(TFilter));

        IEnumerable<TEntity> GetAll(TFilter filter = default(TFilter));

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity, TFilter filter = default(TFilter));

        bool Delete(TFilter filter = default(TFilter));
    }
}