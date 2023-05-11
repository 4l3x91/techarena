namespace DAL.Entities;

public class Activity : BaseEntity
{
    public string Name { get; set; } = String.Empty;

    public virtual ICollection<UserActivity> UserActivities { get; set; }
}

