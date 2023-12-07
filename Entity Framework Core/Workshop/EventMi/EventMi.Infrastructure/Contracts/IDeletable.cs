namespace EventMi.Infrastructure.Contracts;

public interface IDeletable
{
    bool IsActive { get; set; }

    DateTime? DeletedOn { get; set; }
}