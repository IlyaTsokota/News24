
using News24.Data.Infrastructure;
using News24.Model;

namespace News24.Data.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
