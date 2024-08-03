using Core.Entities;
using Core.Persistence.Repositories;

namespace Repository.Abstract;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>, IRepository<OperationClaim, int>
{ }
