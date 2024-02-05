﻿using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SqlWalkRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var result = await _dbContext.Walks.FindAsync(id);
            if (result == null) { return null; }
            _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn, string? filterQuery)
        {
            var result = _dbContext.Walks.Include(x => x.Region).Include(x => x.Difficulty).AsQueryable();

            if (string.IsNullOrEmpty(filterOn) == false && String.IsNullOrEmpty(filterQuery) == false)
            {
                result = filterOn.Equals("name", StringComparison.OrdinalIgnoreCase) ? result.Where(x => x.Name.Contains(filterQuery))
                       : filterOn.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase) ? double.TryParse(filterQuery, out var length) ? result.Where(x => x.LengthInKm == length) : result
                       : filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase) ? result.Where(x => x.Description.Contains(filterQuery))
                       : result;
            }


            return await result.ToListAsync();
        }

        public async Task<Walk?> GetById(Guid id)
        {
            var result = await _dbContext.Walks.Include(x => x.Region).Include(x => x.Difficulty).FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var result = await _dbContext.Walks.Include(x => x.Region).Include(x => x.Difficulty).FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) { return null; }
            result.Name = walk.Name;
            result.Description = walk.Description;
            result.LengthInKm = walk.LengthInKm;
            result.WalkImageUrl = walk.WalkImageUrl;
            result.RegionId = walk.RegionId;
            result.DifficultyId = walk.DifficultyId;

            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
