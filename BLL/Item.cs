using BLL.Interfaces;
using DTO.Common;
using DTO.item;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class Item : IItem
    {
        #region Private Variables
        private readonly DAL.Interfaces.IItem _dalItem;
        #endregion

        #region Class Constructor
        public Item(DAL.Interfaces.IItem dalItem)
        {
            _dalItem = dalItem;
        }
        #endregion
        /// <summary>
        /// Get All Item Details
        /// </summary>
        /// <param name="inDTO"></param>
        /// <returns></returns>
        public List<ItemOut> GetItems(ItemIn inDTO)
        {
            List<ItemOut> items = _dalItem.GetItems(inDTO);

            //setting base path of images
            //items?.ForEach(x => x.Image = $"{Constant.BasePath}\\{x.Image}"  );

            items?.ForEach(x => x.Image = Convert.ToBase64String(System.IO.File.ReadAllBytes($"{Constant.BasePath}\\{x.Image}")));

            return items;
        }
        /// <summary>
        /// Get item By Id
        /// </summary>
        /// <param name="itemBiddingId"></param>
        /// <returns></returns>
        public ItemOut GetItemById(int itemBiddingId)
        {
            ItemOut item = _dalItem.GetItemById(itemBiddingId);
            item.Image = Convert.ToBase64String(System.IO.File.ReadAllBytes($"{Constant.BasePath}\\{item.Image}"));
            //item.Image = $"{Constant.BasePath}\\{item.Image}";
            return item;
        }
    }
}
