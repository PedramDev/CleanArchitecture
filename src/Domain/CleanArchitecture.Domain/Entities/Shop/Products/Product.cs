using CleanArchitecture.Tools.Exceptions;
using CleanArchitecture.Tools.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Shop.Products
{
    public class Product : IAggregateRoot
    {
        public Guid Id { get; private set; }


        public string Name { get; private set; }

        public ICollection<Variant> Items { get; private set; }

        #region Constructors

        #endregion


        #region Properties

        /// <summary>
        /// for efcore
        /// </summary>
        private Product()
        {
            Items = new List<Variant>();
        }

        public Product(Guid id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        #endregion


        public void AddNewItem(Variant variant)
        {
            //بررسی اینکه داپلیکیت نباشد و ... هم میتونید انجام بدین
            Items.Add(variant);
        }

        public void UpdateVariant(Guid variantId, string name)
        {
            var variant = Items.FirstOrDefault(x => x.Id == variantId);
            if (variant != null)
            {
                variant.UpdateProperties(name);
            }
            else
            {
                throw new UserFriendlyException("variant nto found");
            }

        }

    }
}
