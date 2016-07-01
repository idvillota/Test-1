using SuperZapatos.Models;
using SuperZapatos.RepositoryPattern.Contracts;
using System.Data.Entity;
using System.Transactions;

namespace SuperZapatos.RepositoryPattern.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuperZapatosContext _db;
        private TransactionScope _transaction;

        public UnitOfWork()
        {
            _db = new SuperZapatosContext();
        }

        public DbContext Db
        {
            get { return _db; }
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public void Dispose()
        {
        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }
    }
}