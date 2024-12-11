using CodeZoneTask.Data;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Repo.Implemtation
{
    public class StoreService : IStoreService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StoreService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<bool> AddStore(Store store)
        {
            var storeEntity=await applicationDbContext.Stores.AddAsync(store);
            var entitySaved=await applicationDbContext.SaveChangesAsync();
            if (entitySaved > 0) return true;
            else return false;
        }

        public async Task<bool> DeleteStore(int id)
        {
            var storeEntity=await applicationDbContext.Stores.FirstOrDefaultAsync(x => x.Id == id);
            if (storeEntity != null) {
                 applicationDbContext.Stores.Remove(storeEntity);
                var entityDeleted = await applicationDbContext.SaveChangesAsync();
                if (entityDeleted > 0) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<Store> EditStore(int id,Store store)
        {
            var storeEntity=await applicationDbContext.Stores.FirstOrDefaultAsync(x=>x.Id==id);
            if (storeEntity != null) {
                storeEntity.Name = store.Name;
                var entityUpdated=await applicationDbContext.SaveChangesAsync();
                if (entityUpdated > 0)
                {
                    return storeEntity;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

      
        public async Task<List<Store>> GetStores()
        {
            var stores=await applicationDbContext.Stores.AsQueryable().ToListAsync();
            return stores;
        }
    }
}
