using Microsoft.EntityFrameworkCore;
using NtaraCode.Models;
using NtaraCode.Services.EFCore;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;

namespace NtaraCode.Services
{
    #region TeamService
    public class TeamService : ITeamService
    {
        #region Field
        private readonly TeamDbContext _context;
        #endregion

        #region Constructor
        public TeamService()
        {
            var options = new DbContextOptionsBuilder<TeamDbContext>()
                .UseInMemoryDatabase("Teams")
                .Options;

            _context = new TeamDbContext(options);
        }
        #endregion

        #region Method
        public IAsyncEnumerable<Team> GetTeams()
        {
            return _context.Teams.AsAsyncEnumerable<Team>();
        }
        #endregion
    }
    #endregion

    #region ITeamService interface
    public interface ITeamService
    {
        IAsyncEnumerable<Team> GetTeams();
    }
    #endregion
}
