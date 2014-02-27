using System;
using System.Collections.Generic;

namespace CodingBlog.Service.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tag> Tags { get; set; }
    }
}