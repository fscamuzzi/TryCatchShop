using System.Collections.Generic;

namespace DTO.DTO
{
    public class ProductImage
    {
        public int id { get; set; }

        public int? productId { get; set; }

        public string image { get; set; }

        public Product Product { get; set; }
    }
}