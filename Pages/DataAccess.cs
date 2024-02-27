using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DataObjects;

namespace DataQueries
{
    public class DataAccess
    {
        private readonly DatabaseContext _dbContext;
        private readonly string _connectionString;

        public DataAccess(IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string is null or empty.");
            }

            _dbContext = new DatabaseContext(_connectionString);
        }
        public DataTable GetNumofKneeInjuries()
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(
            @"SELECT mp.Position, COUNT(mir.InjuryRecordID) AS NumofKneeInjuries
            FROM mattPlayers mp
            INNER JOIN [mattAttributes] ma ON mp.PlayerID = ma.PlayerID
            INNER JOIN [mattInjuryRecords] mir ON mp.PlayerID = mir.PlayerID
            INNER JOIN [mattInjuryType] mit ON mir.InjuryRecordID = mit.InjuryRecordID
            WHERE mit.InjuryName LIKE '%knee%'
            GROUP BY mp.Position
            ORDER BY COUNT(mir.InjuryRecordID) DESC", connection))
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}


        public DataTable GetPlayersWithMultipleInjuries()
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(
            @"SELECT mp.TeamID, mp.PlayerName, ma.YearsExperience, COUNT(mir.InjuryRecordID) AS NumberofInjuries
            FROM mattPlayers mp
            INNER JOIN [mattAttributes] ma ON mp.PlayerID = ma.PlayerID
            INNER JOIN [mattInjuryRecords] mir ON mp.PlayerID = mir.PlayerID
            INNER JOIN [mattInjuryType] mit ON mir.InjuryRecordID = mit.InjuryRecordID
            GROUP BY mp.TeamID, mp.PlayerName, ma.YearsExperience
            HAVING COUNT(mir.InjuryRecordID) > 1", connection))
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}


        public DataTable GetTeamInjuries(int teamId)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(
            @"SELECT mt.TeamName, mt.TeamID, mp.PlayerID, mp.PlayerName, mp.ContractLengthRem, 
            mp.SalaryPerYear, mp.RoleOnTeam, mit.InjuryName, mit.InjurySeverity
            FROM [mattTeam] mt
            INNER JOIN [mattPlayers] mp ON mt.TeamID = mp.TeamID
            INNER JOIN [mattInjuryRecords] mir ON mp.PlayerID = mir.PlayerID
            INNER JOIN [mattInjuryType] mit ON mir.InjuryRecordID = mit.InjuryRecordID
            WHERE mt.TeamID = @TeamID AND mp.ContractLengthRem < 2", connection))
        {
            command.Parameters.AddWithValue("@TeamID", teamId);
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}


        public DataTable GetSevereInjuries()
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(
            @"SELECT mrp.RecoveryPlanID, mit.InjuryName, mit.InjuryDetails, 
            mit.InjurySeverity, mir.GameType, mrp.NextSteps
            FROM [mattInjuryRecords] mir
            INNER JOIN [mattInjuryType] mit ON mir.InjuryRecordID = mit.InjuryRecordID
            INNER JOIN [mattRecoveryPlan] mrp ON mit.InjuryTypeID = mrp.InjuryTypeID
            WHERE mit.InjurySeverity = 'Severe'", connection))
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
    }

    }
}
