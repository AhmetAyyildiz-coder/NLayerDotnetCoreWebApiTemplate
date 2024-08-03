using Core.Persistence.Repositories;
using Entities;
using Repository.Abstract;
using Repository.Contexts;

namespace Repository.Concrete;

public class EfProductRepository : EfRepositoryBase<Product, int, BaseDbContext>, IProductRepository
{
    public EfProductRepository(BaseDbContext context) : base(context)
    {
    }
}
