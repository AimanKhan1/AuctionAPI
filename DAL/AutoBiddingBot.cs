using DAL.Helper;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AutoBiddingBot : IAutoBiddingBot
    {
        private readonly AppDBContext context;

        public AutoBiddingBot(AppDBContext context)
        {
            this.context = context;
        }
        public async Task ProcessAutoBidding(int userId, int itemBiddingId)
        {
            var autoBiddings = await context.AutoBidding.Where(x => x.IsAutoBidding == true).ToListAsync();
            //checking for other users that have autobidding ON
            var users = autoBiddings?.Where(x => x.UserId != userId & x.ItemBiddingId == itemBiddingId).Select(y => y.UserId).ToList();
            if (users != null && users.Count > 0)
            {
                int autoBiddingItemCount;
                decimal maxBidAmount;
                decimal bidAmount;
                decimal itemCurrentPrice;

                foreach (var bidderId in users)
                {
                    maxBidAmount = context.AutoBiddingAmount.Where(x => x.UserId == bidderId).FirstOrDefault().MaxBidAmount;
                    autoBiddingItemCount = autoBiddings.Where(x => x.UserId == bidderId).Count();

                    //spliting amount between all items where we have activated auto-bidding
                    bidAmount = maxBidAmount / autoBiddingItemCount;
                    itemCurrentPrice = context.ItemBidding.Where(x => x.ItemBiddingId == itemBiddingId).FirstOrDefault().CurrentPrice;

                    if (bidAmount > 0 && bidAmount > itemCurrentPrice)
                    {
                        MakeBiddingHistory(bidderId, itemBiddingId, itemCurrentPrice + 1);
                        UpdateItemPrice(itemBiddingId);
                        UpdateAutoBiddingAmount(bidderId);
                        context.SaveChanges();

                        //Recurcive call to fix concurrency issues with auto-bidding!
                        await ProcessAutoBidding(bidderId, itemBiddingId);
                    }
                    else
                    {
                        //When there is not enough funds anymore, the auto-bidding will stop
                        StopAutoBidding(bidderId);
                    }
                }
            }
        }

        private void StopAutoBidding(int userId)
        {
            var bidding = context.AutoBidding.Where(x => x.UserId == userId).FirstOrDefault();
            if (bidding != null)
            {
                bidding.IsAutoBidding = false;
                context.SaveChanges();
            }
        }

        private void UpdateAutoBiddingAmount(int userId)
        {
            var bidAmount = context.AutoBiddingAmount.Where(x => x.UserId == userId).FirstOrDefault();
            if (bidAmount != null)
                bidAmount.MaxBidAmount = bidAmount.MaxBidAmount - 1;
        }

        private void MakeBiddingHistory(int userId, int itemBiddingId, decimal bidPrice)
        {
            context.ItemBiddingHistory.Add(
                new ItemBiddingHistoryModel()
                {
                    ItemBiddingId = itemBiddingId,
                    UserId = userId,
                    BidPrice = bidPrice,
                    BidTime = DateTime.Now
                });
        }

        private void UpdateItemPrice(int itemBiddingId)
        {
            var item = context.ItemBidding.Where(x => x.ItemBiddingId == itemBiddingId).FirstOrDefault();
            if (item != null)
                item.CurrentPrice = item.CurrentPrice + 1;

        }
    }
}
