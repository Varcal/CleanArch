using System.Threading;
using System.Threading.Tasks;
using CleanArch.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanArch.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly EfContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EfContext db)
        {
            _db = db;
        }

        public void BeginTransaction()
        {
            _transaction = _db.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _db.Database.BeginTransactionAsync(cancellationToken);
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
