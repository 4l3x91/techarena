using DAL.Entities;

namespace DAL.Dtos;

public class UserRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string ProfilePictureURL { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public List<UserInterest> UserInterests { get; set; } = new();
    public string About { get; set; } = string.Empty;
    public Guid PassAuthUserId { get; set; }
}