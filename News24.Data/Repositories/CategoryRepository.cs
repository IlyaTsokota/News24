
using News24.Data.Infrastructure;
using News24.Model;

namespace News24.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
