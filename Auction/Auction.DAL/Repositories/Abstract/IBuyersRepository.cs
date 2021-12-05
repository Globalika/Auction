using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;

namespace Auction.DAL.Repositories.Abstract
{
    public interface IBuyersRepository : IBaseRepository<Buyers, BuyersFilter>
    {
    }
}
