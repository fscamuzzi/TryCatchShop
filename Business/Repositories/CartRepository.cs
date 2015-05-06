using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.IRepositories;
using DTO.DTO;
using Logging;
using System.Data.Entity;
using System.Linq;

namespace Business.Repositories
{
    public class CartRepository : Repository<cart>, ICartRepository
    {
        private readonly Logger _logger = new Logger();
        private readonly TryCatchShopEntities _dbCcontext;

        public CartRepository()
            : this(new TryCatchShopEntities())
        {
        }

        public CartRepository(TryCatchShopEntities context)
            : base(context)
        {
            _dbCcontext = context;
        }

        /// <summary>
        /// Finds the by identifier customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public cart FindByIdCustomer(customer customer)
        {
            try
            {
                var cart = _dbCcontext.carts.Where(h => h.customer_id.Equals(customer.id)).FirstOrDefault();
                return cart;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                throw;
            }
        }

     
    }
}