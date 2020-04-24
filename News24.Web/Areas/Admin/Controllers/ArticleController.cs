using AutoMapper;
using News24.Data.Identity;
using News24.Model;
using News24.Service;
using News24.Web.Areas.Admin.ViewModels.ArticleViewModels;
using News24.Web.Extensions;
using News24.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace News24.Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ApplicationUserManager _userManager;
        private const int _pageSize = 10;
        public ArticleController(IArticleService articleService, ICategoryService categoryService, ApplicationUserManager userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
        }
        // GET: Admin/Article
        public ActionResult Index(int page = 1)
        {
           
            var articles = _articleService.GetArticles();
            var articleList = articles.Select(Mapper.Map<Article, ArticleViewModel>).Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pager = new Pager(page, articles.Count, _pageSize);
            var model = new IndexArticleViewModel
            {
                Articles = articleList,
                Pager = pager
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var article = _articleService.GetArticle(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            var model = Mapper.Map<Article, DetailsArticleViewModel>(article);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categoties = CategorySelectList();
            var model = new CreateArticleViewModel
            {
                CategoriesList = categoties.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateArticleViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.CategoriesList = CategorySelectList();
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(Membership.GetUser().UserName);
            var article = Mapper.Map<CreateArticleViewModel, Article>(model);
            article.User = user;
            var errors = _articleService.CanAddArticle(article);
            ModelState.AddModelErrors(errors);
            _articleService.CreateArticle(article);
            Logger.Log.Info($"{User.Identity.Name} создал новую статью №{model.ArticleId}");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var article = _articleService.GetArticle(id);
            var model = Mapper.Map<Article, EditArticleViewModel>(article);
            model.CategoriesList = CategorySelectList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CategoriesList = CategorySelectList();
                return View(model);
            }
            var article = Mapper.Map<EditArticleViewModel, Article>(model);
            _articleService.UpdateArticle(article);
            Logger.Log.Info($"{User.Identity.Name} изменил статью №{article.ArticleId}");
            return RedirectToAction("Index", "Article");
        }


        public List<SelectListItem> CategorySelectList() =>
            _categoryService.GetCategories().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()

            }).ToList();
    }

}