using System.Collections.Generic;

namespace BulkExtensionsDemo.Models
{
    public class TableB
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TableAToTableB> Relations { get; set; } = new HashSet<TableAToTableB>();
    }
}
