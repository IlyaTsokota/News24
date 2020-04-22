using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace News24.Web.ViewModels.StartViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Категория")]
        public string Name { get; set; }
    }
}