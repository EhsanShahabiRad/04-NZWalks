using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Domain
{
    public class Difficulty
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
