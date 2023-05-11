namespace DAL.Entities;

public class UserInterest : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid InterestId { get; set; }
    public Guid LevelId { get; set; }
    public string? Note { get; set; }
    public Location? Location { get; set; }
}