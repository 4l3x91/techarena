namespace DAL.Entities;

public class ActivityLocation : BaseEntity
{
    public Guid ActivityId { get; set; }
    public string ActivityPosition { get; set; }
   public string LocationName { get; set; }
}