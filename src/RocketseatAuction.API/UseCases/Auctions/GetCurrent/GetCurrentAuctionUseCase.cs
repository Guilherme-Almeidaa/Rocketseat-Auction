using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        public Auction? Execute()
        {
            var respository = new RocketseatAuctionDbContext();
            var today = DateTime.Now;
            return respository
                .Auctions
                .Include(Auction =>  Auction.Items)
                .FirstOrDefault(auction =>  today >= auction.Starts && today <= auction.Ends);
        }
    }
}
