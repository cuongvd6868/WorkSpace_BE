using WorkSpace.Model;

namespace WorkSpace.Repositories
{
    public interface IWorkSpacesRepository
    {
        Task<WorkSpaces> GetWorkSpaceByIdAsync(int id);
        Task<IEnumerable<WorkSpaces>> GetAllWorkSpacesAsync();
        Task AddWorkSpaceAsync(WorkSpaces workspace);
        Task UpdateWorkSpaceAsync(int id, WorkSpaces workspace);
        Task DeleteWorkSpaceAsync(int id);
        Task<IEnumerable<WorkspaceImage>> GetWorkspaceImagesAsync(int workspaceId);
    }
}
