using CodeZoneTask.Data;

namespace CodeZoneTask.Repo.Interfaces
{
    public interface IStoreService
    {
        public Task<List<Store>> GetStores();
        public Task<bool> DeleteStore(int id);
        public Task<bool> AddStore(Store store);
        public Task<Store> EditStore(Store store);
    }
}
