using System.Threading.Tasks;

namespace CleanArch.Cache
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key) where T : class;
        Task SetAsync(string key, object obj, int expiresIn);
        T Get<T>(string key) where T : class;
        void Set(string key, object obj, int expiresIn);
    }
}
