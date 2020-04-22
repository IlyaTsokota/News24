using AutoMapper;
using News24.Model;
using News24.Service;
using News24.Web.ViewModels.StartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News24.Web.Controllers
{
    public class StartController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public StartController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            var articles = _articleService.GetArticles();
            var mappCategories = categories.Select(Mapper.Map<Category, CategoryViewModel>).ToList();
            var mappLastArticles = articles.Select(Mapper.Map<Article, ArticleViewModel>).OrderByDescending(x => x.PublicationDate).Take(5).ToList();
            var model = new IndexViewModel
            {
                Articles = mappLastArticles,
                Categories = mappCategories
            };
            return View(model);
        }
         
        [HttpGet]
        public ActionResult LastArticles()
        {
            var articles = _articleService.GetArticles();
            var model = articles.Select(Mapper.Map<Article, ArticleViewModel>).OrderByDescending(x => x.PublicationDate).Take(5).ToList();
            var trueModel = new LastArticlesViewModel
            {
                Articles = model
            };
            return PartialView("_LastArticles", trueModel);
        }

    }
}