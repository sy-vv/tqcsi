using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tqcsi.Qlkh.Data.Model
{
    // Company provided services
    public class Service : IVersionedModelObject
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set;}
        public virtual string Description { get; set; }
        public virtual string Note { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
