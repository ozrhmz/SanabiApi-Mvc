using App.Core.DTOs;
using App.Core.Models;
using AutoMapper;

namespace App.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<Adress, AdressDto>().ReverseMap();
            CreateMap<AdressUpdateDto, Adress>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<OrderStatus, OrderStatusDto>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
            CreateMap<Admin, AdminDto>().ReverseMap();
        }
    }
}
