using CodeZoneTask.Data;
using CodeZoneTask.DTO;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IStockService stockService;
        private readonly IItemService itemService;
        private readonly IStoreService storeService;

        public PurchaseController(IStockService stockService,IItemService itemService,IStoreService storeService)
        {
            this.stockService = stockService;
            this.itemService = itemService;
            this.storeService = storeService;
        }
        public async Task<IActionResult> Index()
        {
            List<Item> items = new List<Item>();
            items = await itemService.GetItems();
            
            List<Store> stores = new List<Store>();
            stores = await storeService.GetStores();
            
            List<StockDTO>stocks = new List<StockDTO>();
            stocks=await stockService.Stocks();

            ViewData["stores"] = stores;
            ViewData["items"] = items;
            ViewData["stocks"] = stocks;

            return View();
        }
        public async Task<IActionResult> Add(StoreItem item)
        {
           
                var stockdb = await stockService.AddQuantity(item);

                return RedirectToAction("Index", "Purchase");
        }
    }
}
