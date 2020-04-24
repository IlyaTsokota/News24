using AutoMapper;
using News24.Model;
using News24.Service;
using News24.Web.Models;
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
        private const int _pageSize = 4;

        public StartController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        // GET: Home
        public ActionResult Index(int page = 1)
        {
            var categories = _categoryService.GetCategories();
            var articles = _articleService.GetArticles();
            var mappCategories = categories.Select(Mapper.Map<Category, CategoryViewModel>).ToList();
            var mappArticles = articles.Select(Mapper.Map<Article, ArticleViewModel>).Skip((page - 1) * _pageSize).Take(_pageSize).Reverse().ToList();
            var mappLastArticles = articles.Select(Mapper.Map<Article, ArticleViewModel>).OrderByDescending(x => x.PublicationDate).Take(5).ToList();
            var pager = new Pager(page, articles.Count(), _pageSize);
            var model = new IndexViewModel
            {
                Articles = mappArticles,
                LastArticles = mappLastArticles,
                Categories = mappCategories,
                Pager = pager
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult GetArticles(int page = 1, string category = null)
        {
            var articles = _articleService.GetArticles();
            if (!String.IsNullOrEmpty(category))
            {
                articles = articles.Where(x => x.Category.Name == category).ToList();
            }
            var mappArticles = articles.Select(Mapper.Map<Article, ArticleViewModel>).Skip((page - 1) * _pageSize).Take(_pageSize).Reverse().ToList();
            var pager = new Pager(page, articles.Count(), _pageSize);
            var model = new IndexViewModel
            {
                Articles = mappArticles,
                Pager = pager
            };
            return PartialView("_Articles", model);
        }



    }
}