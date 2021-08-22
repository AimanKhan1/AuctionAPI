using DAL.Helper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AutoBiddingAmount : IAutoBiddingAmount
    {
        public decimal GetAutoBidAmount(int userId)
        {
            IList<SqlParameter> sqlparam = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@UserId", Value=userId}
            };
            var row = SqlHelper.ExecuteRow(DBConnection.connectionString, CommandType.StoredProcedure, "GetAutoBiddingAmount", sqlparam);

            return row == null ? 0 : Validate.CheckDecimalNull(row["MaxBidAmount"]);
        }

        public int SaveAutoBidAmount(int userId, decimal maxBidAmount)
        {
            IList<SqlParameter> sqlparam = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@UserId", Value=userId},
                new SqlParameter {ParameterName = "@MaxBidAmount", Value=maxBidAmount}
            };

            return SqlHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.StoredProcedure, "SaveAutoBiddingAmount", sqlparam);
            
        }
    }
}
