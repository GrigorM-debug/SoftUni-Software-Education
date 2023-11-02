using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Football_Betting.Data.Common;

namespace _02.Football_Betting.Data.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Required]  
        public int HomeTeamGoals { get; set; }

        [Required]  
        public int AwayTeamGoals { get; set; }

        [Required]  
        public DateTime DateTime { get; set; }

        [Required]
        public decimal HomeTeamBetRate { get; set; }

        [Required]
        public decimal AwayTeamBetRate { get; set; }

        [Required]  
        public decimal DrawBetRate { get; set; }

        [MaxLength(ValidationConstants.GameResultLength)]
        public string? Result { get; set; }

        //TODO: Navigation properties
    }
}
