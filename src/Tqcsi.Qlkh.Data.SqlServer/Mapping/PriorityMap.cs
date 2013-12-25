using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Data.SqlServer.Mapping
{
    public class PriorityMap : VersionedClassMap<Priority>
    {
        public PriorityMap()
        {
            Id(x => x.PriorityId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Ordinal).Not.Nullable();
        }
    }
}