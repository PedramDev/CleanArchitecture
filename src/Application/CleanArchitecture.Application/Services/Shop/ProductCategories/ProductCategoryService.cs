using CleanArchitecture.Application.Services.Shop.Products;
using CleanArchitecture.Tools.Marker;

namespace CleanArchitecture.Application.Services.Shop.ProductCategories
{
    public class ProductCategoryService : ApplicationService, IProductCategoryService
    {
        private readonly IProductACL _productACL;
        private readonly IProductCategoryRepository _repo;

        public ProductCategoryService(IProductACL productACL, IProductCategoryRepository repo)
        {
            _productACL = productACL;
            _repo = repo;
        }

        public async Task CalculateCategoryProducts(long categoryId)
        {
            //این فقط یک مثال بیخودیه
           var listOfCategories = await _productACL.GetProductListByCategory(categoryId);
            await Task.CompletedTask;
        }
    }
}
