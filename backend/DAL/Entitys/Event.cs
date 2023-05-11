namespace DAL.Entities;

public class Event : BaseEntity
{
    public Guid UserInterestId { get; set; }
    public UserInterest UserInterest { get; set; } = new();
    public DateTime Time { get; set; }
    public Boolean IsPublic { get; set; }

    public virtual ICollection<UserEvent> UserEvents { get; set; }
}