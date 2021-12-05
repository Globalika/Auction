using Auction.DAL.Models.Filters.Abstract;

namespace Auction.DAL.Models.Filters.Impl
{
    public class PhotosFilter : IFilterable
    {
        public ulong? Id { get; set; }
        public string Photo_Path { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nPhoto_Path: {1}",
                Id, Photo_Path);
        }
    }
}
