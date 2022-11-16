using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NtaraCode.Models;
using NtaraCode.Services;
using System.Threading.Tasks;

namespace NtaraCode.Pages
{
    #region Index Model Class
    [BindProperties]
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly ILogger<IndexModel> _logger;
        public ITeamService _teamService;
        #endregion

        #region Property
        [BindProperty]
        public IAsyncEnumerable<Team> Teams { get; private set; }
        #endregion

        #region Constructor
        public IndexModel(ILogger<IndexModel> logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }
        #endregion 

        #region OnGet Method
        public async Task<IActionResult> OnGet()
        {
            
            Teams = _teamService.GetTeams() as IAsyncEnumerable<Team>;
            return Page();
        }
        #endregion

        #region old method
        //public void OnGet()
        //{
        //    //TODO: Convert to Task Async
        //    Teams = _teamService.GetTeams();
        //}
        #endregion

    }
    #endregion
}