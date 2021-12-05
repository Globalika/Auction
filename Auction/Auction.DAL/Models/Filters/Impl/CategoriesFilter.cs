using Auction.DAL.Models.Filters.Abstract;

namespace Auction.DAL.Models.Filters.Impl
{
    public class CategoriesFilter : IFilterable
    {
        public ulong? Id { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nCategory: {1}",
                Id, Category);
        }
    }
}
