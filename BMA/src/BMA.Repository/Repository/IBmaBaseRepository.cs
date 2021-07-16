using System.Threading.Tasks;

namespace BMA.Repository.Repository
{
    public interface IBmaBaseRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
    }
}