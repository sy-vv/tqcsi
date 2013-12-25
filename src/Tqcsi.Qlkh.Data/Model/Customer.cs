using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tqcsi.Qlkh.Data.Model
{
    public class Customer : IVersionedModelObject
    {
        public virtual int Id { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string BussinessSector { get; set; }
        public virtual Scope Scope { get; set; }
        public virtual string Address { get; set; }
        public virtual string Director { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Fax { get; set; }
        public virtual string EmaillAddress { get; set; }
        public virtual string ContactChannel { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual Action CurrentAction { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
