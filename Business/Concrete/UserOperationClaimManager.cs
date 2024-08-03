using AutoMapper;
using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
using DTOs.UserOperationClaims;
using Repository.Abstract;
using Serilog;

namespace Business.Concrete;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private readonly IMapper _mapper;
    private readonly IUserOperationRepository _userOperationClaimDal;
    private readonly ILogger logger;

    public UserOperationClaimManager(IUserOperationRepository userOperationClaimDal, IMapper mapper, ILogger logger)
    {
        _userOperationClaimDal = userOperationClaimDal;
        _mapper = mapper;
        this.logger = logger;
    }

    public IResult Add(UserOperationClaimDto dto)
    {
        try
        {
            _userOperationClaimDal.Add(_mapper.Map<UserOperationClaim>(dto));
            return new Result(true);
        }
        catch (Exception e)
        {
            logger.LogDetailedException(e);
            return new Result(false, e.Message);
        }
    }

    public IResult Update(UserOperationClaimDto dto)
    {
        try
        {
            _userOperationClaimDal.Update(_mapper.Map<UserOperationClaim>(dto));
            return new Result(true);
        }
        catch (Exception e)
        {
            logger.LogDetailedException(e);
            return new Result(false, e.Message);
        }
    }

    public IResult Delete(int id)
    {
        try
        {
            _userOperationClaimDal.Delete(_userOperationClaimDal.Get(u => u.Id == id));
            return new Result(true);
        }
        catch (Exception e)
        {
            logger.LogDetailedException(e);
            return new Result(false, e.Message);
        }
    }

    public IDataResult<List<UserOperationClaimDto>> GetAll(int index, int sizeCount)
    {
        try
        {
            var data = _userOperationClaimDal.GetList(index: index, size: sizeCount);
            return new DataResult<List<UserOperationClaimDto>>(
                _mapper.Map<List<UserOperationClaimDto>>(data.Items.ToList()), true);
        }
        catch (Exception e)
        {
            logger.LogDetailedException(e);
            return new DataResult<List<UserOperationClaimDto>>(null, false, e.Message);
        }
    }
}