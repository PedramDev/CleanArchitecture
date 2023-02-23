using CleanArchitecture.Application.Context;
using CleanArchitecture.Domain.Entities.Shop.Products;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Tools.Data;
using CleanArchitecture.Tools.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.Shop.Products
{
    public class ProductService : ApplicationService , IProductService
    {
        private readonly ProductDomainService _productDomainService;
        private readonly IProductRepository _repo;
        private readonly IEmailSender _emailSender;
        private readonly IGuidService _guidService;
        //private readonly IAppDbContext _appDbContext;
        private readonly AppDbContext _appDbContext;

        public async Task AddVariant(Guid productId, string name)
        {
            var product = await _productDomainService.AddNewVariant(productId, new Variant(_guidService.CreateNew(), name, productId));

            _appDbContext.Update(product);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
