using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    public class Cart
    {

        public int id { get; set; }
        public string Userid { get; set; }
        public DateTime? SubmitDate { get; set; }
        public int? Status { get; set; }
        public int? PaymentGtw { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? CustomerId { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        //public virtual customer customer { get; set; }
        //public virtual ICollection<cart_item> cart_item { get; set; }
    }
}
