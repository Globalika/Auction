using Auction.DAL.Models.Entities.Abstract;

namespace Auction.DAL.Models.Entities.Impl
{
    public class Photos : IBaseEntity
    {
        public ulong Id { get; set; }
        public string Photo_Path { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} \nPhoto_Path: {1}",
                Id, Photo_Path);
        }
    }
}
