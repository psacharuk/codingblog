using CodingBlog.Service.Model;
using CodingBlog.Service.Repository;

namespace CodingBlog.Service.Service
{
    public class BlogService
    {
        private readonly BlogRepository _blogRepository;

        public BlogService()
        {
            _blogRepository = new BlogRepository();
        }

        public Blog GetDefaultBlog()
        {
            return _blogRepository.GetDefaultBlog();
        }
    }
}