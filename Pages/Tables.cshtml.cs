using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Data;
using DataObjects;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, DatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        public List<mattAttributes> MattAttributes { get; set; } = new();
        public List<mattIndustry> MattIndustry { get; set; } = new();
        public List<mattInjuryRecords> MattInjuryRecords { get; set; } = new();
        public List<mattInjuryType> MattInjuryType { get; set; } = new();
        public List<mattMedicalEmployees> MattMedicalEmployees { get; set; } = new();
        public List<mattPlayerStats> MattPlayerStats { get; set; } = new();
        public List<mattPlayers> MattPlayers { get; set; } = new();
        public List<mattRecoveryPlan> MattRecoveryPlan { get; set; } = new();
        public List<mattTeam> MattTeam { get; set; } = new();

        public void OnGet()
        {
            MattAttributes = _dbContext.ReturnMattAttributes();
            MattIndustry = _dbContext.ReturnMattIndusty();
            MattInjuryRecords = _dbContext.ReturnMattInjuryRecords();
            MattInjuryType = _dbContext.ReturnMattInjuryType();
            MattMedicalEmployees = _dbContext.ReturnMattMedicalEmployees();
            MattPlayerStats = _dbContext.ReturnMattPlayerStats();
            MattPlayers = _dbContext.ReturnMattPlayers();
            MattRecoveryPlan = _dbContext.ReturnMattRecoveryPlan();
            MattTeam = _dbContext.ReturnMattTeam();
        }
    }
}