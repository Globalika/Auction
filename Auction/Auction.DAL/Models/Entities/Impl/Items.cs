using Auction.DAL.Models.Entities.Abstract;

namespace Auction.DAL.Models.Entities.Impl
{
    public class Items : IBaseEntity
    {
        public ulong Id { get; set; }
        public ulong Category_ID { get; set; }
        public ulong Seller_ID { get; set; }
        public ulong Buyer_ID { get; set; }
        public int Start_Bid { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nCategory_ID: {1} \nSeller_ID: {2} \nBuyer_ID: {3} \nStart_Bid: {4}",
                Id, Category_ID, Seller_ID, Buyer_ID, Start_Bid);
        }
    }
}
