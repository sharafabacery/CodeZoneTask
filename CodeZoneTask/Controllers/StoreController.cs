using CodeZoneTask.Data;
using CodeZoneTask.Repo.Implemtation;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        public async Task< IActionResult> Index()
        {
            List<Store> stores = new List<Store>();
            stores=await storeService.GetStores();
            ViewData["stores"] = stores;
            return View();
        }
        public async Task<IActionResult> Add(Store store)
        {
            if (ModelState.IsValid)
            {
                var storedb = await storeService.AddStore(store);
                
            }
           return RedirectToAction("Index","Store");
        }
        public async Task<IActionResult>Delete(int id)
        {
            var store =await storeService.DeleteStore(id);
            return RedirectToAction("Index", "Store");
        }
        public async Task<IActionResult> Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                var storedb = await storeService.EditStore(store);

            }
            return RedirectToAction("Index", "Store");
        }
    }
}
