using AutoMapper;
using Business;
using DTO.Dto;
using Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TryCatchShop.Mapping
{
    public static class AspNetRoleDTO
    {
        #region PRIVATE FIELDS

        private static readonly Logger _logger = new Logger();

        #endregion PRIVATE FIELDS

        public static AspNetRoles ToDTO(this AspNetRole aspnetrole)
        {
            try
            {
                Mapper.CreateMap<AspNetRole, AspNetRoles>();

                var u = Mapper.Map<AspNetRole, AspNetRoles>(aspnetrole);
                return u;
            }
            catch (Exception e)
            {
                _logger.LogError("Mapping aspnetrole error in DTO mapping");
                _logger.LogException(e);

                throw;
            }
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <returns></returns>
        public static AspNetRole ToEF(this AspNetRoles aspnetrole)
        {
            try
            {
                Mapper.CreateMap<AspNetRoles, AspNetRole>();
                return Mapper.Map<AspNetRoles, AspNetRole>(aspnetrole);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="aspnetrole">The stock products.</param>
        /// <returns></returns>
        public static List<AspNetRoles> ToDTO(this List<AspNetRole> aspnetrole)
        {
            return aspnetrole.Select(p => p.ToDTO()).ToList();
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <returns></returns>
        public static List<AspNetRole> ToEF(this List<AspNetRoles> aspnetrole)
        {
            return aspnetrole.Select(p => p.ToEF()).ToList();
        }
    }
}