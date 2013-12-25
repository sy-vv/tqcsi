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
    public class PrioritiesController : ApiController
    {
        private readonly ISession _session;
        private readonly IPriorityMapper _priorityMapper;
        private readonly IHttpPriorityFetcher _priorityFetcher;

        public PrioritiesController(
            ISession session,
            IPriorityMapper priorityMapper,
            IHttpPriorityFetcher priorityFetcher)
        {
            _session = session;
            _priorityMapper = priorityMapper;
            _priorityFetcher = priorityFetcher;
        }

        public IEnumerable<Priority> Get()
        {
            return _session
                .QueryOver<Data.Model.Priority>()
                .List()
                .Select(_priorityMapper.CreatePriority);
        }

        public Priority Get(long id)
        {
            var priority = _priorityFetcher.GetPriority(id);
            return _priorityMapper.CreatePriority(priority);
        }
    }
}
