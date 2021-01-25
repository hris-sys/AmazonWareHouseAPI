using AmazonWareHouse.Business.Models.Categories;
using AmazonWareHouse.Business.Models.Cities;
using AmazonWareHouse.Business.Models.Items;
using AmazonWareHouse.Business.Models.Order;
using AmazonWareHouse.Business.Models.Users;
using AutoMapper;
using Data.Models.Common;
using Data.Models.Models;
using System.Linq;

namespace API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginModel>().ReverseMap();
            CreateMap<User, UserAuthModel>().ReverseMap();

            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Category, CreateCategoryModel>().ReverseMap();
            CreateMap<City, CityModel>().ReverseMap();
            CreateMap<City, CreateCityModel>().ReverseMap();

            CreateMap<Item, CreateItemModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();

            CreateMap<UserModel, User>().ReverseMap();

            CreateMap<Item, ItemModel>().ReverseMap();

            CreateMap<User, CreateUserModel>()
                .ForMember(um => um.IsAdmin, u => u.MapFrom(x => x.Role == UserRoles.Admin));

            CreateMap<CreateUserModel, User>()
                .ForMember(u => u.Role, um => um.MapFrom(x => x.IsAdmin ? UserRoles.Admin : UserRoles.User));

            CreateMap<User, EditUserModel>()
                .ForMember(um => um.IsAdmin, u => u.MapFrom(x => x.Role == UserRoles.Admin));

            CreateMap<EditUserModel, User>()
                .ForMember(u => u.Role, um => um.MapFrom(x => x.IsAdmin ? UserRoles.Admin : UserRoles.User));

            CreateMap<ItemModel, Item>()
                .ForMember(i => i.OrderItems, im => im.MapFrom(x => x.OrderItemsIds
                            .Select(u => new OrderItem { Id = u })))
                .ForMember(i => i.ItemCategories, im => im.MapFrom(x => x.ItemCategoriesIds
                            .Select(u => new ItemCategory { Id = u })));

            CreateMap<Item, ItemModel>()
                .ForMember(i => i.ItemCategoriesIds, im => im.MapFrom(x => x.ItemCategories.Select(u => u.Id)))
                .ForMember(i => i.OrderItemsIds, im => im.MapFrom(x => x.OrderItems.Select(u => u.Id)));


        }
    }
}
