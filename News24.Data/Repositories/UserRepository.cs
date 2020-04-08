
using News24.Data.Infrastructure;
using News24.Model;

namespace News24.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
