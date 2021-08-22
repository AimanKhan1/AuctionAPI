using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AutoBiddingAmount : IAutoBiddingAmount
    {
        #region Private Variables
        private readonly DAL.Interfaces.IAutoBiddingAmount _dalAutoBiddingAmount;
        #endregion

        #region Class Constructor
        public AutoBiddingAmount(DAL.Interfaces.IAutoBiddingAmount dalAutoBiddingAmount)
        {
            _dalAutoBiddingAmount = dalAutoBiddingAmount;
        }
        #endregion
        public decimal GetAutoBidAmount(int userId)
        {
            return _dalAutoBiddingAmount.GetAutoBidAmount(userId);
        }

        public int SaveAutoBidAmount(int userId, decimal maxBidAmount)
        {
            return _dalAutoBiddingAmount.SaveAutoBidAmount(userId, maxBidAmount);
        }
    }
}
