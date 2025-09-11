using WorkSpace.Model;

namespace WorkSpace.Repositories
{
    public interface IWorkSpaceFavoriteRepository
    {
        Task<bool> AddToFavoritesAsync(int hotelId, string userId);
        Task<bool> RemoveFromFavoritesAsync(int hotelId, string userId);
        Task<bool> IsFavoriteAsync(int hotelId, string userId);
        Task<List<int>> GetFavoriteWorkSpaceIdsAsync(string userId);
        Task<List<WorkSpaces>> GetFavoriteWorkSpaceAsync(string userId);
    }
}
