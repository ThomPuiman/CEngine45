using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEngine45.Models.Base;

namespace CEngine45.Models.Community
{
    public class Topic : Content
    {
        public string Title { get; set; }
        public Category Category { get; set; }
        public List<Post> Posts { get; set; }

        public Post GetFirstPost()
        {
            return this.Posts.OrderBy(x => x.CreatedOn).FirstOrDefault();
        }

        public List<Post> GetComments()
        {
            return this.Posts.OrderBy(x => x.CreatedOn).Skip(1).ToList();
        }
    }
}
