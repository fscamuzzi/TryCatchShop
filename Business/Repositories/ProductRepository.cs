using System.Threading.Tasks;
using Business.IRepositories;
using Logging;

namespace Business.Repositories
{
    public class ProductRepository : Repository<product>, IProductRepository
    {
        private readonly Logger _logger = new Logger();
        private readonly TryCatchShopEntities _dbCcontext;

        public ProductRepository()
            : this(new TryCatchShopEntities())
        {
        }

        public ProductRepository(TryCatchShopEntities context)
            : base(context)
        {
            _dbCcontext = context;
        }

        public Task<product> FindByCartId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}