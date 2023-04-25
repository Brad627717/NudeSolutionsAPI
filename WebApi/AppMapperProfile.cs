using AutoMapper;
using WebApi.Data.Entities;
using WebApi.Dtos;

namespace WebApi
{
    public class AppMapperProfile: Profile
    {

        public AppMapperProfile()
        {
            CreateMap<InsuredItemDto, InsuredItem>();

            CreateMap<InsuredItem, InsuredItemDto>();

            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryDto>();
        }
    }
}
