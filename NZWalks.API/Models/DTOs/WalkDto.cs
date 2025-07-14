namespace NZWalks.API.Models.DTOs
{
    public class WalkDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }


        //START COMMENT You can comment this if you do not want to see the id
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
        // END COMMNET  

        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }

    }
}
