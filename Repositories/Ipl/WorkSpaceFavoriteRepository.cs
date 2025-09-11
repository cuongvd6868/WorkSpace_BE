using WorkSpace.Data;
using WorkSpace.Model;
using Microsoft.EntityFrameworkCore;

namespace WorkSpace.Repositories.Ipl
{
    public class WorkSpaceFavoriteRepository : IWorkSpaceFavoriteRepository
    {
        private readonly AppDbContext _context;
        public WorkSpaceFavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToFavoritesAsync(int workSpaceId, string userId)
        {
            var favorite = new WorkSpaceFavorite
            {
                WorkspaceId = workSpaceId,
                UserId = userId
            };
            _context.WorkSpaceFavorites.Add(favorite);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<List<WorkSpaces>> GetFavoriteWorkSpaceAsync(string userId)
        {
            return _context.WorkSpaceFavorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Workspace)
                .Select(f => f.Workspace)
                .ToListAsync();
        }

        public async Task<List<int>> GetFavoriteWorkSpaceIdsAsync(string userId)
        {
            var favoriteIds = await _context.WorkSpaceFavorites
                .Where(f => f.UserId == userId)
                .Select(f => f.WorkspaceId)
                .ToListAsync();
            return favoriteIds;
        }

        public async Task<bool> IsFavoriteAsync(int workSpaceId, string userId)
        {
            return await _context.WorkSpaceFavorites
                .AnyAsync(f => f.WorkspaceId == workSpaceId && f.UserId == userId);
        }

        public async Task<bool> RemoveFromFavoritesAsync(int workSpaceId, string userId)
        {
            var favorite = await _context.WorkSpaceFavorites
                .FirstOrDefaultAsync(f => f.WorkspaceId == workSpaceId && f.UserId == userId);
            if (favorite != null)
            {
                _context.WorkSpaceFavorites.Remove(favorite);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;

        }
    }
}
