using DAL.Helper;
using DAL.Interfaces;
using DTO.item;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class Item : IItem
    {
        /// <summary>
        /// Get List Of Items
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public List<ItemOut> GetItems(ItemIn filters)
        {
            IList<SqlParameter> sqlparam = new List<SqlParameter>
            {
                //new SqlParameter {ParameterName = "@ItemId", Value=filters.ItemId},
                new SqlParameter {ParameterName = "@ItemName", Value=filters.ItemName},
                new SqlParameter {ParameterName = "@Description", Value=filters.Description},
                new SqlParameter {ParameterName = "@Skip", Value=filters.Skip},
                new SqlParameter {ParameterName = "@Take", Value=filters.Take},
                new SqlParameter {ParameterName = "@Order", Value=filters.Order}
            };
            var dataTable = SqlHelper.ExecuteTable(DBConnection.connectionString, CommandType.StoredProcedure, "GetItems", sqlparam);

            List<ItemOut> items = null;
            if (dataTable.Rows.Count > 0)
            {
                items = new List<ItemOut>();
                IEnumerable<DataRow> dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
                items.AddRange(dataRows
                    .Select(item => new ItemOut
                    {
                        ItemId = Validate.CheckIntegerNull(item["ItemId"]),
                        ItemName = Validate.CheckStringNull(item["ItemName"]),
                        Description = Validate.CheckStringNull(item["Description"]),
                        Image = Validate.CheckStringNull(item["Image"]),
                        ItemBiddingId = Validate.CheckIntegerNull(item["ItemBiddingId"]),
                        StatingPrice = Validate.CheckDecimalNull(item["StatingPrice"]),
                        CurrentPrice = Validate.CheckDecimalNull(item["CurrentPrice"]),
                        StartTime = Validate.CheckDateTimeNull(item["StartTime"]),
                        EndTime = Validate.CheckDateTimeNull(item["EndTime"]),
                        Count = Validate.CheckIntegerNull(item["Count"]),
                        IsBidding = Validate.CheckBooleanNull(item["IsBidding"])
                    }));

            }
            return items;
        }

        /// <summary>
        /// Get Item Details By Id
        /// </summary>
        /// <param name="itemBiddingId"></param>
        /// <returns></returns>
        public ItemOut GetItemById(int itemBiddingId)
        {
            IList<SqlParameter> sqlparam = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@ItemBiddingId", Value=itemBiddingId}
            };
            var row = SqlHelper.ExecuteRow(DBConnection.connectionString, CommandType.StoredProcedure, "GetItemById", sqlparam);

            ItemOut item = null;
            if (row != null)
            {
                item = new ItemOut
                {
                    ItemId = Validate.CheckIntegerNull(row["ItemId"]),
                    ItemName = Validate.CheckStringNull(row["ItemName"]),
                    Description = Validate.CheckStringNull(row["Description"]),
                    Image = Validate.CheckStringNull(row["Image"]),
                    ItemBiddingId = Validate.CheckIntegerNull(row["ItemBiddingId"]),
                    StatingPrice = Validate.CheckDecimalNull(row["StatingPrice"]),
                    CurrentPrice = Validate.CheckDecimalNull(row["CurrentPrice"]),
                    StartTime = Validate.CheckDateTimeNull(row["StartTime"]),
                    EndTime = Validate.CheckDateTimeNull(row["EndTime"]),
                    IsBidding = Validate.CheckBooleanNull(row["IsBidding"]),
                    IsAutoBidding = Validate.CheckBooleanNull(row["IsAutoBidding"])
                };
            }
            return item;
        }
    }
}
