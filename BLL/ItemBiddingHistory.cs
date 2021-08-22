using BLL.Interfaces;
using DTO.ItemBiddingHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemBiddingHistory : IItemBiddingHistory
    {
        #region Private Variables
        private readonly DAL.Interfaces.IItemBiddingHistory _dalItemBiddingHstory;
        #endregion

        #region Class Constructor
        public ItemBiddingHistory(DAL.Interfaces.IItemBiddingHistory dalItemBiddingHstory)
        {
            _dalItemBiddingHstory = dalItemBiddingHstory;
        }
        #endregion
        public List<ItemBiddingHstoryOut> GetItemBiddingHistory(int itemBiddingId)
        {
            return _dalItemBiddingHstory.GetHistory(itemBiddingId);
        }
    }
}
