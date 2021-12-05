using Auction.DAL.Models.Filters.Abstract;

namespace Auction.DAL.Models.Filters.Impl
{
    public class SellersFilter : IFilterable
    {
        public ulong? Id { get; set; }
        public string Sellers_Username { get; set; }
        public string Sellers_Password { get; set; }
        public string Sellers_Email { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nSellers_Username: {1} \nSellers_Password: {2} \nSellers_Email: {3}",
                Id, Sellers_Username, Sellers_Password, Sellers_Email);
        }
    }
}
