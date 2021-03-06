using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;

namespace Auction.DAL.Repositories.Abstract
{
    public interface IBidsRepository : IBaseRepository<Bids, BidsFilter>
    {
    }
}
