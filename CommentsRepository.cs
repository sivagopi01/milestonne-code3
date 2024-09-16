using ASP.NET_core_web_api_Milestone_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASP.NET_core_web_api_Milestone_.Repository
{
        public class CommentsRepository : ICommentsRepository
        {
            private readonly IMongoCollection<Comment> _comments;

            public CommentsRepository(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
            {
                var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
                _comments = database.GetCollection<Comment>("Comments");
            }

            public async Task<IEnumerable<Comment>> GetCommentsAsync(string ticketId)
            {
                return await _comments.Find(c => c.TicketId == ticketId).ToListAsync();
            }

            public async Task<Comment> GetCommentByIdAsync(string id)
            {
                return await _comments.Find(c => c.Id == id).FirstOrDefaultAsync();
            }

            public async Task CreateCommentAsync(Comment comment)
            {
                await _comments.InsertOneAsync(comment);
            }

            public async Task UpdateCommentAsync(string id, Comment comment)
            {
                await _comments.ReplaceOneAsync(c => c.Id == id, comment);
            }

            public async Task DeleteCommentAsync(string id)
            {
                await _comments.DeleteOneAsync(c => c.Id == id);
            }
        }
    
}
