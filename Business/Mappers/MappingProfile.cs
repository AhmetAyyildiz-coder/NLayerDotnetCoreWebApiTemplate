using AutoMapper;
using Core.Entities;
using Core.Persistence.Paging;
using DTOs.OperationClaims;
using DTOs.UserOperationClaims;
using DTOs.Users;

namespace Business.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserListDto>().ReverseMap();


        CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();


        CreateMap<User, UserForOperationClaimDto>().ReverseMap();

        CreateMap<UserOperationClaim, UserOperationClaimDto>().ReverseMap();

        CreateMap<UserForRegisterDto, UserForOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaimDto, OperationClaim>().ReverseMap();

        // UserForLoginDto Mapping
        CreateMap<UserForLoginDto, User>().ReverseMap();
        
        CreateMap<User, UserListDto>();
        
        // paginate user paginate user list dto 
        CreateMap<Paginate<User>, Paginate<UserListDto>>();


    }
}