using CodeZoneTask.Data;
using CodeZoneTask.Repo.Implemtation;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenericService<Store> genericService;

        public StoreController( IGenericService<Store> genericService)
        {
            this.genericService = genericService;
        }
        public async Task< IActionResult> Index()
        {
            List<Store> stores = new List<Store>();
            stores=await genericService.Get();
            ViewData["stores"] = stores;
            return View();
        }
        public async Task<IActionResult> Add(Store store)
        {
            if (ModelState.IsValid)
            {
                var storedb = await genericService.Add(store);
                
            }
           return RedirectToAction("Index","Store");
        }
        public async Task<IActionResult>Delete(int id)
        {
            var store =await genericService.Delete(id);
            return RedirectToAction("Index", "Store");
        }
        public async Task<IActionResult> Edit(int id,Store store)
        {
            if (ModelState.IsValid)
            {
                var storedb = await genericService.Edit(id,store);

            }
            return RedirectToAction("Index", "Store");
        }
    }
}
