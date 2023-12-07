using EventMI.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMI.Core.Constants;
using ValidationConstants = EventMI.Core.Constants.ValidationConstants;

namespace EventMI.Core.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = UserMessages.Required)]
        [StringLength(ValidationConstants.EventNameMaxLength, MinimumLength = ValidationConstants.EventNameMinLength, ErrorMessage = UserMessages.StringLength)]
        [Display(Name = "Име на събитие")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = UserMessages.Required)]
        [Display(Name = "Начало на събитието")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = UserMessages.Required)]
        [Display(Name = "Край на събитието")]
        public DateTime End { get; set; }

        [Required(ErrorMessage = UserMessages.Required)]
        [StringLength(ValidationConstants.EventPlaceMaxLength, MinimumLength = ValidationConstants.EventPlaceMinLength, ErrorMessage = UserMessages.StringLength)]
        [Display(Name = "Място на провеждане")]
        public string Place { get; set; } = null!;
    }
}
