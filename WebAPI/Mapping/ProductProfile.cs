using AutoMapper;
using LeverX.WebAPI.Features.Products.Dto;
using MusicStore.Core.Data;

namespace LeverX.WebAPI.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductReadDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

        }
    }
}