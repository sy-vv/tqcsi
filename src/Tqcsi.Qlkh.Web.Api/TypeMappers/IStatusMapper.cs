using Tqcsi.Qlkh.Web.Api.Models;

namespace Tqcsi.Qlkh.Web.Api.TypeMappers
{
    public interface IStatusMapper
    {
        Status CreateStatus(Data.Model.Status status);
    }
}