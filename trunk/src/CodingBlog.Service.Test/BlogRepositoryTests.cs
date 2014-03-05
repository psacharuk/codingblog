using System;
using System.Data.Entity;
using System.Transactions;
using CodingBlog.Service.Model;
using CodingBlog.Service.Repository;
using NUnit.Framework;

namespace CodingBlog.Service.Test
{
    [TestFixture]
    internal class BlogRepositoryTests
    {
        private TransactionScope _scope;

        private static Blog GetSampleBlog(string testBlogTitle)
        {
            var blogToCreate = new Blog
            {
                Title = testBlogTitle,
                CreationDate = DateTime.Now
            };
            return blogToCreate;
        }

        [TestFixtureSetUp]
        public void InitOnceBeforeAllTests()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CodingBlogContext>());
            new BlogRepository().GetBlogsCount();
        }

        [SetUp]
        public void BeginTransaction()
        {
            _scope = new TransactionScope();
        }

        [TearDown]
        public void RollbackTransaction()
        {
            _scope.Dispose();
        }

        [Test]
        public void after_creating_new_blog_blogs_count_in_db_equals_one()
        {
            var testBlogTitle = "test blog title";

            var count = new BlogRepository().GetBlogsCount();
            Assert.AreEqual(0, count);

            new BlogRepository().CreateBlog(GetSampleBlog(testBlogTitle));

            count = new BlogRepository().GetBlogsCount();
            Assert.AreEqual(1, count);
        }

        [Test]
        public void should_be_able_to_add_and_read_blog_from_database()
        {
            var blogRepository = new BlogRepository();

            var testBlogTitle = "test blog title";
            var blogToCreate = GetSampleBlog(testBlogTitle);
            
            var blogCreated = blogRepository.CreateBlog(blogToCreate);
            var blogToTest = blogRepository.GetBlogById(blogCreated.Id);
            
            Assert.NotNull(blogToTest);
            Assert.AreEqual(testBlogTitle, blogToTest.Title);
            Assert.GreaterOrEqual(blogToTest.Id, 1);
        }

        [Test]
        public void when_db_empty_default_blog_is_null()
        {
            var blogRepository = new BlogRepository();

            var blogToTest = blogRepository.GetDefaultBlog();

            Assert.Null(blogToTest);
        }

        [Test]
        public void can_get_default_blog()
        {
            var blogRepository = new BlogRepository();

            var testBlogTitle = "test blog title";
            var blogToCreate = GetSampleBlog(testBlogTitle);

            var blogCreated = blogRepository.CreateBlog(blogToCreate);
            var blogToTest = blogRepository.GetDefaultBlog();

            Assert.NotNull(blogToTest);
            Assert.AreEqual(blogCreated.Title, blogToTest.Title);
            Assert.AreEqual(blogCreated.Id, blogToTest.Id);
        }
    }
}