using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News24.Web.Areas.Admin.ViewModels.TagViewModel
{
    public class IndexTagViewModel
    {
        public List<TagViewModel> Tags { get; set; }

        public int ArticleId { get; set; }
    }
}