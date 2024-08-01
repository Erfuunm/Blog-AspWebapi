using AutoMapper;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;

namespace Blog_dotNetApi.Helper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles() {

            //this class is used for Autommaper 

            CreateMap<Article, ArticleDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Publisher, PublisherDto>();

            CreateMap<ArticleDto, Article>();

            CreateMap<CategoryDto, Category>();

        
        }
    }
}
