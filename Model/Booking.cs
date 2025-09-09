using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Model
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string BookingCode { get; set; } // Unique code for reference

        public string CustomerId { get; set; }
        public int WorkspaceId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int NumberOfParticipants { get; set; } = 1;

        [MaxLength(1000)]
        public string SpecialRequests { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal FinalAmount { get; set; }

        public string Currency { get; set; } = "VND";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int BookingStatusId { get; set; }

        public DateTime? CheckedInAt { get; set; }
        public DateTime? CheckedOutAt { get; set; }

        [MaxLength(500)]
        public string CancellationReason { get; set; }
        public bool IsReviewed { get; set; } = false;

        // Navigation properties
        public virtual AppUser Customer { get; set; }
        public virtual Workspace Workspace { get; set; }
        public virtual BookingStatus BookingStatus { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<BookingParticipant> BookingParticipants { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<PromotionUsage> PromotionUsages { get; set; }
    }
}
