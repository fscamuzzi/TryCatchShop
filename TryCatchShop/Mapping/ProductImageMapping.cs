using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Business;
using DTO.DTO;

namespace TryCatchShop.Mapping
{
    public static class ProductImageMapping
    {
        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static ProductImage ToDTO(this product_image address)
        {
            Mapper.CreateMap<product_image, ProductImage>()
                 .ForMember(x => x.Product, y => y.Ignore());

            Mapper.CreateMap<product, Product>()
               .ForMember(x => x.ProductImage, y => y.Ignore());

            var productImage = Mapper.Map<product_image, ProductImage>(address);
            Mapper.Map(address.product, productImage.Product);

            return productImage;
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public static product_image ToEF(this ProductImage address)
        {
            Mapper.CreateMap<ProductImage, product_image>();
            return Mapper.Map<ProductImage, product_image>(address);
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<ProductImage> ToDTO(this List<product_image> address)
        {
            return address.Select(o => o.ToDTO()).ToList();
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<product_image> ToEF(this List<ProductImage> address)
        {
            return address.Select(p => p.ToEF()).ToList();
        }
    }
}