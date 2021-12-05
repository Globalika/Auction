using Auction.DAL.Models.Filters.Abstract;

namespace Auction.DAL.Models.Filters.Impl
{
    public class BidsFilter : IFilterable
    {
        public ulong? Id { get; set; }
        public ulong? Bid_Item_ID { get; set; }
        public ulong? Bid_Buyer_ID { get; set; }
        public int? BidAmount { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nBid_Item_ID: {1} \nBid_Buyer_ID: {2}  \nBidAmount: {3}",
                Id, Bid_Item_ID, Bid_Buyer_ID, BidAmount);
        }
    }
}
