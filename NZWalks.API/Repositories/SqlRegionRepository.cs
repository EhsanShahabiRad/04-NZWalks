using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Exceptions;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SqlRegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _dbContext.regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await _dbContext.regions.FindAsync(id);
            if (region == null) { return new Region(); }
            _dbContext.regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync(string? filterOn = null, string? filterQeuery = null)
        {
            var result = _dbContext.regions.AsQueryable();

            if (string.IsNullOrEmpty(filterOn) == false && string.IsNullOrEmpty(filterQeuery) == false)
            {
                result = filterOn.Equals("name", StringComparison.OrdinalIgnoreCase) ? result.Where(x => x.Name.Contains(filterQeuery))
                         : filterOn.Equals("code", StringComparison.OrdinalIgnoreCase) ? result.Where(x => x.Code.Contains(filterQeuery))
                         : result;
            }
            return await result.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            Region result = await _dbContext.regions.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {

            var result = await _dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            result.Name = region.Name;
            result.Code = region.Code;
            result.RegionImageUrl = region.RegionImageUrl;


            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
