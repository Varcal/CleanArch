using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Data
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void BeginTransaction();
        void Commit();
        void Rollback();
        int SaveChanges();
    }
}
