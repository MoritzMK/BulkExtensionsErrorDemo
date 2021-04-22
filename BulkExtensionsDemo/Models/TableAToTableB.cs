namespace BulkExtensionsDemo.Models
{
    public class TableAToTableB
    {
        public long Id { get; set; }

        public long TableBId { get; set; }

        public virtual TableB TableB { get; set; }

        public long TableAId { get; set; }

        public virtual TableA TableA { get; set; }
    }
}
