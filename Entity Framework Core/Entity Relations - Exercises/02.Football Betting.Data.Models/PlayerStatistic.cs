using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Football_Betting.Data.Models
{
    public class PlayerStatistic
    {
        //
        public int GameId { get; set; }

        public int PlayerId { get; set; }

        public int ScoredGoals { get; set; }

        public int Assists { get; set; }

        public int MinutesPlayed { get; set; }

        //TODO: Composite primary key in Fluent API
    }
}
