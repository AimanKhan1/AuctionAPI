﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoBiddingAmount
{
    public class AutoBiddingAmountIn
    {
        public int UserId { get; set; }
        public decimal MaxBidAmount { get; set; }
    }
}
