using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Helper
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<ItemBiddingModel> ItemBidding { get; set; }
        public DbSet<AutoBiddingModel> AutoBidding { get; set; }
        public DbSet<AutoBiddingAmountModel> AutoBiddingAmount { get; set; }
        public DbSet<ItemBiddingHistoryModel> ItemBiddingHistory { get; set; }
    }
}
