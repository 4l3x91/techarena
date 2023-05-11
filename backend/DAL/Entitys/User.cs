namespace DAL.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string ProfilePictureURL { get; set; } = string.Empty;
    public DateTime BirthDay { get; set; }
    public string Gender { get; set; } = String.Empty;
    public List<UserActivity> UserActivities { get; set; } = new();
    public string About { get; set; } = String.Empty;
}
