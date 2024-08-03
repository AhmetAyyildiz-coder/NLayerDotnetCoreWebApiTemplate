using AutoMapper;
using Business.Abstract;
using Business.Utilities;
using Core.Entities;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using DTOs.Users;
using Repository.Abstract;
using Serilog;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userDal;

    public UserManager(IUserRepository userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public IDataResult<List<OperationClaim>> GetClaims(User user)
    {
        try
        {
            return new DataResult<List<OperationClaim>>(_userDal.GetClaims(user), true);
        }
        catch (Exception e)
        {
            return new DataResult<List<OperationClaim>>(null, false);
        }
    }

    public IResult Add(User user)
    {
        try
        {
            _userDal.Add(user);
            return new Result(true);
        }
        catch (Exception e)
        {
            return new Result(false, e.Message);
        }
    }

    public IDataResult<User?> GetByEmail(string email)
    {
        try
        {
            return new DataResult<User?>(_userDal.Get(u => u.Email == email), true);
        }
        catch (Exception e)
        {
            return new DataResult<User?>(null, false, e.Message);
        }
    }

    public IResult Update(User user)
    {
        try
        {
            _userDal.Update(user);
            return new Result(true);
        }
        catch (Exception e)
        {
            return new Result(false, e.Message);
        }
    }

    public IResult DeleteUser(string userEmail)
    {
        var user = _userDal.Get(u => u.Email == userEmail);
        if (user == null) return new Result(false, Messages.UserNotFound);

        try
        {
            _userDal.Delete(user);
            return new Result(true);
        }
        catch (Exception e)
        {
            return new Result(false, e.Message);
        }
    }

    public IResult UpdateUser(UserForUpdateDto userDto)
    {
        var user = _userDal.Get(u => u.Email == userDto.Email);
        if (user == null) return new Result(false, Messages.UserNotFound);

        try
        {
            _mapper.Map(userDto, user);
            _userDal.Update(user);
            return new Result(true);
        }
        catch (Exception e)
        {
            return new Result(false, e.Message);
        }
    }

    public IDataResult<Paginate<UserListDto>> GetUsers(int index,int size)
    {
        try
        {
            var data = _userDal.GetList(size: size, index: index);
            return new DataResult<Paginate<UserListDto>>(_mapper.Map<Paginate<UserListDto>>(data), true);
        }
        catch (Exception e)
        {

            return new DataResult<Paginate<UserListDto>>(null, false, e.Message);
        }
    }
}