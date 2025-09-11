using Microsoft.AspNetCore.Mvc;
using WorkSpace.Repositories;
using WorkSpace.Model;
using WorkSpace.DTOs.WorkSpaceDto;
using Microsoft.CodeAnalysis;
using WorkSpace.Mappers;

namespace WorkSpace.Controllers
{
    [Route("api/workspaces")]
    [ApiController]
    public class WorkSpaceApiController : ControllerBase
    {
        private IWorkSpacesRepository _workSpacesRepository;
        public WorkSpaceApiController(IWorkSpacesRepository workSpacesRepository)
        {
            _workSpacesRepository = workSpacesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkSpaceAsync()
        {
            var ws = await _workSpacesRepository.GetAllWorkSpacesAsync();
            return Ok(ws);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetWorkSpaceByIdAsync(int id)
        {
            var ws = await _workSpacesRepository.GetWorkSpaceByIdAsync(id);
            if (ws == null)
            {
                return NotFound();
            }
            return Ok(ws);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkSpaceAsync([FromBody] WorkSpaceCreateDto workSpaceDto)
        {
            if (workSpaceDto == null)
            {
                return BadRequest();
            }
            var workSpace = workSpaceDto.ToWorkSpaceFromCreateDTO();
            await _workSpacesRepository.AddWorkSpaceAsync(workSpace);
            return CreatedAtAction(nameof(GetWorkSpaceByIdAsync), new { id = workSpace.Id }, workSpace);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateWorkSpaceAsync(int id, [FromBody] WorkSpaceUpdateDto workSpaceDto)
        {
            if (workSpaceDto == null)
            {
                return BadRequest();
            }
            //var existingWorkSpace = await _workSpacesRepository.GetWorkSpaceByIdAsync(id);
            //if (existingWorkSpace == null)
            //{
            //    return NotFound();
            //}
            var workSpace = workSpaceDto.ToWorkSpaceFromUpdateDTO();
            await _workSpacesRepository.UpdateWorkSpaceAsync(id, workSpace);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteWorkSpaceAsync(int id)
        {
            var existingWorkSpace = await _workSpacesRepository.GetWorkSpaceByIdAsync(id);
            if (existingWorkSpace == null)
            {
                return NotFound();
            }
            await _workSpacesRepository.DeleteWorkSpaceAsync(id);
            return NoContent();
        }
    }
}
