using News24.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using News24.Model;
using News24.Web.ViewModels.ArticleViewModel;

namespace News24.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        // GET: Article
        public ActionResult Index(int id)
        {
            var article = _articleService.GetArticle(id);
            var model = Mapper.Map<Article, ArticleDetailsViewModel >(article);
          
            return View(model);
        }
    }
}