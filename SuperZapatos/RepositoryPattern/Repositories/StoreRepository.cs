using SuperZapatos.Models;
using SuperZapatos.RepositoryPattern.Concrete;
using SuperZapatos.RepositoryPattern.Contracts;

namespace SuperZapatos.RepositoryPattern.Repositories
{
    public class StoreRepository : BaseRepository<Store>
    {
        public StoreRepository(IUnitOfWork unit)
            : base(unit)
        {
        }
    }
}