namespace News24.Model
{
    public class Comment
    {
        public int ReviewsId { get; set; }

        public string Head { get; set; }

        public string Body { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}