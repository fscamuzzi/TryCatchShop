using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business;
using DTO.Dto;
using Logging;

namespace TryCatchShop.Mapping
{
    public static class AspNetUserDTO
    {
        #region PRIVATE FIELDS
        private static readonly Logger _logger = new Logger();
        #endregion

        public static AspNetUsers ToDTO(this AspNetUser aspnetuser)
        {
            try
            {
                Mapper.CreateMap<AspNetUser, AspNetUsers>();
                //Mapper.CreateMap<user, Users>().ForMember(x => x.AspNetUser, y => y.Ignore());

                var u = Mapper.Map<AspNetUser, AspNetUsers>(aspnetuser);
            //    Mapper.Map<user, Users>(aspnetuser.users.FirstOrDefault(), u.Users);

                return u;
            }
            catch (Exception e)
            {
                _logger.LogError("Mapping aspnetuser error in DTO mapping");
                _logger.LogException(e);

                throw;
            }
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <returns></returns>
        public static AspNetUser ToEF(this AspNetUsers user)
        {
            try
            {
                Mapper.CreateMap<AspNetUsers, AspNetUser>();
                return Mapper.Map<AspNetUsers, AspNetUser>(user);
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
        /// <param name="user">The stock products.</param>
        /// <returns></returns>
        public static List<AspNetUsers> ToDTO(this List<AspNetUser> user)
        {
            return user.Select(p => p.ToDTO()).ToList();
        }

        /// <summary>
        /// To the ef.
        /// </summary>
        /// <returns></returns>
        public static List<AspNetUser> ToEF(this List<AspNetUsers> user)
        {
            return user.Select(p => p.ToEF()).ToList();
        }
    }
}