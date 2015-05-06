using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Business;
using DTO.DTO;

namespace TryCatchShop.Mapping
{
    public static class ProductMapping
    {
        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static Product ToDTO(this product address)
        {
            Mapper.CreateMap<product, Product>()
                .ForMember(x => x.ProductImage, y => y.Ignore());

            Mapper.CreateMap<product_image, ProductImage>()
                .ForMember(x => x.Product, y => y.Ignore());

            var product = Mapper.Map<product, Product>(address);
            Mapper.Map(address.product_image, product.ProductImage);
            return product;
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public static product ToEF(this Product address)
        {
            Mapper.CreateMap<Product, product>()
                .ForMember(x => x.product_image, y => y.Ignore());

            Mapper.CreateMap<ProductImage, product_image>()
             .ForMember(x => x.product, y => y.Ignore());

            var prod = Mapper.Map<Product, product>(address);
            Mapper.Map(address.ProductImage, prod.product_image);
            return prod;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<Product> ToDTO(this List<product> address)
        {
            return address.Select(o => o.ToDTO()).ToList();
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<product> ToEF(this List<Product> address)
        {
            return address.Select(p => p.ToEF()).ToList();
        }
    }
}