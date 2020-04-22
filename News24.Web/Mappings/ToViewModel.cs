using AutoMapper;
using News24.Model;
using News24.Web.ViewModels.StartViewModels;

namespace News24.Web.Mappings
{
    public class ToViewModel : Profile
    {
        public ToViewModel()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<Category, ArticleCategoryViewModel>();
            CreateMap<Category,CategoryViewModel >();
        }
    }
}