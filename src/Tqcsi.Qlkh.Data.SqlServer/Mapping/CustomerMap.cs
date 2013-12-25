using System;
using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Data.SqlServer.Mapping
{
    public class CustomerMap : VersionedClassMap<Customer>
    {
        public CustomerMap()
        {
            Map(x => x.CustomerName).Not.Nullable();
            Map(x => x.Address).Nullable();
            Map(x => x.Director).Nullable();
            Map(x => x.PhoneNumber).Nullable();
            Map(x => x.Fax).Nullable();
            Map(x => x.EmaillAddress).Nullable();
            Map(x => x.ContactChannel).Nullable();
            Map(x => x.CreatedDate).Nullable();
        }
    }
}
