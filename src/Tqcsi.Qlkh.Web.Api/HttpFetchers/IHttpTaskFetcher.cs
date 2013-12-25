using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Web.Api.HttpFetchers
{
    public interface IHttpTaskFetcher
    {
        Task GetTask(long taskId);
    }
}