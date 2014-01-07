using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Data.SqlServer.Mapping
{
    public class CustomerServiceMap : VersionedClassMap<CustomerService>
    {
        public CustomerServiceMap()
        {
            Id(x => x.Id);
            Map(x => x.WantedIsoType).Nullable();
            Map(x => x.Note).Nullable();
        }
    }
}
