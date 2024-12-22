using AutoMapper;
using product_category_api.DTOs.CategoryDtos;
using product_category_api.DTOs.ProductDtos;
using product_category_api.Models;

namespace product_category_api.Mapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        CreateMap<GetCategoryDto, Category>().ReverseMap();
        CreateMap<GetAllCategoryDto, Category>().ReverseMap();
        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
        CreateMap<GetProductDto, Product>().ReverseMap();
        CreateMap<GetAllProductDto, Product>().ReverseMap();
    }
}