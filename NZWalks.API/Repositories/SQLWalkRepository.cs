using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }



        //public async Task<List<Walk>> GetAllAsyinc(
        public async Task<PaginatedResponseDto<Walk>> GetAllAsyinc(
            string? name = null,
            double? lengthInKm = null, 
            string? description = null,
            string? sortBy = null,
            bool isDescending = false,
            int pageNumber = 1,
            int pageSize = 10
            )
        {
            //return await dbContext.Walks.ToListAsync();

            //Include("Difficulty") ->Model name
            //return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //Filtering
            if (!string.IsNullOrWhiteSpace(name))
            {
                //walks = walks.Where(x => x.Name.Contains(name));  //✅ Case-insensitive
                walks = walks.Where(x => x.Name.ToLower().Contains(name.ToLower()));  
            }

            if (lengthInKm.HasValue)
            {
                walks = walks.Where(x => x.LengthInKm == lengthInKm.Value);
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                //✅If you must ensure case-insensitivity regardless of DB collation

               // If you're using an in-memory collection (e.g., after .ToList())

              //For quick filtering during testing / debugging

                //walks = walks.Where(x => x.Descripton.ToLower().Contains(description.ToLower()));

                //or
                //better performance,database collation is case-insensitive
                walks = walks.Where(x => EF.Functions.Like(x.Descripton, $"%{description}%"));
            }

            // Total count before pagination
            var totalCount = await walks.CountAsync();

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        walks = isDescending ? walks.OrderByDescending(x => x.Name) : walks.OrderBy(x => x.Name);
                        break;
                    case "length":
                        walks = isDescending ? walks.OrderByDescending(x => x.LengthInKm) : walks.OrderBy(x => x.LengthInKm);
                        break;
                    default:
                        // Optional: apply default sort or ignore
                        break;
                }
            }

            // Pagination
            var skip = (pageNumber - 1) * pageSize;
            //walks = walks.Skip(skip).Take(pageSize);
            //return await walks.ToListAsync();

           var walksResponse = await walks.Skip(skip).Take(pageSize).ToListAsync();

            return new PaginatedResponseDto<Walk>
            {
                Data = walksResponse,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            //return await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk  walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Descripton = walk.Descripton; 
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walkRegion = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkRegion == null)
            {
                return null;
            }

            dbContext.Walks.Remove(walkRegion);
            await dbContext.SaveChangesAsync();

            return walkRegion;
        }

    
    }
}
