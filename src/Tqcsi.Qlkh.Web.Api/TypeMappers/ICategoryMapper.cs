using Tqcsi.Qlkh.Web.Api.Models;

namespace Tqcsi.Qlkh.Web.Api.TypeMappers
{
    public interface ICategoryMapper
    {
        Category CreateCategory(Data.Model.Category modelCategory);
    }
}