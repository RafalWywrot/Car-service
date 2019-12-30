using CarService.Identity;

namespace CarService.Repository.Entities
{
    public class LinkBookingServiceUser
    {
        public virtual int BookingServiceId { get; set; }
        public virtual string UserId { get; set; }
        public virtual BookingServiceEntity BookingService { get; set; }
        public virtual ApplicationUser AssignedUser { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as LinkBookingServiceUser;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.BookingServiceId == BookingServiceId && other.UserId == UserId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)243126;
                const int HashingMultiplier = 167619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (BookingServiceId.GetHashCode());
                hash = (hash * HashingMultiplier) ^ (UserId.GetHashCode());
                return hash;
            }
        }
    }
}