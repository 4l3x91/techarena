namespace DAL.Entities;

public class UserActivity : BaseEntity
{
    public int UserId { get; set; }
    public int ActivityId { get; set; }
    public int LevelId { get; set; }
}