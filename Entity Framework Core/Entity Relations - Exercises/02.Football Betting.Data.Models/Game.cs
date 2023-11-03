using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>(); 
        }

        [Key]
        public int GameId { get; set; }

        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; } = null!;

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

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
