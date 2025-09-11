using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.Extensions;
using WorkSpace.Repositories;

namespace WorkSpace.Controllers
{
    [Authorize]
    [Route("api/workspace-favorite")]
    [ApiController]
    public class WorkSpaceFavoriteController : ControllerBase
    {
        private IWorkSpaceFavoriteRepository _workSpaceFavoriteRepository;
        public WorkSpaceFavoriteController(IWorkSpaceFavoriteRepository workSpaceFavoriteRepository)
        {
            _workSpaceFavoriteRepository = workSpaceFavoriteRepository;
        }

        [HttpPost("add/{workSpaceId}")]
        public async Task<IActionResult> AddToFavorites(int workSpaceId)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var result = await _workSpaceFavoriteRepository.AddToFavoritesAsync(workSpaceId, userId);
            if (result)
            {
                return Ok(new { message = "Added to favorites successfully." });
            }
            return BadRequest(new { message = "Failed to add to favorites." });
        }

        [HttpDelete("remove/{workSpaceId}")]
        public async Task<IActionResult> RemoveFromFavorites(int workSpaceId)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var result = await _workSpaceFavoriteRepository.RemoveFromFavoritesAsync(workSpaceId, userId);
            if (result)
            {
                return Ok(new { message = "Removed from favorites successfully." });
            }
            return BadRequest(new { message = "Failed to remove from favorites." });
        }

        [HttpGet("is-favorite/{workSpaceId}")]
        public async Task<IActionResult> IsFavorite(int workSpaceId)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var isFavorite = await _workSpaceFavoriteRepository.IsFavoriteAsync(workSpaceId, userId);
            return Ok(new { isFavorite });
        }

        [HttpGet("favorites")]
        public async Task<IActionResult> GetFavoriteWorkSpaces()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var favoriteWorkSpaces = await _workSpaceFavoriteRepository.GetFavoriteWorkSpaceAsync(userId);
            return Ok(favoriteWorkSpaces);
        }
    }
}
