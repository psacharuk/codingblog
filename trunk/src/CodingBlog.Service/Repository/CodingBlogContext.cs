using System.Data.Entity;
using CodingBlog.Service.Model;

namespace CodingBlog.Service.Repository
{
    internal class CodingBlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}