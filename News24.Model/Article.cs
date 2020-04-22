using System;
using System.Collections.Generic;


namespace News24.Model
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Head { get; set; }

        public string Body { get; set; }

        public byte[] MainImage { get; set; }

        public DateTime PublicationDate { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
