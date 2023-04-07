using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCondo_Finance_Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string RefCode { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedDate { get; set; }
    }
}
