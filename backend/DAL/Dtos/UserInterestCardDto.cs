using DAL.Entities;

namespace DAL.Dtos;

public class UserInterestCardDto
{
    public string Username { get; set; } = string.Empty;
    public string InterestName { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string ProfilePictureURL { get; set; } = string.Empty;
    public string Gender { get; set; }
    public int Age { get; set; }
    public string About { get; set; }
    public Location Location { get; set; }
}