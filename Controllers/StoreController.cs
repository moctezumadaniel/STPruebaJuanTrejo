using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaSTJuanTrejo.Business.Services.Stores;
using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoresService _storesService;
        public StoreController(IStoresService serviceStore)
        {
            _storesService = serviceStore;
        }
        [HttpGet]
        [Route("/Stores")]
        [Authorize]
        public IActionResult GetStores(
            [FromQuery] int limit
            )
        {

            var stores = _storesService.GetStores(limit);
            return new JsonResult(stores);
        }

        [HttpPost]
        [Route("/Stores")]
        [Authorize]
        public IActionResult CreateStore(
            [FromBody] StoreToCreate store
            )
        {
            if (ModelState.IsValid)
            {
                var newStore = new Store
                {
                    Address = store.Address,
                    Branch = store.Branch,
                };
                var stores = _storesService.CreateStore(newStore);
                return new JsonResult(stores);
            }
            else return new JsonResult(null);
        }

        [HttpPut]
        [Route("/Stores")]
        [Authorize]
        public IActionResult UpdateStore(
            [FromBody] Store store
            )
        {

            var stores = _storesService.UpdateStore(store);
            return new JsonResult(stores);
        }

        [HttpDelete]
        [Route("/Stores/{guid}")]
        [Authorize]
        public IActionResult DeleteStore(
            [FromRoute] Guid guid
            )
        {

            var stores = _storesService.DeleteStore(guid);
            return new JsonResult(stores);
        }

    }
}
