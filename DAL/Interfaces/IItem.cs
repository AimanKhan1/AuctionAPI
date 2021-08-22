using DTO.item;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IItem
    {
        /// <summary>
        /// List of Item
        /// </summary>
        /// <returns></returns>
        List<ItemOut> GetItems(ItemIn filters);
        /// <summary>
        /// Get Item Details By Id
        /// </summary>
        /// <param name="itemBiddingId"></param>
        /// <returns></returns>
        ItemOut GetItemById(int itemBiddingId);
    }
}
