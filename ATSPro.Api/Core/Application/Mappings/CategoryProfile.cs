using ATSPro.Api.Core.Application.Dto;
using ATSPro.Api.Core.Domain;
using AutoMapper;

namespace ATSPro.Api.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category,CategoryListDto>().ReverseMap();
        }
    }
}
