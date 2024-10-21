using Azure;
using Jasons_Personal_Blog.Models.Domain;
using Jasons_Personal_Blog.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jasons_Personal_Blog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        internal async Task DeleteAsync(EditBlogPostRequest editBlogPostRequest)
        {
            throw new NotImplementedException();
        }
    }
}
