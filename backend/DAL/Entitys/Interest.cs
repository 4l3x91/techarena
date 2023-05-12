namespace DAL.Entities;

public class Interest : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public virtual ICollection<UserInterest> UserInterests { get; set; }
}

