using CodeZoneTask.Data;
using CodeZoneTask.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Repo.Implemtation
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GenericService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Add(T item)
        {
            var itemEntity = await applicationDbContext.Set<T>().AddAsync(item);
            var entitySaved = await applicationDbContext.SaveChangesAsync();
            if (entitySaved > 0) return true;
            else return false;
        }

        public async Task<bool> Delete(int id)
        {
            var itemEntity = await applicationDbContext.Set<T>().FindAsync(id);
            if (itemEntity != null)
            {
                applicationDbContext.Set<T>().Remove(itemEntity);
                var entityDeleted = await applicationDbContext.SaveChangesAsync();
                if (entityDeleted > 0) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<T> Edit(int id,T item)
        {
            var dbSet = applicationDbContext.Set<T>();
            var itemEntity = await dbSet.FindAsync(id); // Assuming `Id` is a primary key.
            if (itemEntity == null)
            {
                return null;
            }

            // Update properties
            applicationDbContext.Entry(itemEntity).CurrentValues.SetValues(item);

            // Save changes
            var entityUpdated = await applicationDbContext.SaveChangesAsync();
            return entityUpdated > 0 ? itemEntity : null;
        }

        public async Task<List<T>> Get()
        {
            var items = await applicationDbContext.Set<T>().AsQueryable().ToListAsync();
            return items;
        }
    }
}
