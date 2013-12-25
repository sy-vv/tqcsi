using System.Web.Http.Filters;

namespace Tqcsi.Qlkh.Web.Common
{
    public interface IActionExceptionHandler
    {
        void HandleException(HttpActionExecutedContext filterContext);
    }
}