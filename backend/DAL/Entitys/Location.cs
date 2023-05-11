namespace DAL.Entities;

public class Location : BaseEntity
{
    public double[]? Cords { get; set; }
   public string LocationName { get; set; } = string.Empty;
}