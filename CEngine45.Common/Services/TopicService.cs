using System;
using System.Linq;
using CEngine45.Models.Community;
using CEngine45.Models.Context;

namespace CEngine45.Common.Services
{
    public class TopicService : ITopic
    {
        private IUser userServiceInstance { get; set; }

        public TopicService(IUser userService)
        {
            userServiceInstance = userService;
        }

        public Topic Create(Post firstPost)
        {
            firstPost.CreatedBy = userServiceInstance.CurrentUser();
            firstPost.Topic.CreatedBy = userServiceInstance.CurrentUser();
            using (CommunityDbContext db = new CommunityDbContext())
            {
                db.Posts.Add(firstPost);
                db.Topics.Add(firstPost.Topic);
                db.SaveChanges();
            }
            return firstPost.Topic;
        }

        public Topic Get(int topicId)
        {
            Topic currentTopic = null;
            using (CommunityDbContext db = new CommunityDbContext())
            {
                currentTopic = db.Topics.SingleOrDefault(x => x.ID == topicId);
            }
            return currentTopic;
        }
    }

    public interface ITopic
    {
        Topic Create(Post firstPost);
        Topic Get(int topicId);
    }
}
