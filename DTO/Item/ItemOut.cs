using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.item
{
    public class ItemOut
    {
        public int ItemId { get; set; }
        public int ItemBiddingId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal StatingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBidding { get; set; }
        public bool IsAutoBidding { get; set; }
        public int Count { get; set; }

    }
}
