using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News24.Model
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Head { get; set; }

        public string Body { get; set; }

        public byte[] MainImage { get; set; }

        public DateTime PublicationDate { get; set; }


        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public virtual User User { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Tag> Tags { get; set; }

    }
}
