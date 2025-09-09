using Microsoft.AspNetCore.Identity;

namespace WorkSpace.Model
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual HostProfile HostProfile { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WorkSpaceFavorite> WorkSpaceFavorites { get; set; }
        public virtual ICollection<PromotionUsage> PromotionUsages { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
