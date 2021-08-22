using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ItemBiddingHistory
{
    public class ItemBiddingHstoryOut
    {
        public int ItemBiddingId { get; set; }
        public string ItemName { get; set; }
        public string UserName { get; set; }
        public decimal BidPrice { get; set; }
        public DateTime BidTime { get; set; }
    }
}
