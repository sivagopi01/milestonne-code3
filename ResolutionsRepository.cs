using ASP.NET_core_web_api_Milestone_.Models;
using Microsoft.Extensions.Options;

namespace ASP.NET_core_web_api_Milestone_.Repository
{
    public class ResolutionsRepository
    {
        public class ResolutionsRepository : IResolutionsRepository
        {
            private readonly IMongoCollection<Resolution> _resolutions;

            public ResolutionsRepository(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
            {
                var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
                _resolutions = database.GetCollection<Resolution>("Resolutions");
            }

            public async Task<IEnumerable<Resolution>> GetResolutionsAsync(string ticketId)
            {
                return await _resolutions.Find(r => r.TicketId == ticketId).ToListAsync();
            }

            public async Task<Resolution> GetResolutionAsync(string id)
            {
                return await _resolutions.Find(r => r.Id == id).FirstOrDefaultAsync();
            }

            public async Task CreateResolutionAsync(Resolution resolution)
            {
                await _resolutions.InsertOneAsync(resolution);
            }

            public async Task UpdateResolutionAsync(string id, Resolution resolution)
            {
                await _resolutions.ReplaceOneAsync(r => r.Id == id, resolution);
            }

            public async Task DeleteResolutionAsync(string id)
            {
                await _resolutions.DeleteOneAsync(r => r.Id == id);
            }
        }
    }
}
