using CleanArchitecture.Tools.Exceptions;

namespace CleanArchitecture.Domain.Entities.Shop.Products
{
    public class Variant
    {
        #region Constructors

        /// <summary>
        /// for ef
        /// </summary>
        private Variant(){ }

        /// <summary>
        /// new variant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="productId"></param>
        public Variant(Guid id, string name, Guid productId)
        {
            Id = id;
            ProductId = productId;
            CreatedAt = DateTime.Now;

            SetName(name);
        }

        #endregion

        #region Methods

        public void UpdateProperties(string name)
        {
            SetName(name);
        }

        internal void SetName(string name)
        {
            if(name == null || string.IsNullOrWhiteSpace(name))
            {
                throw new UserFriendlyException("نام تنوع نمیتواند خالی باشد");
            }

            if(name.Length >= 150)
            {
                throw new UserFriendlyException("نام تنوع نمیتواند بیشتر از ۱۵۰ کاراکتر باشد");
            }

            Name = name;
        }

        #endregion

        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public DateTime CreatedAt { get; private set; }

        #endregion

        #region Navigations

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        
        #endregion

    }


}
