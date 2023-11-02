using System.ComponentModel.DataAnnotations;
using _02.Football_Betting.Data.Common;

namespace _02.Football_Betting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.TeamLogoURLMaxLength)]
        public string LogoURL { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.TeamInitialsMaxLength)]
        public string Initials { get; set; } = null!;

        [Required]
        public decimal Budget { get; set; }

        //TODO: Make the relations and navigation properties
        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorId { get; set; }

        public int TownId { get; set; }
    }
}