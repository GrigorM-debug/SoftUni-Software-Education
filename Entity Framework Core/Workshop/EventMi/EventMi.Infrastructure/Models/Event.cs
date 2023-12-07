using System.ComponentModel.DataAnnotations;
using EventMi.Infrastructure.Constants;
using EventMi.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventMi.Infrastructure.Models;

[Comment("Събитие")]
public class Event : IDeletable
{
    [Key]
    [Comment("Идентификатор на събитие")]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.EventNameMaxLength)]
    [Comment("Име на събитие")]
    public string Name { get; set; } = null!;

    [Required]
    [Comment("Начало на събитието")]
    public DateTime Start { get; set; }

    [Required]
    [Comment("Край на събитието")]
    public DateTime End { get; set; }

    [Required]
    [Comment("Място на провеждане")]
    [MaxLength(ValidationConstants.EventPlaceMaxLength)]
    public string Place { get; set; } = null!;

    [Required]
    [Comment("Статус на събитието")]
    public bool IsActive { get; set; } = true;

    [Comment("Дата на изтриване")] public DateTime? DeletedOn { get; set; }
}