using CodeZoneTask.Data;
using CodeZoneTask.DTO;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IStockService stockService;
        private readonly IGenericService<Store> genericServiceStore;
        private readonly IGenericService<Item> genericServiceItem;
        
        public PurchaseController(IStockService stockService,IGenericService<Store> genericServiceStore,IGenericService<Item>genericServiceItem)
        {
            this.stockService = stockService;
            this.genericServiceStore = genericServiceStore;
            this.genericServiceItem = genericServiceItem;
          
        }
        public async Task<IActionResult> Index()
        {
            List<Item> items = new List<Item>();
            items = await genericServiceItem.Get();
            
            List<Store> stores = new List<Store>();
            stores = await genericServiceStore.Get();
            
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
