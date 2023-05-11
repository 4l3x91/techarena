using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public class ApplicationDbContextSeed
{
    private readonly HttpClient httpClient;

    public ApplicationDbContextSeed()
    {
        httpClient = new();
    }

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

        if (!await context.Users.AnyAsync())
        {
            await context.Users.AddRangeAsync(await GetUsersAsync());
            
            await context.SaveChangesAsync();
        }
    }

    private static async Task<List<User>> GetUsersAsync()
    {
        var users = new List<User>();

        for (int i = 0; i < 20; i++)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://randomuser.me/api/");
            string responseBody = await responseMessage.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);

            dynamic data = JsonConvert.DeserializeObject<dynamic>(responseBody);
            
            if (data != null)
            {
                users.Add(new User()
                {
                    Name = data.results[0].name.first,
                    ProfilePictureURL = data.results[0].picture.large,
                    BirthDate = data.results[0].dob.date,
                    Gender = data.results[0].gender,
                });

            }
        }

        return users;

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
        string simhallarfilePath = "../backend/location/badhus_simhallar.json";
        string badplatserfilePath = "../backend/location/badplatser.json";
        string parkerfilePath = "../backend/location/parker.json";
        string elljussparfilePath = "../backend/location/Elljusspår.json";
        string skidsparfilePath = "../backend/location/skidspar.json";

        string simhallarJson = File.ReadAllText(simhallarfilePath);
        string badplatserJson = File.ReadAllText(badplatserfilePath);
        string parkerJson = File.ReadAllText(parkerfilePath);
        string elljussparJson = File.ReadAllText(elljussparfilePath);
        string skidsparJson = File.ReadAllText(skidsparfilePath);

        dynamic simhallarData = JsonConvert.DeserializeObject<dynamic>(simhallarJson);
        dynamic badplatserData = JsonConvert.DeserializeObject<dynamic>(badplatserJson);
        dynamic parkerData = JsonConvert.DeserializeObject<dynamic>(parkerJson);
        dynamic elljussparData = JsonConvert.DeserializeObject<dynamic>(elljussparJson);
        dynamic skidsparData = JsonConvert.DeserializeObject<dynamic>(skidsparJson);

        foreach (var feature in simhallarData.features)
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
        }

        foreach (var feature in badplatserData.features)
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
        }

        foreach (var feature in parkerData.features)
        {
            if (feature.properties.namn != null)
            {
                Location location = new Location
                {
                    Longitude = feature.geometry.coordinates[0],
                    Latitude = feature.geometry.coordinates[1],
                    LocationName = feature.properties.namn
                };
            locations.Add(location);
            }            
        }

        foreach (var feature in elljussparData.features)
        {
            if (feature.properties.Titel != null)
            {
                Location location = new Location
                {
                    Longitude = feature.geometry.coordinates[0][0],
                    Latitude = feature.geometry.coordinates[0][1],
                    LocationName = feature.properties.Titel + "s elljusspår"
                };
            locations.Add(location);
            }            
        }

        foreach (var feature in skidsparData.features)
        {
            if (feature.properties.namn != null)
            {
                Location location = new Location
                {
                    Longitude = feature.geometry.coordinates[0][0],
                    Latitude = feature.geometry.coordinates[0][1],
                    LocationName = feature.properties.namn
                };
            locations.Add(location);
            }            
        }

        return locations;
    }


}