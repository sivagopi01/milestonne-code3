using ASP.NET_core_web_api_Milestone_.Models;

namespace ASP.NET_core_web_api_Milestone_.Repository
{

        public interface ICommentsRepository
        {
            Task<IEnumerable<Comment>> GetCommentsAsync(string ticketId);
            Task<Comment> GetCommentByIdAsync(string id);
            Task CreateCommentAsync(Comment comment);
            Task UpdateCommentAsync(string id, Comment comment);
            Task DeleteCommentAsync(string id);
        }
   
}
