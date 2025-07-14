using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepositoy
    {
        public Task<Region> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>{

                 new Region
                    {
                        Id = Guid.NewGuid(),
                        Name = "Canterbury Region",
                        Code = "CAN",
                        RegionImageUrl = "https://picsum.photos/id/1025/600/400"
                    },
                    new Region
                    {
                        Id = Guid.NewGuid(),
                        Name = "Wellington Region",
                        Code = "WLG",
                        RegionImageUrl = "https://picsum.photos/id/1033/600/400"
                    },
                    new Region
                    {
                        Id = Guid.NewGuid(),
                        Name = "Otago Region",
                        Code = "OTA",
                        RegionImageUrl = "https://picsum.photos/id/1042/600/400"
                    },
                    new Region
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bay of Plenty Region",
                        Code = "BOP",
                        RegionImageUrl = "https://picsum.photos/id/1056/600/400"
                    }
            };
        }

        public Task<Region?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
