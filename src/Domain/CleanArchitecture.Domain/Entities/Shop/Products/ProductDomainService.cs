using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Tools.Exceptions;
using CleanArchitecture.Tools.Marker;

namespace CleanArchitecture.Domain.Entities.Shop.Products
{
    public class ProductDomainService : DomainService
    {
        /// <summary>
        /// فقط ریپوزیتوری مربوط به همین موجودیت
        /// </summary>
        private readonly IProductRepository _repo;

        public ProductDomainService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Product> AddNewVariant(Guid productId, Variant variant)
        {
            var existInPromotion = await _repo.IsProductInPromotion(productId);
            if(existInPromotion)
            {
                throw new UserFriendlyException("محصول در پروموشن است!");
            }


            //بجای خط پایین میتونید همینجا از context بخونید
            //بهتر هم هست
            var product = await _repo.GetProduct(productId);



            product.AddNewItem(variant);

            return product;
        }

    }


}
