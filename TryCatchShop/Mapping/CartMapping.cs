using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Business;
using DTO.DTO;
using Microsoft.Owin.BuilderProperties;

namespace TryCatchShop.Mapping
{
    public static class CartMapping
    {
        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static Cart ToDTO(this cart address)
        {
            Mapper.CreateMap<cart, Cart>();
            //return Mapper.Map<address, address>(address);
            return Mapper.Map<cart, Cart>(address);
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public static cart ToEF(this Cart address)
        {
            Mapper.CreateMap<Cart, cart>();
            return Mapper.Map<Cart, cart>(address);
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<Cart> ToDTO(this List<cart> address)
        {
            return address.Select(o => o.ToDTO()).ToList();
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<cart> ToEF(this List<Cart> address)
        {
            return address.Select(p => p.ToEF()).ToList();
        }
    }
}