using System.Web.Http;
using Tqcsi.Qlkh.Web.Api.HttpFetchers;
using Tqcsi.Qlkh.Web.Api.Models;
using Tqcsi.Qlkh.Web.Api.TypeMappers;
using Tqcsi.Qlkh.Web.Common;
using NHibernate;

namespace Tqcsi.Qlkh.Web.Api.Controllers
{
    [LoggingNHibernateSession]
    public class TaskStatusController : ApiController
    {
        private readonly ISession _session;
        private readonly IStatusMapper _statusMapper;
        private readonly IHttpStatusFetcher _statusFetcher;
        private readonly IHttpTaskFetcher _taskFetcher;

        public TaskStatusController(
            IHttpTaskFetcher taskFetcher, 
            ISession session, 
            IStatusMapper statusMapper,
            IHttpStatusFetcher statusFetcher)
        {
            _taskFetcher = taskFetcher;
            _session = session;
            _statusMapper = statusMapper;
            _statusFetcher = statusFetcher;
        }

        public Status Get(long taskId)
        {
            var task = _taskFetcher.GetTask(taskId);
            return _statusMapper.CreateStatus(task.Status);
        }

        public void Put(long taskId, long statusId)
        {
            var task = _taskFetcher.GetTask(taskId);

            var status = _statusFetcher.GetStatus(statusId);

            task.Status = status;

            _session.SaveOrUpdate(task);
        }
    }
}