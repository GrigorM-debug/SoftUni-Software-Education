using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Football_Betting.Data.Common;

namespace _02.Football_Betting.Data.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayerNameMaxLength)]
        public string Name { get; set; }

        [Required]  
        public int SquadNumber { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]  
        public bool IsInjured { get; set; }

        //TODO: Navigation properties
    }
}
