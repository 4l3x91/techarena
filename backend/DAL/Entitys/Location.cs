namespace DAL.Entities;

public class Location : BaseEntity
{
    public double? Longitude { get; set; }
    public double? Latitude { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public virtual ICollection<UserInterest> UserInterests { get; set; }
}