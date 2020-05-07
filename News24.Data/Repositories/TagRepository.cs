using News24.Data.Infrastructure;
using News24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News24.Data.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDatabaseFactory databaseFactory): base(databaseFactory)
        {

        }
    }
}
