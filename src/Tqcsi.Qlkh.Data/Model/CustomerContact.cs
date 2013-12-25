using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tqcsi.Qlkh.Data.Model
{
    public class CustomerContact : IVersionedModelObject
    {
        public virtual int Id { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual DateTime ContactDate { get; set; }
        public virtual string Content { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual User ContactPerson { get; set; }
        public virtual string CustomerFeedback { get; set; }
        public virtual Action Action { get; set; }
        public virtual Action NextAction { get; set; }
        public virtual string Note { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
