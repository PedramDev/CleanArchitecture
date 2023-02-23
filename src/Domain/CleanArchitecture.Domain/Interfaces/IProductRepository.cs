using CleanArchitecture.Domain.Entities.Shop.Products;
using CleanArchitecture.Tools.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product, Guid>
    {
        Task<bool> IsProductInPromotion(Guid id);
        Task<Product> GetProduct(Guid id);
    }
}
