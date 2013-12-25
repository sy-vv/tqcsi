using Tqcsi.Qlkh.Web.Api.Models;

namespace Tqcsi.Qlkh.Web.Api.TypeMappers
{
    public interface IPriorityMapper
    {
        Priority CreatePriority(Data.Model.Priority priority);
    }
}