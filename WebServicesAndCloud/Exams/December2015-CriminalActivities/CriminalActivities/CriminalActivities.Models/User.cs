namespace CriminalActivities.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Criminal> criminals;

        public User()
        {
            this.criminals = new HashSet<Criminal>();
        }

        public virtual ICollection<Criminal> Criminals
        {
            get { return this.criminals; }
            set { this.criminals = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
