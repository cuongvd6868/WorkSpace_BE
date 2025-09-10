using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Model
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Street { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [MaxLength(20)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Navigation properties
        public virtual ICollection<WorkSpaces> Workspaces { get; set; }
    }
}
