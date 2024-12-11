using CodeZoneTask.Data;

namespace CodeZoneTask.Repo.Interfaces
{
    public interface IItemService
    {
        public Task<List<Item>> GetItems();
        public Task<bool> DeleteItem(int id);
        public Task<bool> AddItem(Item item);
        public Task<Item> EditItem( Item item);
    }
}
