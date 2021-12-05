using AutoMapper;
using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;

namespace Auction.DAL.Models
{
    public sealed class ObjectsMapper
    {
        private volatile static IMapper mapper = null;
        private static MapperConfiguration config = null;
        public static IMapper Get()
        {
            if (mapper == null)
            {
                if (config == null)
                {
                    return ConfigMapper().CreateMapper();
                }
            }
            return config.CreateMapper();
        }
        private static MapperConfiguration ConfigMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bids, BidsFilter>();
                cfg.CreateMap<BidsTobuyer, BidsToBuyerFilter>();
                cfg.CreateMap<Buyers, BuyersFilter>();
                cfg.CreateMap<Categories, CategoriesFilter>();
                cfg.CreateMap<Items, ItemsFilter>();
                cfg.CreateMap<Photos, PhotosFilter>();
                cfg.CreateMap<Sellers, SellersFilter>();
            });
            return config;
        }
    }
}
