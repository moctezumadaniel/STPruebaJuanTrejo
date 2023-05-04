using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaSTJuanTrejo.Business.Services.Items;
using PruebaSTJuanTrejo.Data.Repositories.Items;
using PruebaSTJuanTrejo.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace PruebaSTJuanTrejo.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemsService _itemsService;
        public ItemController(
            IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet]
        [Route("/Items")]
        [Authorize]

        public IActionResult ReadItems(
            [FromQuery] int limit)
        {
            var result = _itemsService.GetItems(limit);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("/Items")]
        [Authorize]

        public IActionResult CreateItem(
            [FromBody] ItemToCreate item)
        {
            if (ModelState.IsValid)
            {
                var newItem = new Item
                {
                    Code = item.Code,
                    Description = item.Description,
                    Price = item.Price,
                    Stock = item.Stock,
                    StoreId = item.StoreId,

                };
                var result = _itemsService.CreateItem(newItem);
                return new JsonResult(result);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        [HttpPut]
        [Route("/Items")]
        [Authorize]

        public IActionResult UpdateItem(
            [FromBody] Item item)
        {
            var result = _itemsService.UpdateItem(item);
            return new JsonResult(result);
        }

        [HttpDelete]
        [Route("/Items/{guid}")]
        [Authorize]

        public IActionResult DeleteItem(
            [FromRoute] Guid guid)
        {
            var result = _itemsService.DeleteItem(guid);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("/Items/{guid}")]
        [Authorize]
        public IActionResult UpdateItem(
            [FromRoute] Guid guid,
            [FromHeader] string authorization)
        {
            var jwt = authorization.Split()[1];
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadJwtToken(jwt);
            var payload = token.Payload;
            var userId = Guid.Parse(payload["userId"].ToString());
            _itemsService.AddItemToCart(guid, userId);
            return new JsonResult("creado");
        }
    }
}
