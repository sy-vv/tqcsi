using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Data.SqlServer.Mapping
{
    public class CustomerContactMap : VersionedClassMap<CustomerContact>
    {
        public CustomerContactMap()
        {
            Map(x => x.CustomerFeedback).Nullable();
            Map(x => x.Note).Nullable();
        }
    }
}
