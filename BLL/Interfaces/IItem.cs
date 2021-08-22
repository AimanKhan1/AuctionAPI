using DTO.item;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IItem
    {
        /// <summary>
        /// List of Items
        /// </summary>
        /// <returns></returns>
        List<ItemOut> GetItems(ItemIn inDTO);
        /// <summary>
        /// Get Item Detail By Id
        /// </summary>
        /// <param name="itemBiddingId"></param>
        /// <returns></returns>
        ItemOut GetItemById(int itemBiddingId);
    }
}
