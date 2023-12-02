using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
    public class PatientMedicine
    {
        [Required]
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        [Required]
        public virtual Patient Patient { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(MedicineId))]
        public int MedicineId { get; set; }

        [Required] 
        public virtual Medicine Medicine { get; set; } = null!;
    }
}
