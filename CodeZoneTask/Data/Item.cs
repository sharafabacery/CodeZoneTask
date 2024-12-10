namespace CodeZoneTask.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StoreItem> StoreItem { get; } = new List<StoreItem>(); // Collection navigation containing dependents

    }
}
