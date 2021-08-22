using DTO.ItemBiddingHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IItemBiddingHistory
    {
        /// <summary>
        /// Get List Of Item Bidding History
        /// </summary>
        /// <param name="itemBiddingId"></param>
        /// <returns></returns>
        List<ItemBiddingHstoryOut> GetHistory(int itemBiddingId);
    }
}
