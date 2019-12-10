using NHibernate.AspNet.Identity;

namespace CarService.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; }
    }
}