using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        //Task<List<Walk>> GetAllAsyinc();
        /*      Task<List<Walk>> GetAllAsyinc(string? name = null,
                  double? lengthInKm = null ,
                  string ? description = null,
                  string? sortBy = null,
                  bool isDescending = false,
                  int pageNumber = 1,
                  int pageSize = 10
                  );*/
        Task<PaginatedResponseDto<Walk>> GetAllAsyinc(
          string? name = null,
          double? lengthInKm = null,
          string? description = null,
          string? sortBy = null,
          bool isDescending = false,
          int pageNumber = 1,
          int pageSize = 10
            );

        Task<Walk?> GetByIdAsync(Guid id); 
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
