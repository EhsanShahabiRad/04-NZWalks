﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        [Required]
      
        
        public Guid Id { get; set; }
        [MinLength(3, ErrorMessage = "Error Message")]
        [MaxLength(15, ErrorMessage = "Error Message")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double lenghInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}