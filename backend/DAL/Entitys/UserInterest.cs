namespace DAL.Entities;

public class UserInterest : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ActivityId { get; set; }
    public Guid LevelId { get; set; }
}