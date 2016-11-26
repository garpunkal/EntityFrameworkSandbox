using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garpunkal.EntityFrameworkSandbox.Data.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
