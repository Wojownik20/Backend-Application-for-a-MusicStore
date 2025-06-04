using AutoMapper;
using LeverX.WebAPI.Features.Orders.Dto;
using MusicStore.Core.Data;

namespace LeverX.WebAPI.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderReadDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

        }
    }
}