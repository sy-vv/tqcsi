using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Web.Api.HttpFetchers
{
    public interface IHttpPriorityFetcher
    {
        Priority GetPriority(long priorityId);
    }
}