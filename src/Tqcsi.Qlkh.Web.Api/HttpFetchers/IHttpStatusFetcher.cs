using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Web.Api.HttpFetchers
{
    public interface IHttpStatusFetcher
    {
        Status GetStatus(long statusId);
    }
}