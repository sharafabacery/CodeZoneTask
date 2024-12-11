using CodeZoneTask.Data;

namespace CodeZoneTask.Repo.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task<List<T>> Get();
        public Task<bool> Delete(int id);
        public Task<bool> Add(T item);
        public Task<T> Edit(int id,T item);
    }
}
