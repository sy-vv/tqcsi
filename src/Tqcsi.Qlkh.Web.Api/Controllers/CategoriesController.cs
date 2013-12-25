using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tqcsi.Qlkh.Web.Api.HttpFetchers;
using Tqcsi.Qlkh.Web.Api.Models;
using Tqcsi.Qlkh.Web.Api.TypeMappers;
using Tqcsi.Qlkh.Web.Common;
using Tqcsi.Qlkh.Web.Common.Security;
using NHibernate;

namespace Tqcsi.Qlkh.Web.Api.Controllers
{
    [LoggingNHibernateSession]
    public class CategoriesController : ApiController
    {
        private readonly ISession _session;
        private readonly ICategoryMapper _categoryMapper;
        private readonly IHttpCategoryFetcher _categoryFetcher;

        public CategoriesController(
            ISession session, 
            ICategoryMapper categoryMapper, 
            IHttpCategoryFetcher categoryFetcher)
        {
            _session = session;
            _categoryMapper = categoryMapper;
            _categoryFetcher = categoryFetcher;
        }

        public IEnumerable<Category> Get()
        {
            return _session
                .QueryOver<Data.Model.Category>()
                .List()
                .Select(_categoryMapper.CreateCategory)
                .ToList();
        }

        public Category Get(long id)
        {
            var category = _categoryFetcher.GetCategory(id);
            return _categoryMapper.CreateCategory(category);
        }

        [AdministratorAuthorized]
        public HttpResponseMessage Post(HttpRequestMessage request, Category category)
        {
            var modelCategory = new Data.Model.Category
                                    {
                                        Description = category.Description,
                                        Name = category.Name
                                    };

            _session.Save(modelCategory);

            var newCategory = _categoryMapper.CreateCategory(modelCategory);

            var href = newCategory.Links.First(x => x.Rel == "self").Href;

            var response = request.CreateResponse(HttpStatusCode.Created, newCategory);
            response.Headers.Add("Location", href);

            return response;
        }

        [AdministratorAuthorized]
        public HttpResponseMessage Delete()
        {
            var categories = _session.QueryOver<Data.Model.Category>().List();
            foreach (var category in categories)
            {
                _session.Delete(category);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [AdministratorAuthorized]
        public HttpResponseMessage Delete(long id)
        {
            var category = _session.Get<Data.Model.Category>(id);
            if (category != null)
            {
                _session.Delete(category);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [AdministratorAuthorized]
        public Category Put(long id, Category category)
        {
            var modelCateogry = _categoryFetcher.GetCategory(id);

            modelCateogry.Name = category.Name;
            modelCateogry.Description = category.Description;

            _session.SaveOrUpdate(modelCateogry);

            return _categoryMapper.CreateCategory(modelCateogry);
        }
    }
}
