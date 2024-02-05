using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Error on minLengh")]
        [MaxLength(3, ErrorMessage = "Error on maxLengh")]
 
        public string Code { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Error on minLengh")]
        [MaxLength(20, ErrorMessage = "Error on maxLengh")]
 
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
