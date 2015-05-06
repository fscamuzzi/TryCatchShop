using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DTO.DTO;

namespace Business.IRepositories
{
    public interface ICartRepository : IRepository<cart>
    {
        cart FindByIdCustomer(customer customer);
    }
}
