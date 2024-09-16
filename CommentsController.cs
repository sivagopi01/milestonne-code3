using ASP.NET_core_web_api_Milestone_.Models;
using ASP.NET_core_web_api_Milestone_.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_core_web_api_Milestone_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepository _repository;

        public CommentsController(ICommentsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/comments/{ticketId}
        [HttpGet("{ticketId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(string ticketId)
        {
            var comments = await _repository.GetCommentsAsync(ticketId);
            return Ok(comments);
        }

        // GET: api/comments/{id}
        [HttpGet("{id:length(24)}", Name = "GetComment")]
        public async Task<ActionResult<Comment>> GetComment(string id)
        {
            var comment = await _repository.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // POST: api/comments
        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment(Comment comment)
        {
            await _repository.CreateCommentAsync(comment);
            return CreatedAtRoute("GetComment", new { id = comment.Id }, comment);
        }

        // PUT: api/comments/{id}
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateComment(string id, Comment commentIn)
        {
            var comment = await _repository.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            commentIn.Id = comment.Id;

            await _repository.UpdateCommentAsync(id, commentIn);

            return NoContent();
        }

        // DELETE: api/comments/{id}
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var comment = await _repository.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            await _repository.DeleteCommentAsync(id);

            return NoContent();
        }
    }

}
