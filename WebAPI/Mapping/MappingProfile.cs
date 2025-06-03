using AutoMapper;
using LeverX.WebAPI.ModelsDto;
using MusicStore.Core.Data;
using WebAPI.ModelsDto;

namespace LeverX.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductReadDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerReadDto, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderReadDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeReadDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

        }
    }
}