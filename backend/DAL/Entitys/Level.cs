namespace DAL.Entities;

public class Level : BaseEntity
{
    public string Name { get; set; } = String.Empty;

    public virtual ICollection<UserInterest> UserInterests { get; set; }
}