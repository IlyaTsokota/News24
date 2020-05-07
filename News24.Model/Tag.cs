using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News24.Model
{
    public class Tag
    {
        public int TagId { get; set; }

        public string Value { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article {get;set;}
    }
}
