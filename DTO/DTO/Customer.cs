using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Dto;

namespace DTO.DTO
{
    public class Customer
    {

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string aspNetId { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Cart> carts { get; set; }
    }
}
