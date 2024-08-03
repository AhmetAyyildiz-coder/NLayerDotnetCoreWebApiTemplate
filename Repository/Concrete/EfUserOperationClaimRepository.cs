using Core.Entities;
using Core.Persistence.Repositories;
using Repository.Abstract;
using Repository.Contexts;

namespace Repository.Concrete;

public class EfUserOperationRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationRepository
{
    public EfUserOperationRepository(BaseDbContext context) : base(context)
    {
    }
}
