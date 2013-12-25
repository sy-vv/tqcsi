using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tqcsi.Qlkh.Common;
using Tqcsi.Qlkh.Web.Api.HttpFetchers;
using Tqcsi.Qlkh.Web.Api.Models;
using Tqcsi.Qlkh.Web.Api.TypeMappers;
using Tqcsi.Qlkh.Web.Common;
using Tqcsi.Qlkh.Web.Common.Security;
using NHibernate;
using NHibernate.Linq;

namespace Tqcsi.Qlkh.Web.Api.Controllers
{
    [LoggingNHibernateSession]
    public class TasksController : ApiController
    {
        private readonly ISession _session;
        private readonly IHttpTaskFetcher _taskFetcher;
        private readonly IUserSession _userSession;
        private readonly IDateTime _dateTime;
        private readonly ITaskMapper _taskMapper;

        public TasksController(
            IHttpTaskFetcher taskFetcher, 
            IUserSession userSession, 
            ISession session, 
            IDateTime dateTime, 
            ITaskMapper taskMapper)
        {
            _taskFetcher = taskFetcher;
            _userSession = userSession;
            _session = session;
            _dateTime = dateTime;
            _taskMapper = taskMapper;
        }

        public Task Get(long id)
        {
            var modelTask = _taskFetcher.GetTask(id);
            var task = _taskMapper.CreateTask(modelTask);

            return task;
        }

        public IEnumerable<Task> Get()
        {
            var tasks = _session
                .Query<Data.Model.Task>()
                .Where(
                    x =>
                    x.CreatedBy.UserId == _userSession.UserId || x.Users.Any(user => user.UserId == _userSession.UserId))
                .Select(_taskMapper.CreateTask)
                .ToList();

            return tasks;
        }

        public HttpResponseMessage Delete(long id)
        {
            var task = _session.Get<Data.Model.Task>(id);
            if (task != null)
            {
                task.Status = _session.Query<Data.Model.Status>().First(x => x.Name == "Completed");
                _session.SaveOrUpdate(task);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Post(HttpRequestMessage request, Task task)
        {
            var currentUser = _session.Get<Data.Model.User>(_userSession.UserId);

            var modelTask = new Data.Model.Task
                                {
                                    CreatedDate = _dateTime.UtcNow,
                                    CreatedBy = currentUser,
                                    Subject = task.Subject,
                                    DateCompleted = task.DateCompleted,
                                    DueDate = task.DueDate,
                                    StartDate = task.StartDate,
                                    Priority = _session.Get<Data.Model.Priority>(task.Priority.PriorityId),
                                    Status = _session.Get<Data.Model.Status>(task.Status.StatusId)                                   
                                };

            foreach (var category in task.Categories)
            {
                var modelCategory = _session.Get<Data.Model.Category>(category.CategoryId);
                modelTask.Categories.Add(modelCategory);
            }

            foreach (var user in task.Assignees)
            {
                var modelUser = _session.Get<Data.Model.User>(user.UserId);
                modelTask.Users.Add(modelUser);
            }

            _session.SaveOrUpdate(modelTask);

            var newTask = _taskMapper.CreateTask(modelTask);

            var href = newTask.Links.First(x => x.Rel == "self").Href;

            var response = request.CreateResponse(HttpStatusCode.Created, newTask);
            response.Headers.Add("Location", href);

            return response;
        }

        public Task Put(HttpRequestMessage request, Task task)
        {
            var modelTask = _taskFetcher.GetTask(task.TaskId);

            modelTask.Subject = task.Subject;
            modelTask.DateCompleted = task.DateCompleted;
            modelTask.DueDate = task.DueDate;
            modelTask.StartDate = task.StartDate;
            modelTask.Priority = _session.Get<Data.Model.Priority>(task.Priority.PriorityId);
            modelTask.Status = _session.Get<Data.Model.Status>(task.Status.StatusId);
        
            modelTask.Categories.Clear();
            foreach (var category in task.Categories)
            {
                var modelCategory = _session.Get<Data.Model.Category>(category.CategoryId);
                modelTask.Categories.Add(modelCategory);
            }

            modelTask.Users.Clear();
            foreach (var user in task.Assignees)
            {
                var modelUser = _session.Get<Data.Model.User>(user.UserId);
                modelTask.Users.Add(modelUser);
            }

            _session.SaveOrUpdate(modelTask);

            return _taskMapper.CreateTask(modelTask);
        }
    }
}