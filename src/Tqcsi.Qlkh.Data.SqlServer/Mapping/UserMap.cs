using System;
using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Data.SqlServer.Mapping
{
    public class UserMap : VersionedClassMap<User>
    {
        public UserMap()
        {
            Table("UserProfile");

            Id(x => x.UserId).CustomType<int>();
            Map(x => x.Firstname).Not.Nullable();
            Map(x => x.Lastname).Not.Nullable();
            Map(x => x.Email).Nullable();
            Map(x => x.Username).Not.Nullable();
        }
    }
}