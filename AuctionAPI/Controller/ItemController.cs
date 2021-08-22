using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTO.item;
using DTO.ItemBiddingHistory;
using BLL.Interfaces;
using DTO.ItemBidding;
using System.ComponentModel.DataAnnotations;
using DTO.AutoBiddingAmount;

namespace AuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        #region Private Variables
        private readonly BLL.Interfaces.IItem _bllItem;
        private readonly BLL.Interfaces.IItemBidding _bllItemBidding;
        private readonly BLL.Interfaces.IItemBiddingHistory _bllItemBiddingHistory;
        private readonly BLL.Interfaces.IAutoBiddingAmount _bllAutoBiddingAmount;
        #endregion

        #region Class Constructor
        public ItemController(BLL.Interfaces.IItem bllItem,
            BLL.Interfaces.IItemBidding bllItemBidding,
            BLL.Interfaces.IAutoBiddingAmount bllAutoBiddingAmount,
            BLL.Interfaces.IItemBiddingHistory bllItemBiddingHistory)
        {
            _bllItem = bllItem;
            _bllItemBidding = bllItemBidding;
            _bllAutoBiddingAmount = bllAutoBiddingAmount;
            _bllItemBiddingHistory = bllItemBiddingHistory;
        }
        #endregion

        [HttpPost("~/GetItems")]
        public ActionResult<List<ItemOut>> GetItems([FromBody]ItemIn inDTO)
        {
            return Ok(_bllItem.GetItems(inDTO));
        }

        [HttpGet("~/GetItemById")]
        public ActionResult<ItemOut> GetItemById([Required]int itemBiddingId)
        {
            return Ok(_bllItem.GetItemById(itemBiddingId));
        }

        [HttpGet("~/GetItemBiddingHistory")]
        public ActionResult<ItemBiddingHstoryOut> GetItemBiddingHistory(int itemBiddingId)
        {
            return Ok(_bllItemBiddingHistory.GetItemBiddingHistory(itemBiddingId));
        }

        [HttpPost("~/BidNow")]
        public async Task<ActionResult<int>> BidNow([FromBody] ItemBiddingIn inDTO)
        {
            return Ok(await _bllItemBidding.BidNow(inDTO));
        }

        [HttpGet("~/GetAutoBidAmount")]
        public ActionResult<decimal> GetAutoBidAmount(int userId)
        {
            return Ok(_bllAutoBiddingAmount.GetAutoBidAmount(userId));
        }

        [HttpPost("~/SaveAutoBidAmount")]
        public ActionResult<int> SaveAutoBidAmount([FromBody] AutoBiddingAmountIn inDTO)
        {
            return Ok(_bllAutoBiddingAmount.SaveAutoBidAmount(inDTO.UserId, inDTO.MaxBidAmount));
        }
    }
}
