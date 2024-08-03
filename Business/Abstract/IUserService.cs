using Core.Entities;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using DTOs.Users;

namespace Business.Abstract;

public interface IUserService
{
    IDataResult<List<OperationClaim>> GetClaims(User user);
    IResult Add(User user);
    IDataResult<User?> GetByEmail(string email);
    IResult Update(User user);
    IResult DeleteUser(string userEmail);

    IResult UpdateUser(UserForUpdateDto userDto);
    IDataResult<Paginate<UserListDto>> GetUsers(int index,int size);
}