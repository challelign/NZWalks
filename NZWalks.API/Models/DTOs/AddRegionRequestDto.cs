using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class AddRegionRequestDto
    {



       
        [Required]
        [MinLength (3, ErrorMessage ="Code has to be a mini of 3 chars")]
        [MaxLength (3, ErrorMessage ="Code has to be a mini of 3 chars")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name must be greater than 100 chars long")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
