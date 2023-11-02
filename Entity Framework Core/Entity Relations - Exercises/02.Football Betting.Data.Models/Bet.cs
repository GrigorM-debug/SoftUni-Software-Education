using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Football_Betting.Data.Models
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; } 

        public 
    }
}
