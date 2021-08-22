using DAL.Helper;
using DAL.Interfaces;
using DTO.Common;
using DTO.ItemBiddingHistory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemBiddingHistory : IItemBiddingHistory
    {

        /// <summary>
        /// Get List Of Item Bidding History
        /// </summary>
        /// <param name="itemBiddingId"></param>
        /// <returns></returns>
        public List<ItemBiddingHstoryOut> GetHistory(int itemBiddingId)
        {
            IList<SqlParameter> sqlparam = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@ItemBiddingId", Value=itemBiddingId}
            };
            var dataTable = SqlHelper.ExecuteTable(DBConnection.connectionString, CommandType.StoredProcedure, "GetItemBiddingHistory", sqlparam);

            List<ItemBiddingHstoryOut> history = null;
            if (dataTable.Rows.Count > 0)
            {
                history = new List<ItemBiddingHstoryOut>();
                IEnumerable<DataRow> dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
                history.AddRange(dataRows
                    .Select(item => new ItemBiddingHstoryOut
                    {
                        ItemName = Validate.CheckStringNull(item["ItemName"]),
                        UserName = Validate.CheckStringNull(((UserEnum.User)item["UserId"]).ToString()),
                        ItemBiddingId = Validate.CheckIntegerNull(item["ItemBiddingId"]),
                        BidPrice = Validate.CheckDecimalNull(item["BidPrice"]),
                        BidTime = Validate.CheckDateTimeNull(item["BidTime"])
                    }));

            }
            return history;
        }

    }
}
