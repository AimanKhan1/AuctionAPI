using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.item
{
    public class ItemIn
    {
        //public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool Order { get; set; }
    }
}
