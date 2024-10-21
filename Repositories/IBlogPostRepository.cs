using Jasons_Personal_Blog.Models.Domain;

namespace Jasons_Personal_Blog.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost> AddAsync(BlogPost blogpost);

        Task<BlogPost?> UpdateAsync(BlogPost blogpost);
    }
}
