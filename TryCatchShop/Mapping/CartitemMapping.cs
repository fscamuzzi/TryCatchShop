using AutoMapper;
using Business;
using DTO.DTO;
using System.Collections.Generic;
using System.Linq;

namespace TryCatchShop.Mapping
{
    public static class CartItemMapping
    {
        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static CartItem ToDTO(this cart_item address)
        {
            Mapper.CreateMap<cart_item, CartItem>();
            //return Mapper.Map<address, address>(address);
            return Mapper.Map<cart_item, CartItem>(address);
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public static cart_item ToEF(this CartItem address)
        {
            Mapper.CreateMap<CartItem, cart_item>();
            return Mapper.Map<CartItem, cart_item>(address);
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<CartItem> ToDTO(this List<cart_item> address)
        {
            return address.Select(o => o.ToDTO()).ToList();
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<cart_item> ToEF(this List<CartItem> address)
        {
            return address.Select(p => p.ToEF()).ToList();
        }
    }
}