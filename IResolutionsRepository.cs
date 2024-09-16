namespace ASP.NET_core_web_api_Milestone_.Repository;
namespace ASP.NET_core_web_api_Milestone_.Models.ResolutionsRepository
{
    public interface IResolutionsRepository
    {
        Task<IEnumerable<Resolution>> GetResolutionsAsync(string ticketId);
        Task<Resolution> GetResolutionAsync(string id);
        Task CreateResolutionAsync(Resolution resolution);
        Task UpdateResolutionAsync(string id, Resolution resolution);
        Task DeleteResolutionAsync(string id);
    }
}
