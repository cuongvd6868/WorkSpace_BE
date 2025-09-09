namespace WorkSpace.Model
{
    public class WorkspaceAmenity
    {
        public int WorkspaceId { get; set; }
        public int AmenityId { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Navigation properties
        public virtual Workspace Workspace { get; set; }
        public virtual Amenity Amenity { get; set; }
    }
}
