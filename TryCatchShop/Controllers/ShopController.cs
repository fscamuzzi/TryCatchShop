using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using Business.IRepositories;
using DTO.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TryCatchShop.Mapping;

namespace TryCatchShop.Controllers
{
    public class ShopController : ApiController
    {
        private ICartRepository _cartRepository { get; set; }

        public ShopController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // GET: api/Shop
        public async Task<List<Cart>> Get()
        {
            var carts = await _cartRepository.GetAllAsync();
            return carts.ToList().ToDTO();
        }

        // GET: api/Shop/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shop
        public void Post([FromBody]Cart cart)
        {

        }

        // PUT: api/Shop/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shop/5
        public void Delete(int id)
        {
        }

    
    }
}