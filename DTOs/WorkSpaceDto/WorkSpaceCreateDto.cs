using System.ComponentModel.DataAnnotations;
using WorkSpace.Model;

namespace WorkSpace.DTOs.WorkSpaceDto
{
    public class WorkSpaceCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 255 characters")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "HostId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "HostId must be greater than 0")]
        public int HostId { get; set; }

        [Required(ErrorMessage = "AddressId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "AddressId must be greater than 0")]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "WorkspaceTypeId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "WorkspaceTypeId must be greater than 0")]
        public int WorkspaceTypeId { get; set; }

        [Range(0, 1000000, ErrorMessage = "Price per hour must be between 0 and 1,000,000")]
        public decimal PricePerHour { get; set; }

        [Range(0, 10000000, ErrorMessage = "Price per day must be between 0 and 10,000,000")]
        public decimal PricePerDay { get; set; }

        [Range(0, 100000000, ErrorMessage = "Price per month must be between 0 and 100,000,000")]
        public decimal PricePerMonth { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, 10000, ErrorMessage = "Capacity must be between 1 and 10,000 people")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Area is required")]
        [Range(1, 100000, ErrorMessage = "Area must be between 1 and 100,000 square meters")]
        public double Area { get; set; } // mét vuông

        public virtual WorkspaceType WorkspaceType { get; set; }
        public virtual List<WorkspaceImage> WorkspaceImages { get; set; }
        public virtual List<WorkspaceAmenity> WorkspaceAmenities { get; set; }
        public virtual Address Address { get; set; }
        public virtual HostProfile Host { get; set; }
    }
}
