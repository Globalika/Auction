using System;

namespace Auction.DAL.Models.Entities.Abstract
{
    public interface IBaseEntity
    {
        ulong Id { get; set; }
    }
}
