using AutoMapper;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.EditAddress;
using Shop.Web.ViewModels.ShopCart;
using ShopUi.ViewModels.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddUserAddressCommand, AddAddressViewModel>().ReverseMap();
            //CreateMap<UserAddressDto, EditAddressViewModel>().ReverseMap();
            CreateMap<EditUserAddressCommand, EditAddressViewModel>().ReverseMap();
            CreateMap<AddToShopCartViewModel, ShopCartItemViewModel>().ReverseMap();
        }
    }
}
