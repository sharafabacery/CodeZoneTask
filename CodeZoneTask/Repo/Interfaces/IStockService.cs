using CodeZoneTask.Data;
using CodeZoneTask.DTO;

namespace CodeZoneTask.Repo.Interfaces
{
    public interface IStockService
    {
        public Task<List<StockDTO>> Stocks();
        public Task<StoreItem> AddQuantity(StoreItem storeItem);
    }
}
