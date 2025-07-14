using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepositoy
    {

        /*
         A repository provides a layer of abstraction over data access logic. 
        It hides the actual database logic behind an interface, enabling loose coupling.
        lives in Application Layer or  Domain Layer as interfaces.
        Implementation lives in Infrastructure Layer  using DbContext.

        
         */
       Task<List<Region>> GetAllAsync();
       Task <Region?> GetByIdAsync(Guid id);
       Task <Region> CreateAsync(Region region);
       Task <Region?> UpdateAsync(Guid id ,Region region);

       Task<Region?> DeleteAsync(Guid id);

    }
}
