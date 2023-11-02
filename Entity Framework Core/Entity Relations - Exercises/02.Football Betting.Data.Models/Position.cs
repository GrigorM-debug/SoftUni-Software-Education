using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Football_Betting.Data.Common;

namespace _02.Football_Betting.Data.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PositionNameMaxLength)]
        public string Name { get; set; }

        //TODO: Navigation Properties
    }
}
