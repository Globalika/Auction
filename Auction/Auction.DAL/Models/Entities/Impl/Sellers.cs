using Auction.DAL.Models.Entities.Abstract;

namespace Auction.DAL.Models.Entities.Impl
{
    public class Sellers : IBaseEntity
    {
        public ulong Id { get; set; }
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
