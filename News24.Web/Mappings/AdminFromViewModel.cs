using AutoMapper;
using News24.Model;
using News24.Web.Areas.Admin.ViewModels.ArticleViewModels;
using News24.Web.Areas.Admin.ViewModels.CategoryViewModels;
using News24.Web.Extensions;
using System;

using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using News24.Web.Areas.Admin.ViewModels.TagViewModel;

namespace News24.Web.Mappings
{
    public class AdminFromViewModel : Profile
    {
        public AdminFromViewModel()
        {
            //Article
            CreateMap<ArticleViewModel, Article>();
            CreateMap<ArticleCategoryViewModel, Category>();
            CreateMap<CreateArticleViewModel, Article>()
                .ForMember(m => m.MainImage,
                opt => opt.MapFrom(src => src.Image.ToByteArray()))
                .ForMember(m => m.PublicationDate,
                opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<EditArticleViewModel, Article>()
                .ForMember(
                m => m.MainImage,
                opt => opt.MapFrom(src => src.Image == null ? src.MainImage : src.Image.ToByteArray()));

            //Category
            CreateMap<CreateCategoryViewModel, Category>();
            CreateMap<EditCategoryViewModel, Category>();
            CreateMap<TagViewModel, Tag>();

        }

      
    }
}