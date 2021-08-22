using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("AutoBidding")]
    public class AutoBiddingModel
    {
        [Key]
        public int AutoBiddingId { get; set; }
        public int ItemBiddingId { get; set; }
        public int UserId { get; set; }
        public bool IsAutoBidding { get; set; }
    }
}
