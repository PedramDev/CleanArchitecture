using CleanArchitecture.Tools.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.Shop.ProductCategories
{
    public interface IProductCategoryService : IApplicationService
    {
        Task CalculateCategoryProducts(long categoryId);
    }
}
