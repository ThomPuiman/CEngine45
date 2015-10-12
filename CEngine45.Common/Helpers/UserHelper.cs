using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEngine45.Models.Community;
using CEngine45.Models.Context;

namespace CEngine45.Common.Helpers
{
    public class UserHelper
    {

        public static UserProfile CreateNewUserProfile(string userName, string emailAddress)
        {
            var profile = new UserProfile();
            profile.UserName = userName;
            profile.EmailAddress = emailAddress;
            profile.MemberSince = DateTime.Now;

            using (CommunityDbContext context = new CommunityDbContext())
            {
                context.Profiles.Add(profile);
                context.SaveChanges();
            }
            return profile;
        }

    }
}
