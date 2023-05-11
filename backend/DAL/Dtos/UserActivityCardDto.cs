namespace DAL.Dtos;

public class UserActivityCardDto
{
    public string Username { get; set; } = string.Empty;
    public string ActivityName { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string ProfilePictureURL { get; set; } = string.Empty;
    public string Gender { get; set; }
    public int Age { get; set; }
}