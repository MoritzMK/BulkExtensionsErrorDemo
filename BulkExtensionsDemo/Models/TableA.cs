using System.Collections.Generic;

namespace BulkExtensionsDemo.Models
{
    public class TableA
    {
        public long Id { get; set; }

        public string Data { get; set; }

        public virtual ICollection<TableAToTableB> Relations { get; set; } = new HashSet<TableAToTableB>();
    }
}
