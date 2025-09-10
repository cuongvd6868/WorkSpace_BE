namespace WorkSpace.Model
{
    public class WorkSpaceFavorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int WorkspaceId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Navigation properties
        public virtual AppUser User { get; set; }
        public virtual WorkSpaces Workspace { get; set; }
    }
}
