using System;
using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Data
{
    public interface IUserRepository
    {
        void SaveUser(int userId, string firstname, string lastname);
        User GetUser(int userId);
    }
}
