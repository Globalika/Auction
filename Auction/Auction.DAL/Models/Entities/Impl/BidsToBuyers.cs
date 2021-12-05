using Auction.DAL.Models.Entities.Abstract;

namespace Auction.DAL.Models.Entities.Impl
{
    public class BidsTobuyer : IBaseEntity
    {
        public ulong Id { get; set; }
        public ulong Buyer_ID { get; set; }
        public ulong Bid_ID { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nBuyer_ID: {1} \nBid_ID: {2}",
                Id, Buyer_ID, Bid_ID);
        }
    }
}
