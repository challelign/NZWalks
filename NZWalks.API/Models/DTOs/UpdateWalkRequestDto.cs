namespace NZWalks.API.Models.DTOs
{
    public class UpdateWalkRequestDto
    {

        public string Name { get; set; }
        public string Descripton { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

         
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; } 
    }
}
