using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
     Task< List<Region>> GetAllAsync(string? filterOn,string? filterQeuery);
     Task< Region?> GetByIdAsync(Guid id);
     Task<Region?> UpdateAsync(Guid id, Region region);
     Task< Region?> DeleteAsync(Guid id);
     Task< Region> CreateAsync(Region region);
    }
}
