//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public product()
        {
            this.product_image = new HashSet<product_image>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<int> first_image_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> locked_amount { get; set; }
        public Nullable<decimal> avaiable { get; set; }
        public System.DateTime insert_date { get; set; }
    
        public virtual ICollection<product_image> product_image { get; set; }
    }
}