using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Data.SqlServer.Mapping
{
    public class ActionMap :  VersionedClassMap<Action>
    {
        public ActionMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Nullable();
        }
    }
}
