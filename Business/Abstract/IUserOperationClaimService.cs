using Core.Utilities.Results;
using DTOs.UserOperationClaims;

namespace Business.Abstract;

public interface IUserOperationClaimService
{
    IResult Add(UserOperationClaimDto dto);
    IResult Update(UserOperationClaimDto dto);
    IResult Delete(int id);
    IDataResult<List<UserOperationClaimDto>> GetAll(int index, int sizeCount);
}