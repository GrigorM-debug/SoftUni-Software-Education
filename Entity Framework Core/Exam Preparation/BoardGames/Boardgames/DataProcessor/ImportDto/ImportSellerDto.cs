using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Common;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [Required]
        [MaxLength(ValidationConstants.SellerNameMaxLength)]
        [MinLength(ValidationConstants.SellerNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.SellerAddressMaxLength)]
        [MinLength(ValidationConstants.SellerAddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(ValidationConstants.WebsiteRegex)]
        public string Website { get; set; } = null!;

        [Required]
        public int[] Boardgames { get; set; } 
    }
}
