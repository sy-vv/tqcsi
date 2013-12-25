using Tqcsi.Qlkh.Data.Model;

namespace Tqcsi.Qlkh.Web.Api.HttpFetchers
{
    public interface IHttpCategoryFetcher
    {
        Category GetCategory(long categoryId);
    }
}