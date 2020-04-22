using System;

namespace News24.Web.Models
{
    public class Pager
    {
        public int PageNumber { get; } // номер текущей страницы
        public int PageSize { get; } // кол-во объектов на странице
        public int TotalItems { get; } // всего объектов
        public int TotalPages { get; } // всего страниц


        public Pager(int pageNumber, int totalItems, int pageSize = 3)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
        }
    }
}