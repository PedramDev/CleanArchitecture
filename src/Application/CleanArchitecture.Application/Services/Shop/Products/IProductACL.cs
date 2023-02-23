using CleanArchitecture.Domain.Entities.Shop.Products;
using CleanArchitecture.Tools.Marker;

namespace CleanArchitecture.Application.Services.Shop.Products
{
    /// <summary>
    /// در صورتی که نیاز به استفاده از اطلاعات یک 
    /// Aggregate Root
    /// در سرویس دیگیری بود* حتما از ACL
    /// استفاده میکنیم و باید از سرویس های عادی سیستم جدا شود
    /// </summary>
    public interface IProductACL : IApplicationService
    {
        Task<List<Product>> GetProductListByCategory(long categoryId);
    }
}
