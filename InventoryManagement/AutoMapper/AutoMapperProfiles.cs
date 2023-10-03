using InventoryManagement.Dtos;
using InventoryManagement.Models;
using AutoMapper;

namespace InventoryManagement.AutoMapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            //CreateMap<UserDTO, UserDomainModel>().ForMember(x => x.FullName, option => option.MapFrom(x=> x.DisplayName))
            //    .ReverseMap();

            CreateMap<UserDetailDto, User>().ReverseMap();
            CreateMap<UserLoginDto, User>().ReverseMap();
            CreateMap<UserRegistrationDto, User>().ReverseMap();
        }

    }
}
