using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO
{
    public class Product
    {
        private List<ProductImage> _productImage = new List<ProductImage>();
        private int? _lockedAmount = 0;

        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public decimal? qty { get; set; }

        public int? firstImageId { get; set; }

        public decimal? price { get; set; }

        public int? lockedAmount
        {
            get { return _lockedAmount; }
            set { _lockedAmount = value; }
        }

        public decimal? avaiable { get; set; }

        public DateTime insertDate { get; set; }

        public List<ProductImage> ProductImage
        {
            get { return _productImage; }
            set { _productImage = value; }
        }
    }
}