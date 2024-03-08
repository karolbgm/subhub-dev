namespace Subhub.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
}

//serves as a foundation for other entities within my app.
//contains common properties shared among all entities