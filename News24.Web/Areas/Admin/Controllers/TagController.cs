using AutoMapper;
using News24.Model;
using News24.Service;
using News24.Web.Areas.Admin.ViewModels.TagViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News24.Web.Areas.Admin.Controllers
{
    public class TagController : Controller
    {

        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        // GET: Admin/Tag
        public ActionResult Index(int id)
        {
            var tags = _tagService.GetTags(id);
            var tagsMapp = tags.Select(Mapper.Map<Tag, TagViewModel>).ToList();
            var model = new IndexTagViewModel
            {
                Tags = tagsMapp,
                ArticleId = id
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int articleId)
        {
            return View(new TagViewModel { ArticleId = articleId});
        }


        [HttpPost]
        public ActionResult Create(TagViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var mappingTag = Mapper.Map<TagViewModel, Tag>(model);
            var tagsSplit = mappingTag.Value.Split(',');
            var tags = new List<Tag>();
            foreach (var item in tagsSplit)
            {
                tags.Add(new Tag { Value = item, ArticleId = mappingTag.ArticleId });
            }
            _tagService.AddTags(tags);
            Logger.Log.Info($"{User.Identity.Name} добавил теги к статье №{model.ArticleId}");
            return RedirectToAction("Index", new { id = model.ArticleId});
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tag = _tagService.GetTag(id);
            var model = Mapper.Map<Tag, TagViewModel>(tag);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TagViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var tag = Mapper.Map<TagViewModel, Tag>(model);
            _tagService.Update(tag);
            Logger.Log.Info($"{User.Identity.Name} добавил теги к статье №{model.ArticleId}");
            return RedirectToAction("Index", new { id = model.ArticleId });
        }

        public ActionResult Delete(int id)
        {
            var tag = _tagService.GetTag(id);
            _tagService.Delete(tag);
            return RedirectToAction("Index", new { id = tag.ArticleId});
        }
    }
}