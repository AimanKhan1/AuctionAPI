using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("ItemBiddingHistory")]
    public class ItemBiddingHistoryModel
    {
        [Key]
        public int ItemBiddingHistoryId { get; set; }
        public int ItemBiddingId { get; set; }
        public int UserId { get; set; }
        public decimal BidPrice { get; set; }
        public DateTime BidTime { get; set; }

    }
}
