using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{

    [XmlType("Boardgame")]
    public class ImportBoardGameDto
    {
        [Required]
        [MaxLength(ValidationConstants.BoardgameMaxNameLenght)]
        [MinLength(ValidationConstants.BoardgameMinNameLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(ValidationConstants.BoardgameRatingMinValue, ValidationConstants.BoardGameRatingMaxValue)]
        [XmlElement("Rating")]
        public double Rating { get; set; }

        [Required]
        [Range(ValidationConstants.BoardgameYearPublishedMinValue, ValidationConstants.BoardgameYearPublishedMaxValue)]
        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [Required] 
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}
