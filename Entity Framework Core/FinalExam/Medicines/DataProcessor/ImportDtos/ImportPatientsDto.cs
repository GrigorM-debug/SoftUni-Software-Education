using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicines.Common;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientsDto
    {
        [Required]
        [MaxLength(ValidationConstants.PatientFullNameMaxLength)]
        [MinLength(ValidationConstants.PatientFullNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        public int AgeGroup { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public int[] Medicines { get; set; }
    }
}
