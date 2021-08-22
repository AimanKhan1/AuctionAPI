using DTO.ItemBidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IItemBidding
    {
        Task<int> BidNow(ItemBiddingIn inDTO);
    }

}
