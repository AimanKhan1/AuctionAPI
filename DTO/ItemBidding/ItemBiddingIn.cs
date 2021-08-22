using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ItemBidding
{
    public class ItemBiddingIn
    {
        [Required]
        public int ItemBiddingId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public decimal BidPrice { get; set; }
        [Required]
        public bool IsAutoBidding { get; set; }
    }
}
