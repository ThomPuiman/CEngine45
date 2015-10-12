using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEngine45.Models.Community;

namespace CEngine45.Models.Context
{
    public class CommunityDbContext : DbContext
    {
        public CommunityDbContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<UserProfile> Profiles { get; set; } 

        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Topic> Topics { get; set; }  
    }
}
