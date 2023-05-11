namespace DAL.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string ProfilePictureURL { get; set; } = string.Empty;
    public DateTime BirthDate { private get; set; }
    public int Age { get{ return DateTime.Now.Year - BirthDate.Year;} }
    public string Gender { get; set; } = String.Empty;
    public List<UserActivity> UserActivities { get; set; } = new();
    public string About { get; set; } = String.Empty;
}