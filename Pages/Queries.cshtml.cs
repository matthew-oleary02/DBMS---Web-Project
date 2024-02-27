using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using DataQueries;

namespace RazorPagesMovie.Pages
{
    public class QueriesModel : PageModel
    {
        private readonly ILogger<QueriesModel> _logger;
        private readonly DataAccess _dataAccess;

        public DataTable? NumofKneeInjuries { get; private set; }
        public DataTable? PlayersWithMultipleInjuries { get; private set; }
        public DataTable? TeamInjuries { get; private set; }
        public DataTable? SevereInjuries { get; private set; }

        public QueriesModel(ILogger<QueriesModel> logger, DataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public void OnGet()
        {
            NumofKneeInjuries = _dataAccess.GetNumofKneeInjuries();
            PlayersWithMultipleInjuries = _dataAccess.GetPlayersWithMultipleInjuries();
            int yourTeamId = 2;
            TeamInjuries = _dataAccess.GetTeamInjuries(yourTeamId);
            SevereInjuries = _dataAccess.GetSevereInjuries();
        }

    }
}
