using System.ComponentModel.DataAnnotations;
using EventMi.Core.Constants;

namespace EventMi.Core.Models;

public class EventModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = UserMessages.Required)]
    [StringLength(ValidationConstants.EventNameMaxLength, MinimumLength = ValidationConstants.EventNameMinLength,
        ErrorMessage = UserMessages.StringLength)]
    [Display(Name = "Име на събитие")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = UserMessages.Required)]
    [Display(Name = "Начало на събитието")]
    public DateTime Start { get; set; }

    [Required(ErrorMessage = UserMessages.Required)]
    [Display(Name = "Край на събитието")]
    public DateTime End { get; set; }

    [Required(ErrorMessage = UserMessages.Required)]
    [Display(Name = "Място на провеждане")]
    [StringLength(ValidationConstants.EventPlaceMaxLength, MinimumLength = ValidationConstants.EventPlaceMinLength,
        ErrorMessage = UserMessages.StringLength)]
    public string Place { get; set; } = null!;

    [Display(Name = "Описание на събитието")]
    [StringLength(ValidationConstants.EventDescriptionMaxLength, MinimumLength = ValidationConstants.EventDescriptionMinLength, ErrorMessage = UserMessages.StringLength)]
    public string? Description { get; set; }
}