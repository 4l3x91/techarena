using System.Text;
using API.Identity.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
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

        if (!await context.UserInterests.AnyAsync())
        {
            await context.UserInterests.AddRangeAsync(await GetUserInterestsAsync(context));
            await context.SaveChangesAsync();
        }
    }

    private static async Task<List<UserInterest>> GetUserInterestsAsync(ApplicationDbContext context)
    {
        var random = new Random();
        var userInterests = new List<UserInterest>();

        foreach (var user in context.Users)
        {
            for (int i = 0; i < random.Next(1, 4); i++)
            {
                var Interesets = await context.Interests.ToListAsync();
                var Levels = await context.Levels.ToListAsync();
                var Locations = await context.Locations.ToListAsync();

                userInterests.Add(new UserInterest()
                {
                    UserId = user.Id,
                    InterestId = Interesets[random.Next(0, Interesets.Count())].Id,
                    LevelId = Levels[random.Next(0, Levels.Count())].Id,
                    LocationId = random.Next(1, 4) != 3 ? Locations[random.Next(0, Locations.Count())].Id : null
                });
            }
        }

        return userInterests;
    }

    private static async Task<List<User>> GetUsersAsync()
    {
        HttpClient httpClient = new HttpClient();

        
        var users = new List<User>();

        for (int i = 0; i < 50; i++)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://randomuser.me/api/");
            string responseBody = await responseMessage.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject<dynamic>(responseBody);

            if (data != null)
            {
                Console.WriteLine(data.results[0].dob.date);
                users.Add(new User()
                {
                    Name = data.results[0].name.first,
                    ProfilePictureURL = data.results[0].picture.large,
                    BirthDate = data.results[0].dob.date,
                    Gender = data.results[0].gender,
                    AuthUserId = Guid.NewGuid()
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
            new Interest() { Name = "Muay Thai", ImageUrl = "https://cdn.onefc.com/wp-content/uploads/2020/09/Felipe-Lobo-Yodpanomrung-Jitmuangnon-Muay-Thai-1920X1280-29-1536x1024.jpg" },
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
            new Interest() { Name = "Skiing cross-country" , ImageUrl = "https://d3aux7tjp119y2.cloudfront.net/images/I20skidspC3A5ret20-20Leif20Wikberg-CMSTempl.max-1667x600_0IQv2k8.jpg"},
            new Interest() { Name = "Snowboarding" },
            new Interest() { Name = "Rowing", ImageUrl = "https://www.britishrowing.org/wp-content/uploads/2022/08/GBR_M9_ERC2022.jpg"},
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