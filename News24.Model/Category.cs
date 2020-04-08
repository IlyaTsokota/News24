using System.Collections.Generic;

namespace News24.Model
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}