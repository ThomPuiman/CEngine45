using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using CEngine45.Models.Community;
using CEngine45.Models.Context;

namespace CEngine45.Common.Services
{
    public class UserService : IUser
    {
        private HttpContext currentContext { get; set; }

        public UserService(HttpContext context)
        {
            currentContext = context;
        }

        public UserProfile CurrentUser()
        {
            IPrincipal currentMembershipUser = currentContext.User;
            if (currentMembershipUser != null)
            {
                return UserByEmail(currentMembershipUser.Identity.Name);
            }
            return null;
        }

        public UserProfile UserByEmail(string emailAddress)
        {
            UserProfile foundProfile = null;
            using (CommunityDbContext db = new CommunityDbContext())
            {
                foundProfile = db.Profiles.FirstOrDefault(x => x.EmailAddress.ToLower().Equals(emailAddress.ToLower()));
            }
            return foundProfile;
        }
    }

    public interface IUser
    {
        UserProfile CurrentUser();
        UserProfile UserByEmail(string emailAddress);
    }
}
