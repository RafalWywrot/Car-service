using NHibernate.AspNet.Identity;

namespace CarService.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual bool Active { get; set; }
    }
}