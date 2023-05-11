namespace DAL.Entities;

public class Activity : BaseEntity
{
    public string Name { get; set; } = String.Empty;

    public virtual ICollection<UserInterest> UserInterests { get; set; }
}

