using InventoryManagement.Models;
using AutoMapper;
using InventoryManagement.Dtos.ProductDto;
using InventoryManagement.Dtos.AuthDto;
using InventoryManagement.Dtos.StockDto;
using InventoryManagement.Dtos.IssueProductDto;

namespace InventoryManagement.AutoMapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            /*       CreateMap<UserDetailDto, User>().ForMember(x => x.FullName, option => option.MapFrom(x => x.DisplayName))
                       .ReverseMap();*/

            CreateMap<UserDetailDto, User>()
                .ReverseMap();
            CreateMap<UserLoginDto, User>().ReverseMap();
            CreateMap<UserRegistrationDto, User>().ReverseMap();

            CreateMap<CreateStockDto, Stock>().ReverseMap();

            CreateMap<CreateIssueProductDto, IssueProduct>().ReverseMap();
        }

    }
}
