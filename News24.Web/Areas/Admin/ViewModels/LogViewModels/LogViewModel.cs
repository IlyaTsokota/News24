using System;
using System.ComponentModel.DataAnnotations;

namespace News24.Web.Areas.Admin.ViewModels.LogViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Дата перехвата")]
        public DateTime Date { get; set; }

        [Display(Name = "Уровень")]
        public string Level { get; set; }


        [Display(Name = "Сообщение")]
        public string Message { get; set; }

  
      
    }
}