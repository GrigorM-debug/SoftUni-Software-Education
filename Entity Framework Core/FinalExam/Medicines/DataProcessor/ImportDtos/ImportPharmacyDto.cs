using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Medicines.Common;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [Required] 
        [XmlAttribute("non-stop")] 
        public string IsNonStop { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.PharmacyNameMaxLength)]
        [MinLength(ValidationConstants.PharmacyNameMinLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.PharmacyPhoneNumberLenght)]
        [RegularExpression(ValidationConstants.RegexPattern)]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Medicines")]
        public ImportMedicineDto[] Medicines { get; set; }
    }

    [XmlType("Medicine")]
    public class ImportMedicineDto
    {
        [Required]
        [XmlAttribute("category")]
        public int Category { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MedicineNameMaxLength)]
        [MinLength(ValidationConstants.MedicineNameMinLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(ValidationConstants.MedicinePriceMinRange, ValidationConstants.MedicinePriceMaxRange)]
        [XmlElement("Price")]
        public string Price { get; set; } = null!;

        [Required]
        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; } = null!;

        [Required]
        [XmlElement("ExpiryDate")]
        public string ExpiryDate { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.MedicineProducerMaxLength)]
        [MinLength(ValidationConstants.MedicineProducerMinLength)]
        [XmlElement("Producer")]
        public string Producer { get; set; } = null!;
    }
}
