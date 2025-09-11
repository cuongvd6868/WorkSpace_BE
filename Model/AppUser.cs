using Microsoft.AspNetCore.Identity;

namespace WorkSpace.Model
{
    public class AppUser : IdentityUser
    {
        public virtual List<Booking> Bookings { get; set; }
        public virtual HostProfile HostProfile { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<WorkSpaceFavorite> WorkSpaceFavorites { get; set; }
        public virtual List<PromotionUsage> PromotionUsages { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
