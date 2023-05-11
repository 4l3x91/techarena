namespace DAL.Entities;

public class Event : BaseEntity
{
    public Guid ActivityId { get; set; }
    public string? Location { get; set; }
    public DateTime Time { get; set; }
    public List<User>? Users { get; set; }
    public Boolean IsPublic { get; set; }
}