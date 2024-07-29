using AutoMapper;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;

namespace Blog_dotNetApi.Helper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles() {

            CreateMap<Article, ArticleDto>();
            CreateMap<Category, CategoryDto>();
        
        }
    }
}
