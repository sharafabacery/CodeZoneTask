using CodeZoneTask.Data;
using CodeZoneTask.Repo.Implemtation;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }
        public async Task<IActionResult> Index()
        {
            List<Item> items = new List<Item>();
            items = await itemService.GetItems();
            ViewData["items"] = items;
            return View();
        }
        public async Task<IActionResult> Add(Item item)
        {
            if (ModelState.IsValid)
            {
                var itemdb = await itemService.AddItem(item);

            }
            return RedirectToAction("Index", "Item");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item = await itemService.DeleteItem(id);
            return RedirectToAction("Index", "Item");
        }
        public async Task<IActionResult> Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                var itemdb = await itemService.EditItem(item);

            }
            return RedirectToAction("Index", "Item");
        }
    }
}
