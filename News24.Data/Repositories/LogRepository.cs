
using News24.Data.Infrastructure;
using News24.Model;

namespace News24.Data.Repositories
{
    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public LogRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
