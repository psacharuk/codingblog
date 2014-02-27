using System.Collections.Generic;

namespace CodingBlog.Service.Model
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
        public List<Post> Posts { get; set; } 
    }
}