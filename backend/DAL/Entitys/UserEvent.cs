namespace DAL.Entities;

public class UserEvent : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }

}