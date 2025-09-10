using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Model
{
    public class WorkspaceType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Private Office, Meeting Room, Hot Desk, etc.

        [MaxLength(500)]
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<WorkSpaces> Workspaces { get; set; }
    }
}
