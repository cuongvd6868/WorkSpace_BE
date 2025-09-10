using WorkSpace.Data;
using WorkSpace.Model;
using Microsoft.EntityFrameworkCore;

namespace WorkSpace.Repositories.Ipl
{
    public class WorkSpacesRepository : IWorkSpacesRepository
    {
        private readonly AppDbContext _context;

        public WorkSpacesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddWorkSpaceAsync(WorkSpaces workspace)
        {
            await _context.Workspaces.AddAsync(workspace);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorkSpaceAsync(int id)
        {
            var workspace = await _context.Workspaces.FindAsync(id);
            if (workspace != null)
            {
                _context.Workspaces.Remove(workspace);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WorkSpaces>> GetAllWorkSpacesAsync()
        {
            return await _context.Workspaces.ToListAsync();
        }

        public async Task<WorkSpaces> GetWorkSpaceByIdAsync(int id)
        {
            return await _context.Workspaces
                .Include(w => w.Address)
                .Include(w => w.Host)
                .Include(w => w.WorkspaceType)
                .Include(w => w.WorkspaceImages)
                .Include(w => w.WorkspaceAmenities)
                    .ThenInclude(wa => wa.Amenity)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<WorkspaceImage>> GetWorkspaceImagesAsync(int workspaceId)
        {
            return await _context.WorkspaceImages
                .Where(wi => wi.WorkspaceId == workspaceId)
                .ToListAsync();
        }

        public Task UpdateWorkSpaceAsync(int id, WorkSpaces workspace)
        {
            throw new NotImplementedException();
        }
    }
}
