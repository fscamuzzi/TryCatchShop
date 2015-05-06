using Business;
using Business.IRepositories;
using DTO.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Logging;
using TryCatchShop.Mapping;

namespace TryCatchShop.Controllers
{

    public class ProductController : ApiController
    {
        private readonly IProductRepository repository;
        private readonly Logger _logger = new Logger();

        public ProductController(IProductRepository _repo)
        {
            repository = _repo;
        }

        // GET: api/Product
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> Get()
        {
            var prod = await repository.GetAllAsync();
            return prod.ToList().ToDTO();
        }

        // GET: api/Product/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Product> Get(int id)
        {
            var entity = await repository.FindAsync(x => x.id == id);
            return entity.ToDTO();
        }

        // POST: api/Product
        /// <summary>
        /// Posts the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<Product> Post([FromBody]Product product)
        {
            try
            {
                if (product == null) return null;
                var task = await repository.AddAsync(product.ToEF());
                return task.ToDTO();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                throw;
            }
        }

        // PUT: api/Product/5
        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<Product> Put(int id, [FromBody]Product product)
        {
            var updateAsync = await repository.UpdateAsync(product.ToEF(), id);
            return updateAsync.ToDTO();
        }

        // DELETE: api/Product/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<int> Delete(int id)
        {
            var entity = await repository.FindAsync(x => x.id == id);
            int rows = await repository.DeleteAsync(entity);
            return rows;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/Product/UploadFile")]
        public Task<HttpResponseMessage> UploadFile()
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType));
            }

            string root = HttpContext.Current.Server.MapPath("~/content/images");
            var provider = new MultipartFormDataStreamProvider(root);

            var task = request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(o =>
                {
                    var finfo = new FileInfo(provider.FileData.First().LocalFileName);

                    string guid = Guid.NewGuid().ToString();

                    var fileName = guid + "_" + provider.FileData.First().Headers.ContentDisposition.FileName.Replace("\"", "");

                    File.Move(finfo.FullName, Path.Combine(root, fileName));

                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(fileName)
                    };
                });

            return task;
        }
    }
}