using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CodingBlog.Service.Model;
using CodingBlog.Service.Repository;
using NUnit.Framework;

namespace CodingBlog.Service.Test
{
    [TestFixture]
    internal class BlogRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            Database.DefaultConnectionFactory 
                = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            Database.SetInitializer(new DropCreateDatabaseAlways<CodingBlogContext>());
        }

        [Test]
        public void when_database_recreated_there_are_no_blogs()
        {
            var count = new BlogRepository().GetBlogsCount();
            Assert.AreEqual(0, count);
        }

        [Test]
        public void should_be_able_to_add_and_read_blog_from_database()
        {
            string testBlogTitle = "test blog title";
            Blog blogToCreate = new Blog
            {
                Title = testBlogTitle,
                CreationDate = DateTime.Now
            };

            var blog = new BlogRepository().CreateBlog(blogToCreate);
            
            Assert.NotNull(blog);
            Assert.AreEqual(testBlogTitle, blog.Title);
            Assert.GreaterOrEqual(1, blog.Id);
        }
    }
}