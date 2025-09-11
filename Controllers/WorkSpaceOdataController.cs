using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.Repositories;
using Microsoft.AspNetCore.OData.Query;

namespace WorkSpace.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class WorkSpaceOdataController : ODataController
    {
        private readonly IWorkSpacesRepository _workSpacesRepository;
        public WorkSpaceOdataController(IWorkSpacesRepository workSpacesRepository)
        {
            _workSpacesRepository = workSpacesRepository;
        }

        [EnableQuery]
        [HttpGet]
        public async Task<IActionResult> GetAllWorkSpaceAsync()
        {
            var ws = await _workSpacesRepository.GetAllWorkSpacesAsync();
            return Ok(ws);
        }
    }
}
