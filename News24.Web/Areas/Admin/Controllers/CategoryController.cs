using AutoMapper;
using News24.Model;
using News24.Service;
using News24.Web.Areas.Admin.ViewModels.CategoryViewModels;
using News24.Web.Extensions;
using News24.Web.Models;
using System.Linq;
using System.Web.Mvc;


namespace News24.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private const int pageSize = 10;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: Admin/Category
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var categories = _categoryService.GetCategories();
            var categoriesList = categories.Select(Mapper.Map<Category, CategoryViewModel>).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var pager = new Pager(page,categories.Count(), pageSize);
            var model = new IndexCategoryViewModel
            {
                Categories = categoriesList,
                Pager = pager
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            var category = Mapper.Map<CreateCategoryViewModel, Category>(model);
            var errors = _categoryService.CanAddCategory(category);
            ModelState.AddModelErrors(errors);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _categoryService.CreateCategory(category);
            Logger.Log.Info($"{User.Identity.Name} создал категорию №{category.Id} с названием  {model.Name} ");
            return RedirectToAction("Index");
        }

        // GET: Admin/Category/Edit/
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            var model = Mapper.Map<Category, EditCategoryViewModel>(category);
            return View(model);
        }

        // POST: Admin/Category/Edit
        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var newCategory = Mapper.Map<EditCategoryViewModel, Category>(model);
            var errors = _categoryService.CanAddCategory(newCategory);
            ModelState.AddModelErrors(errors);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _categoryService.UpdateCategory(newCategory);
            Logger.Log.Info($"{User.Identity.Name} изменил категорию №{newCategory.Id} {newCategory.Name} ");
            return RedirectToAction("Index");
        }


    }
}