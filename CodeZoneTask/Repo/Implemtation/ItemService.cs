using CodeZoneTask.Data;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Repo.Implemtation
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ItemService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<bool> AddItem(Item item)
        {
            var itemEntity = await applicationDbContext.Items.AddAsync(item);
            var entitySaved = await applicationDbContext.SaveChangesAsync();
            if (entitySaved > 0) return true;
            else return false;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var itemEntity = await applicationDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (itemEntity != null)
            {
                applicationDbContext.Items.Remove(itemEntity);
                var entityDeleted = await applicationDbContext.SaveChangesAsync();
                if (entityDeleted > 0) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<Item> EditItem( Item item)
        {
            var itemEntity = await applicationDbContext.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (itemEntity != null)
            {
                itemEntity.Name = item.Name;
                var entityUpdated = await applicationDbContext.SaveChangesAsync();
                if (entityUpdated > 0)
                {
                    return itemEntity;
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

        
        public async Task<List<Item>> GetItems()
        {
            var items = await applicationDbContext.Items.AsQueryable().ToListAsync();
            return items;
        }
    }
}
