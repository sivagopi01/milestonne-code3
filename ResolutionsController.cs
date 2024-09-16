using ASP.NET_core_web_api_Milestone_.Models;
using ASP.NET_core_web_api_Milestone_.Repository.ASP.NET_core_web_api_Milestone_.Models;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_core_web_api_Milestone_.Repository;

namespace ASP.NET_core_web_api_Milestone_.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ResolutionsController : ControllerBase
        {
            private readonly IResolutionsRepository _repository;

            public ResolutionsController(IResolutionsRepository repository)
            {
                _repository = repository;
            }

            [HttpGet("{ticketId}")]
            public async Task<ActionResult<IEnumerable<Resolution>>> GetResolutions(string ticketId)
            {
                var resolutions = await _repository.GetResolutionsAsync(ticketId);
                return Ok(resolutions);
            }

            [HttpPost]
            public async Task<ActionResult> CreateResolution(Resolution resolution)
            {
                await _repository.CreateResolutionAsync(resolution);
                return CreatedAtAction(nameof(GetResolutions), new { id = resolution.Id }, resolution);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateResolution(string id, Resolution resolution)
            {
                await _repository.UpdateResolutionAsync(id, resolution);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteResolution(string id)
            {
                await _repository.DeleteResolutionAsync(id);
                return NoContent();
            }
        }
    
}
