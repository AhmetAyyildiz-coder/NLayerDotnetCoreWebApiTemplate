using Core.Entities;
using Core.Persistence.Repositories;

namespace Repository.Abstract;

public interface IUserOperationRepository :IAsyncRepository<UserOperationClaim, int>, IRepository<UserOperationClaim, int>
{

}