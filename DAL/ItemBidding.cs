using DAL.Helper;
using DAL.Interfaces;
using DTO.ItemBidding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemBidding : IItemBidding
    {
        public int BidNow(ItemBiddingIn inDTO)
        {
            IList<SqlParameter> sqlparam = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@ItemBiddingId", Value=inDTO.ItemBiddingId},
                new SqlParameter {ParameterName = "@UserId", Value=inDTO.UserId},
                new SqlParameter {ParameterName = "@IsAutoBidding", Value=inDTO.IsAutoBidding},
                new SqlParameter {ParameterName = "@BidPrice", Value=inDTO.BidPrice}
            };
            int rowaffected = SqlHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.StoredProcedure, "ProcessBidding", sqlparam);

            return rowaffected;
        }
    }
}
