namespace DAL.Entities;

public class Event : BaseEntity
{
    public Guid UserActivityId { get; set; }
    public UserInterest UserInterest { get; set; } = new();
    public string? Location { get; set; }
    public DateTime Time { get; set; }
    public List<User>? Users { get; set; }
    public Boolean IsPublic { get; set; }
}