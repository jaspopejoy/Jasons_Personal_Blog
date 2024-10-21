using Jasons_Personal_Blog.Data;
using Jasons_Personal_Blog.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jasons_Personal_Blog.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogpost)
        {
            await _context.AddAsync(blogpost);
            await _context.SaveChangesAsync();
            return blogpost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await _context.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogpost)
        {
            var existingBlog = await _context.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == blogpost.Id);
        
            if (existingBlog != null)
            {
                existingBlog.Id = blogpost.Id;
                existingBlog.PageTitle = blogpost.PageTitle;
                existingBlog.Heading = blogpost.Heading;
                existingBlog.Content = blogpost.Content;
                existingBlog.ShortDescription = blogpost.ShortDescription;
                existingBlog.Author = blogpost.Author;
                existingBlog.FeaturedImageUrl = blogpost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogpost.UrlHandle;
                existingBlog.Visible = blogpost.Visible;
                existingBlog.PublishedDate = blogpost.PublishedDate;
                existingBlog.Tags = blogpost.Tags;

                await _context.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }
    }
}
