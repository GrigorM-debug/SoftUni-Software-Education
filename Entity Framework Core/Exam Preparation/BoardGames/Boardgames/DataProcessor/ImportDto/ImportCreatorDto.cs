using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Boardgames.Common;
using Boardgames.Data.Models.Enums;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [Required]
        [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
        [MinLength(ValidationConstants.CreatorFirstNameMinLength)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
        [MinLength(ValidationConstants.CreatorLastNameMinLength)]
        [XmlElement("LastName")]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public ImportBoardGameDto[] Boardgames { get; set; }
    }
}
