using BLL.Interfaces;
using DTO.ItemBidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemBidding : IItemBidding
    {
        #region Private Variables
        private readonly DAL.Interfaces.IItemBidding _dalItemBidding;
        private readonly DAL.Interfaces.IAutoBiddingBot _dalAutoBiddingBot;
        #endregion

        #region Class Constructor
        public ItemBidding(DAL.Interfaces.IItemBidding dalItemBidding,
            DAL.Interfaces.IAutoBiddingBot dalAutoBiddingBot)
        {
            _dalItemBidding = dalItemBidding;
            _dalAutoBiddingBot = dalAutoBiddingBot;
        }
        #endregion
        public async Task<int> BidNow(ItemBiddingIn inDTO)
        {
            int result = _dalItemBidding.BidNow(inDTO);
            if (result > 0)
            {
                await Task.Run(() => _dalAutoBiddingBot.ProcessAutoBidding(inDTO.UserId, inDTO.ItemBiddingId));
            }
            return result;
        }
    }
}
