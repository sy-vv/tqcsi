using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Data.SqlServer.Mapping
{
    public class ServiceMap :  VersionedClassMap<Service>
    {
        public ServiceMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Nullable();
            Map(x => x.Note).Nullable();
        }
    }
}
