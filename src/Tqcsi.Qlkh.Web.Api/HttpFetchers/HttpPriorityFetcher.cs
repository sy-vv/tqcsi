using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tqcsi.Qlkh.Data.Model;
using NHibernate;

namespace Tqcsi.Qlkh.Web.Api.HttpFetchers
{
    public class HttpPriorityFetcher : IHttpPriorityFetcher
    {
        private readonly ISession _session;

        public HttpPriorityFetcher(ISession session)
        {
            _session = session;
        }

        public Priority GetPriority(long priorityId)
        {
            var priority = _session.Get<Priority>(priorityId);
            if (priority == null)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.NotFound,
                            ReasonPhrase = string.Format("Priority {0} not found", priorityId)
                        });
            }

            return priority;
        }
    }
}