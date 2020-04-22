using System.ComponentModel;

namespace News24.Web.Areas.Admin.ViewModels.ArticleViewModels
{
    public class ArticleCategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Категория")]
        public string Name { get; set; }
    }
}