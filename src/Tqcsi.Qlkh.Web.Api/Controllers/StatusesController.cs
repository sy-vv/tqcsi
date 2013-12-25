using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tqcsi.Qlkh.Web.Api.HttpFetchers;
using Tqcsi.Qlkh.Web.Api.Models;
using Tqcsi.Qlkh.Web.Api.TypeMappers;
using Tqcsi.Qlkh.Web.Common;
using NHibernate;

namespace Tqcsi.Qlkh.Web.Api.Controllers
{
    [LoggingNHibernateSession]
    public class StatusesController : ApiController
    {
        private readonly ISession _session;
        private readonly IStatusMapper _statusMapper;
        private readonly IHttpStatusFetcher _statusFetcher;

        public StatusesController(
            ISession session, 
            IStatusMapper statusMapper,
            IHttpStatusFetcher statusFetcher)
        {
            _session = session;
            _statusMapper = statusMapper;
            _statusFetcher = statusFetcher;
        }

        public IEnumerable<Status> Get()
        {
            return _session
                .QueryOver<Data.Model.Status>()
                .List()
                .Select(_statusMapper.CreateStatus);
        }

        public Status Get(long id)
        {
            var status = _statusFetcher.GetStatus(id);
            return _statusMapper.CreateStatus(status);
        }
    }
}
