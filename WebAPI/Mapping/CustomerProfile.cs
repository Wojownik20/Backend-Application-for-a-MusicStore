using AutoMapper;
using LeverX.WebAPI.Features.Customers.Dto;
using MusicStore.Core.Data;

namespace LeverX.WebAPI.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerReadDto, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

        }
    }
}