using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Football_Betting.Data.Common;

namespace _02.Football_Betting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TownNameMaxLength)]
        public string Name { get; set; }

        public int CountryId { get; set; }

        //TODO: navigation properties
    }
}
