using CodeZoneTask.Data;
using CodeZoneTask.Repo.Implemtation;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Controllers
{
    public class ItemController : Controller
    {
        private readonly IGenericService<Item> genericService;

        public ItemController(IGenericService<Item> genericService)
        {
            this.genericService = genericService;
        }
        public async Task<IActionResult> Index()
        {
            List<Item> items = new List<Item>();
            items = await genericService.Get();
            ViewData["items"] = items;
            return View();
        }
        public async Task<IActionResult> Add(Item item)
        {
            if (ModelState.IsValid)
            {
                var itemdb = await genericService.Add(item);

            }
            return RedirectToAction("Index", "Item");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item = await genericService.Delete(id);
            return RedirectToAction("Index", "Item");
        }
        public async Task<IActionResult> Edit(int id,Item item)
        {
            if (ModelState.IsValid)
            {
                var itemdb = await genericService.Edit(id,item);

            }
            return RedirectToAction("Index", "Item");
        }
    }
}
