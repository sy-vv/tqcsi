using System.Collections.Generic;
using Tqcsi.Qlkh.Web.Api.Models;

namespace Tqcsi.Qlkh.Web.Api.TypeMappers
{
    public class PriorityMapper : IPriorityMapper
    {
        public Priority CreatePriority(Data.Model.Priority priority)
        {
            return new Priority
                       {
                           PriorityId = priority.PriorityId,
                           Ordinal = priority.Ordinal,
                           Name = priority.Name,
                           Links = new List<Link>
                                       {
                                           new Link
                                               {
                                                   Title = "self",
                                                   Rel = "self",
                                                   Href = "/api/priorities/" + priority.PriorityId
                                               },
                                           new Link
                                               {
                                                   Title = "All Priorities",
                                                   Rel = "all",
                                                   Href = "/api/priorities"
                                               }
                                       }
                       };
        }
    }
}