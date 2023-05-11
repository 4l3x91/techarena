namespace DAL.Entities;

public class UserActivity : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ActivityId { get; set; }
    public Guid LevelId { get; set; }
    public string? Note { get; set; }
    public ActivityLocation? Location { get; set; }
}