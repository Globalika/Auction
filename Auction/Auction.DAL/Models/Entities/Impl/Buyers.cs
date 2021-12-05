using Auction.DAL.Models.Entities.Abstract;

namespace Auction.DAL.Models.Entities.Impl
{
    public class Buyers : IBaseEntity
    {
        public ulong Id { get; set; }
        public string Buyers_Username { get; set; }
        public string Buyers_Password { get; set; }
        public string Buyers_Email { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nBuyers_Username: {1} \nBuyers_Password: {2} \nBuyers_Email: {3}",
                Id, Buyers_Username, Buyers_Password, Buyers_Email);
        }
    }
}
