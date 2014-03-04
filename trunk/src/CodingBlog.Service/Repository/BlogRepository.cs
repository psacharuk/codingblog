using System.Linq;
using CodingBlog.Service.Model;

namespace CodingBlog.Service.Repository
{
    public class BlogRepository
    {
        public int GetBlogsCount()
        {
            using (var context = new CodingBlogContext())
            {
                return context.Blogs.Count();
            }
        }

        public Blog CreateBlog(Blog blogToCreate)
        {
            using (var context = new CodingBlogContext())
            {
                context.Blogs.Add(blogToCreate);
                context.SaveChanges();

                return blogToCreate;             
            }
        }
    }
}