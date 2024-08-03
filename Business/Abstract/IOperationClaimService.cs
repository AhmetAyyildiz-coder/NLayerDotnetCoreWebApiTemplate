using Core.Entities;
using Core.Utilities.Results;
using DTOs.OperationClaims;

namespace Business.Abstract;

public interface IOperationClaimService
{
    IDataResult<List<OperationClaim>> GetAll(int index, int sizeCount);
    IResult Add(OperationClaimDto dto);
    IResult Update(OperationClaimDto dto);
    IResult Delete(int id);
}