using Auction.DAL.Models.Entities.Abstract;

namespace Auction.DAL.Models.Entities.Impl
{
    public class Categories : IBaseEntity
    {
        public ulong Id { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nCategory: {1}",
                Id, Category);
        }
    }
}
