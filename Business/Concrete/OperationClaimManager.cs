using AutoMapper;
using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
using DTOs.OperationClaims;
using Repository.Abstract;

namespace Business.Concrete;

public class OperationClaimManager : IOperationClaimService
{
    private readonly IMapper _mapper;
    private readonly IOperationClaimRepository _operationClaimDal;

    public OperationClaimManager(IOperationClaimRepository operationClaimDal, IMapper mapper)
    {
        _operationClaimDal = operationClaimDal;
        _mapper = mapper;
    }

    public IDataResult<List<OperationClaim>> GetAll(int index, int sizeCount)
    {
        try
        {
            var data = _operationClaimDal.GetList(index: index, size: sizeCount);
            return new DataResult<List<OperationClaim>>(data.Items.ToList(), true);
        }
        catch (Exception e)
        {
            return new DataResult<List<OperationClaim>>(null, false, e.Message);
        }
    }

    public IResult Add(OperationClaimDto dto)
    {
        try
        {
            _operationClaimDal.Add(_mapper.Map<OperationClaim>(dto));
            return new Result(true);
        }
        catch (Exception e)
        {
            return new Result(false, e.Message);
        }
    }

    public IResult Update(OperationClaimDto dto)
    {
        try
        {
            _operationClaimDal.Update(_mapper.Map<OperationClaim>(dto));
            return new Result(true);
        }
        catch (Exception e)
        {
            return new Result(false, e.Message);
        }
    }

    public IResult Delete(int id)
    {
        try
        {
            _operationClaimDal.Delete(new OperationClaim { Id = id });
            return new Result(true);
        }
        catch (Exception e)
        {
            return new Result(false, e.Message);
        }
    }
}