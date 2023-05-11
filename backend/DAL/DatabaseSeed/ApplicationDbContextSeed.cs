using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public class ApplicationDbContextSeed
{
   

    public static async Task SeedAsync(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (!await context.Locations.AnyAsync())
        {
            await context.Locations.AddRangeAsync(GetLocations());

            await context.SaveChangesAsync();
        }

        if (!await context.Interests.AnyAsync())
        {
            await context.Interests.AddRangeAsync(GetInterests());

            await context.SaveChangesAsync();
        }

        if (!await context.Levels.AnyAsync())
        {
            await context.Levels.AddRangeAsync(GetLevels());

            await context.SaveChangesAsync();
        }
    }

    private static List<Level> GetLevels()
    {
        return new List<Level>()
        {
            new Level() { Name = "Beginner" },
            new Level() { Name = "Novice" },
            new Level() { Name = "Intermediate" },
            new Level() { Name = "Advanced" },
            new Level() { Name = "Expert" }
        };

    }

    private static List<Interest> GetInterests()
    {
        return new List<Interest>()
        {
            new Interest() { Name = "Walking" },
            new Interest() { Name = "Cycling" },
            new Interest() { Name = "Swimming" },
            new Interest() { Name = "Dancing" },
            new Interest() { Name = "Yoga" },
            new Interest() { Name = "Pilates" },
            new Interest() { Name = "Weightlifting" },
            new Interest() { Name = "Bodyweight exercises" },
            new Interest() { Name = "High-intensity interval training" },
            new Interest() { Name = "Karate" },
            new Interest() { Name = "Taekwondo" },
            new Interest() { Name = "Judo" },
            new Interest() { Name = "Brazilian Jiu-Jitsu" },
            new Interest() { Name = "Muay Thai" },
            new Interest() { Name = "Kung Fu" },
            new Interest() { Name = "Boxing" },
            new Interest() { Name = "Krav Maga" },
            new Interest() { Name = "Aikido" },
            new Interest() { Name = "Capoeira" },
            new Interest() { Name = "Tennis" },
            new Interest() { Name = "Soccer" },
            new Interest() { Name = "Basketball" },
            new Interest() { Name = "Volleyball" },
            new Interest() { Name = "Hockey" },
            new Interest() { Name = "Golf" },
            new Interest() { Name = "Skiing downhill" },
            new Interest() { Name = "Skiing cross-country" },
            new Interest() { Name = "Snowboarding" },
            new Interest() { Name = "Rowing" },
            new Interest() { Name = "Climbing indoor" },
            new Interest() { Name = "Climbing outdoor" },
            new Interest() { Name = "Jumping rope" },
            new Interest() { Name = "Hiking" },
            new Interest() { Name = "Kayaking or canoeing" },
            new Interest() { Name = "Surfing" },
            new Interest() { Name = "Skateboarding" },
            new Interest() { Name = "Rollerblading" },
            new Interest() { Name = "Calisthenics" },
            new Interest() { Name = "Tai chi" },
            new Interest() { Name = "Stretching" },
        };
    }

    private static List<Location> GetLocations()
    {
        var locations = new List<Location>();
        string filePath = "../backend/location/badhus_simhallar.json";

        // Read the JSON file into a string
        string json = File.ReadAllText(filePath);

        // Deserialize the JSON string into an object
        dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

        // Loop through the features and map them to Location objects
        foreach (var feature in data.features)
        {
            if (feature.properties.name != null)
            {
                Location location = new Location
                {
                    Longitude = feature.geometry.coordinates[0],
                    Latitude = feature.geometry.coordinates[1],
                    LocationName = feature.properties.name
                };
            locations.Add(location);
            }

            
            // Do something with the location object
        }

        return locations;
    }
}