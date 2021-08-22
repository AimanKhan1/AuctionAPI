using DTO.ItemBidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IItemBidding
    {
        int BidNow(ItemBiddingIn inDTO);
    }
}
