using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAutoBiddingAmount
    {
        decimal GetAutoBidAmount(int userId);
        int SaveAutoBidAmount(int userId, decimal maxBidAmount);
    }
}
