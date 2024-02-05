using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkDTO
    {
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
