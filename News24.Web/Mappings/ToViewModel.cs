using AutoMapper;
using News24.Model;
using News24.Web.ViewModels;
using News24.Web.ViewModels.ArticleViewModel;
using News24.Web.ViewModels.StartViewModels;

namespace News24.Web.Mappings
{
    public class ToViewModel : Profile
    {
        public ToViewModel()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<Category, ArticleCategoryViewModel>();
            CreateMap<Category, CategoryViewModel>();

            CreateMap<Article, ArticleDetailsViewModel>();
            CreateMap<User, ContactInfoViewModel>().ForMember(
                x => x.Image,
                opt => opt.MapFrom(src => src.AccountImage));
        }
    }
}