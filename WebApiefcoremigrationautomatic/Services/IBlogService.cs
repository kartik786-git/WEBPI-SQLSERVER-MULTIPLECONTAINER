using WebApiefcoremigrationautomatic.Entity;

namespace WebApiefcoremigrationautomatic.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync(int id, Blog blog);
        Task<int> DeleteAsync(int id);
    }
}
