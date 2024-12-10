namespace CodeZoneTask.Data
{
    public class StoreItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public Item Item { get; set; }

    }
}
