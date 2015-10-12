using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEngine45.Models.Base;

namespace CEngine45.Models.Community
{
    public class Post : Content
    {
        public Post()
        {
            Topic = new Topic();
        }

        public string Body { get; set; }

        public Topic Topic { get; set; }
    }
}
