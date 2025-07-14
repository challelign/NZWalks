using NZWalks.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class AddWalkRequestDto
    {

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Descripton { get; set; }


        [Required(ErrorMessage = "Length in Km is required.")]
        [Range(0.1, 1000.0, ErrorMessage = "Length in Km must be between 0.1 and 1000.")]
        public double LengthInKm { get; set; }

        [Url(ErrorMessage = "WalkImageUrl must be a valid URL.")]
        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
 
    }
}
