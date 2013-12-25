using System;
using Tqcsi.Qlkh.Web.Api.Models;

namespace Tqcsi.Qlkh.Web.Api.TypeMappers
{
    public interface IUserMapper
    {
        User CreateUser(string username, string firstname, string lastname, string email, int userId);
        User CreateUser(Data.Model.User modelUser);
    }
}