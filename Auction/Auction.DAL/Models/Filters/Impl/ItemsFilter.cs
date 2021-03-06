using Auction.DAL.Models.Filters.Abstract;

namespace Auction.DAL.Models.Filters.Impl
{
    public class ItemsFilter : IFilterable
    {
        public ulong? Id { get; set; }
        public ulong? Category_ID { get; set; }
        public string ItemName { get; set; }
        public ulong? Seller_ID { get; set; }
        public ulong? Buyer_ID { get; set; }
        public int? Start_Bid { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nCategory_ID: {1} \nItemName: {2} \nSeller_ID: {2} \nBuyer_ID: {2} \nStart_Bid: {5}",
                Id, Category_ID, ItemName, Seller_ID, Buyer_ID, Start_Bid);
        }
    }
}
