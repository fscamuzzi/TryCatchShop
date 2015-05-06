using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IContext
{
    interface ICartContext
    {

        DbSet<cart> Carts { get; set; }
        DbSet<customer> Customers { get; set; }
        int SaveChanges();

    }
}
