using AutoMapper;
using Business;
using DTO.DTO;
using System.Collections.Generic;
using System.Linq;

namespace TryCatchShop.Mapping
{
    public static class CustomerMapping
    {
        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static Customer ToDTO(this customer address)
        {
            Mapper.CreateMap<customer, Customer>();
            //return Mapper.Map<address, address>(address);
            return Mapper.Map<customer, Customer>(address);
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public static customer ToEF(this Customer address)
        {
            Mapper.CreateMap<Customer, customer>();
            return Mapper.Map<Customer, customer>(address);
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<Customer> ToDTO(this List<customer> address)
        {
            return address.Select(o => o.ToDTO()).ToList();
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <param name="address">The stock address.</param>
        /// <returns></returns>
        public static List<customer> ToEF(this List<Customer> address)
        {
            return address.Select(p => p.ToEF()).ToList();
        }
    }
}