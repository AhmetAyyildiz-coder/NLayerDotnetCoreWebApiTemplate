using Core.Entities;
using Core.Persistence.Repositories;
using Repository.Abstract;
using Repository.Contexts;


namespace Repository.Concrete;

public class EfUserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
{
    public EfUserRepository(BaseDbContext context) : base(context)
    {
    }

    public List<OperationClaim> GetClaims(User User)
    {
        return (from uop in Context.UserOperationClaims
                join u in Context.Users
                    on uop.UserId equals u.Id
                join op in Context.OperationClaims
                    on uop.OperationClaimId equals op.Id
                select new OperationClaim()
                {
                    Id = op.Id,
                    Name = op.Name
                }).ToList();
    }

    public User GetByEmail(string email)
    {
        return Context.Users.FirstOrDefault(u => u.Email == email);
    }
}