using Core.Entities;
using Core.Persistence.Repositories;

namespace Repository.Abstract;

public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int>
{
    /// <summary>
    /// Gelen kullanıcının sahip olduğu rolleri getirir.
    /// </summary>
    /// <param name="User"></param>
    /// <returns></returns>
    List<OperationClaim> GetClaims(User User);

    User GetByEmail(string email);
}