using Tqcsi.Qlkh.Web.Api.Models;

namespace Tqcsi.Qlkh.Web.Api.TypeMappers
{
    public interface ITaskMapper
    {
        Task CreateTask(Data.Model.Task modelTask);
    }
}