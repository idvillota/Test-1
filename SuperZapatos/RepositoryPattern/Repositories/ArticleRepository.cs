using SuperZapatos.Models;
using SuperZapatos.RepositoryPattern.Concrete;
using SuperZapatos.RepositoryPattern.Contracts;

namespace SuperZapatos.RepositoryPattern.Repositories
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(IUnitOfWork unit)
            : base(unit)
        {
        }
    }
}