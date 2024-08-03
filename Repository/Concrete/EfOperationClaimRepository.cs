using Core.Entities;
using Core.Persistence.Repositories;
using Repository.Abstract;
using Repository.Contexts;

namespace Repository.Concrete;

public class EfOperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    public EfOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}