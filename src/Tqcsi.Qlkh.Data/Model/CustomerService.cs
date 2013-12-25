using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tqcsi.Qlkh.Data.Model
{
    public class CustomerService : IVersionedModelObject
    {
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Service Service { get; set; }
        public virtual string WantedIsoType { get; set; }
        public virtual string Note { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
