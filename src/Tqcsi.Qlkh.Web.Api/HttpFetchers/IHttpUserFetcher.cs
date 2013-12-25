using System;
using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Web.Api.HttpFetchers
{
    public interface IHttpUserFetcher
    {
        User GetUser(int userId);
    }
}