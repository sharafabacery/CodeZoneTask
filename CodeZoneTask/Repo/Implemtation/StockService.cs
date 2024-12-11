using CodeZoneTask.Data;
using CodeZoneTask.DTO;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Repo.Implemtation
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StockService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<StoreItem> AddQuantity(StoreItem storeItem)
        {
            var stock= await applicationDbContext.StoreItems.Where(x=>x.ItemId==storeItem.ItemId&&x.StoreId==storeItem.StoreId).FirstOrDefaultAsync();
            if (stock != null) {
                stock.Quantity += storeItem.Quantity;
                
            }
            else
            {
                var storeEntity = await applicationDbContext.StoreItems.AddAsync(storeItem);
               
            }
            var entity = await applicationDbContext.SaveChangesAsync();
            if (entity > 0)
            {
                return stock;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<StockDTO>> Stocks()
        {
            var stores = await applicationDbContext.StoreItems.Include(x => x.Store).Include(x => x.Item).Select(e =>new StockDTO{ 
                ItemId=e.ItemId,
                StoreId=e.StoreId,
                Quantity=e.Quantity,
                ItemName=e.Item.Name,
                StoreName=e.Store.Name,
                Id=e.Id
            }).AsQueryable().ToListAsync();
            return stores;
        }
    }
}
