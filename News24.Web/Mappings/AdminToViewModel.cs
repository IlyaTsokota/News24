using AutoMapper;
using News24.Model;
using News24.Web.Areas.Admin.ViewModels.ArticleViewModels;
using News24.Web.Areas.Admin.ViewModels.CategoryViewModels;
using News24.Web.Areas.Admin.ViewModels.LogViewModels;
using News24.Web.Areas.Admin.ViewModels.TagViewModel;
using News24.Web.Areas.Admin.ViewModels.UserViewModels;

namespace News24.Web.Mappings
{
    public class AdminToViewModel : Profile
    {
        public AdminToViewModel()
        {
            //Article
            CreateMap<Article, ArticleViewModel>();
            CreateMap<Article, DetailsArticleViewModel>();
            CreateMap<Article, IndexArticleViewModel>();
            CreateMap<Article, EditArticleViewModel>();

            //Category
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, EditCategoryViewModel>();
            CreateMap<Category, ArticleCategoryViewModel>();
            //Log
            CreateMap<Log, LogViewModel>()
                .ForMember(
                m=> m.Message,
                opt=> opt.MapFrom(
                    p => p.Message.Substring(0, p.Message.Length > 200 ? 200 : p.Message.Length) + "..."));

            //User
            CreateMap<User, UserViewModel>().ForMember(
                m=>m.IsBlocked, 
                opt=>opt.MapFrom(src=>src.LockoutEnabled)
                );
            CreateMap<User, DetailsUserViewModel>();
            CreateMap<Tag, TagViewModel>();
        }
    }
}