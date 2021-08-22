using DTO.ItemBiddingHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IItemBiddingHistory
    {

        /// <summary>
        /// Get Item Bidding Hostory
        /// </summary>
        /// <param name="itemBiddingId"></param>
        /// <returns></returns>
        List<ItemBiddingHstoryOut> GetItemBiddingHistory(int itemBiddingId);
    }
}
