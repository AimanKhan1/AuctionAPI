using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("ItemBidding")]
    public class ItemBiddingModel
    {
        [Key]
        public int ItemBiddingId { get; set; }
        public int ItemId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal CurrentPrice { get; set; }
        public bool IsBidding { get; set; }
        public int Status { get; set; }

    }
}
