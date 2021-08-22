using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("AutoBiddingAmount")]
    public class AutoBiddingAmountModel
    {
        [Key]
        public int AutoBiddingAmountId { get; set; }
        public int UserId { get; set; }
        public decimal MaxBidAmount { get; set; }
    }
}
