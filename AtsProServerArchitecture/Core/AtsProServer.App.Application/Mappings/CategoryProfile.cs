using AtsProServer.App.Application.Dtos;
using AtsProServer.App.Domain.Entities;
using AutoMapper;

namespace AtsProServer.App.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category,CategoryListDto>().ReverseMap();
            this.CreateMap<Category,CreatedCategoryResponseDto>().ReverseMap();
        }
    }
}
