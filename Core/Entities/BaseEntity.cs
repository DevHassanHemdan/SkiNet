using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.UtcNow;
        public string UpdatedBy { get; set; }
        public DateTimeOffset DeletedOn { get; set; } = DateTimeOffset.UtcNow;
        public string DeletedBy { get; set; }
    }
}
