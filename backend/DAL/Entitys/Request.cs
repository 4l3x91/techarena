namespace DAL.Entities;

public class Request : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
}