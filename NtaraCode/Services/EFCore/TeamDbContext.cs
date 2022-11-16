using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using NtaraCode.Models;
using System.Text.Json;

namespace NtaraCode.Services.EFCore
{
    #region Team Database Context

    #region EF Core DB Context
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options)
        : base(options)
        {
            this.Seed();
        }
        public DbSet<Team> Teams { get; set; }
    }
    #endregion

    #region Team Seeder Class
    static class TeamSeeder
    {
       
        private static IWebHostEnvironment _hostEnvironment;
        public static bool IsInitialized { get; private set; }
        public static void Init(IWebHostEnvironment hostEnvironment)
        {
            if (!IsInitialized)
            {
                _hostEnvironment = hostEnvironment;
                IsInitialized = true;
            }
        }
        private static string JsonFileName
            => Path.Combine(_hostEnvironment.WebRootPath, "data", "CollegeFootballTeamWinsWithMascots.json");
        static volatile bool seeded = false;
        public static void Seed(this TeamDbContext context)
        {
            if (!seeded && context.Teams.Count() == 0)
            {
                if (!seeded)
                {
                    var teams = GetTeams();

                    context.Teams.AddRange(teams);
                    context.SaveChanges();
                    seeded = true;
                }
            }
        }
        public static IEnumerable<Team> GetTeams()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Team[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
    #endregion

    #region old_code

    //    public static class TeamSeeder
    //    {
    //        static string dir;


    //        static TeamSeeder()
    //        {
    //            dir = Directory.GetCurrentDirectory();

    //        }

    //        // TODO: 

    //        private static string JsonFileName 
    //            => Path.Combine(dir, "wwwroot","data","CollegeFootballTeamWinsWithMascots.json");
    //        static volatile bool seeded = false;
    //        public static void Seed(this TeamDbContext context)
    //        {
    //            if (!seeded && context.Teams.Count() == 0)
    //            {
    //                if (!seeded)
    //                {
    //                    var teams = GetTeams();

    //                    context.Teams.AddRange(teams);
    //                    context.SaveChanges();
    //                    seeded = true;
    //                }
    //            }
    //        }


    //        public static IEnumerable<Team> GetTeams()
    //        {
    //            using var jsonFileReader = File.OpenText(JsonFileName);
    //            return JsonSerializer.Deserialize<Team[]>(jsonFileReader.ReadToEnd(),
    //                new JsonSerializerOptions
    //                {
    //                    PropertyNameCaseInsensitive = true
    //                });
    //        }

    //    }
    #endregion
    
    #endregion
}


