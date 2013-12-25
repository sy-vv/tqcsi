using System.Collections.Generic;
using Tqcsi.Qlkh.Web.Api.Models;

namespace Tqcsi.Qlkh.Web.Api.TypeMappers
{
    public class CategoryMapper : ICategoryMapper
    {
        public Category CreateCategory(Data.Model.Category modelCategory)
        {
            return new Category
                       {
                           CategoryId = modelCategory.CategoryId,
                           Description = modelCategory.Description,
                           Name = modelCategory.Name,
                           Links = new List<Link>
                                       {
                                           new Link
                                               {
                                                   Title = "self",
                                                   Rel = "self",
                                                   Href = "/api/categories/" + modelCategory.CategoryId
                                               },
                                           new Link
                                               {
                                                   Title = "All Categories",
                                                   Rel = "all",
                                                   Href = "/api/categories"
                                               }
                                       }
                       };
        }
    }
}