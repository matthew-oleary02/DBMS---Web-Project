using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataObjects
{

    public class mattAttributes
    {
        public int AttributesID { get; set; }
        public string? YearsExperience { get; set; }
        public string? Height_inches { get; set; }
        public string? Weight_lbs { get; set; }
        public int? PlayerID { get; set; }
    }

    public class mattIndustry
    {
        public int IndustryID { get; set; }
        public string? IndustryType { get; set; }
        public string? IndustryLevel { get; set; }
        
    }

    public class mattInjuryRecords
    {
        public int InjuryRecordID { get; set; }
        public DateTime? DateOfInjury { get; set; }
        public int? GameNumber { get; set; }
        public string? GameType { get; set; }
        public int? PlayerID { get; set; }
    }

    public class mattInjuryType
    {
        public int InjuryTypeID { get; set; }
        public string? InjuryName { get; set; }
        public string? InjuryDetails { get; set; }
        public string? InjurySeverity { get; set; }
        public int? InjuryRecordID { get; set; }
    }

    public class mattMedicalEmployees
    {
        public int MedicalEmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position_or_Experise { get; set; }
        public string? YearsExperience { get; set; }
        public int? TeamID { get; set; }
    }

    public class mattPlayerStats
    {
        public int PlayerStatsID { get; set; }
        public string? PointsPerGame { get; set; }
        public string? Assists { get; set; }
        public string? Rebounds { get; set; }
        public string? Steals { get; set; }
        public string? Blocks { get; set; }
        public int? PlayerID { get; set; }
    }

    public class mattPlayers
    {
        public int PlayerID { get; set; }
        public string? PlayerName { get; set; }
        public string? Position { get; set; }
        public string? College { get; set; }
        public int? ContractLengthRem { get; set; }
        public SqlMoney? SalaryPerYear { get; set; }
        public string? RoleOnTeam { get; set; }
        public int? TeamID { get; set; }
    }

    public class mattRecoveryPlan
    {
        public int RecoveryPlanID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? RecoveryStatus { get; set; }
        public string? NextSteps { get; set; }
        public int? InjuryTypeID { get; set; }
    }

    public class mattTeam
    {
        public int TeamID { get; set; }
        public string? TeamLocationCity { get; set; }
        public string? TeamLocationState { get; set; }
        public string? TeamName { get; set; }
        public int? IndustryID { get; set; }
    }

    public class DatabaseContext
    {
        public string ConnectionString { get; set; }
        public List<mattAttributes> MattAttributes = new List<mattAttributes>();
        public List<mattIndustry> MattIndustry = new List<mattIndustry>();
        public List<mattInjuryRecords> MattInjuryRecords = new List<mattInjuryRecords>();
        public List<mattInjuryType> MattInjuryType = new List<mattInjuryType>();
        public List<mattMedicalEmployees> MattMedicalEmployees = new List<mattMedicalEmployees>();
        public List<mattPlayerStats> MattPlayerStats = new List<mattPlayerStats>();
        public List<mattPlayers> MattPlayers = new List<mattPlayers>();
        public List<mattRecoveryPlan> MattRecoveryPlan = new List<mattRecoveryPlan>();
        public List<mattTeam> MattTeam = new List<mattTeam>();
        public DatabaseContext(string connectionString)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public List<mattAttributes> ReturnMattAttributes()
        {
            List<mattAttributes> MattAttributes = new List<mattAttributes>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattAttributes", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattAttributes ma = new()
                        {
                            AttributesID = reader.GetInt32(0),
                            YearsExperience = reader.GetString(1),
                            Height_inches = reader.GetString(2),
                            Weight_lbs = reader.GetString(3),
                            PlayerID = reader.GetInt32(4),
                        };

                        MattAttributes.Add(ma);
                    }
                }
            }

            return MattAttributes;
        }

        public List<mattIndustry> ReturnMattIndusty()
        {
            List<mattIndustry> MattAttributes = new List<mattIndustry>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattIndustry", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattIndustry mi = new()
                        {
                            IndustryID = reader.GetInt32(0),
                            IndustryType = reader.GetString(1),
                            IndustryLevel = reader.GetString(2),
                        };

                        MattIndustry.Add(mi);
                    }
                }
            }

            return MattIndustry;
        }

        public List<mattInjuryRecords> ReturnMattInjuryRecords()
        {
            List<mattInjuryRecords> MattInjuryRecords = new List<mattInjuryRecords>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattInjuryRecords", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattInjuryRecords mir = new()
                        {
                            InjuryRecordID = reader.GetInt32(0),
                            DateOfInjury = reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1),
                            GameNumber = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                            GameType = reader.IsDBNull(3) ? null : reader.GetString(3),
                            PlayerID = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                        };

                        MattInjuryRecords.Add(mir);
                    }
                }
            }

            return MattInjuryRecords;
        }

        public List<mattInjuryType> ReturnMattInjuryType()
        {
            List<mattInjuryType> MattInjuryType = new List<mattInjuryType>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattInjuryType", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattInjuryType mit = new()
                        {
                            InjuryTypeID = reader.GetInt32(0),
                            InjuryName = reader.GetString(1),
                            InjuryDetails = reader.GetString(2),
                            InjurySeverity = reader.GetString(3),
                            InjuryRecordID = reader.GetInt32(4),
                        };

                        MattInjuryType.Add(mit);
                    }
                }
            }

            return MattInjuryType;
        }

        public List<mattMedicalEmployees> ReturnMattMedicalEmployees()
        {
            List<mattMedicalEmployees> MattMedicalEmployees = new List<mattMedicalEmployees>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattMedicalEmployees", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattMedicalEmployees mme = new()
                        {
                            MedicalEmployeeID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Position_or_Experise = reader.GetString(3),
                            YearsExperience = reader.GetString(4),
                            TeamID = reader.GetInt32(5),
                        };

                        MattMedicalEmployees.Add(mme);
                    }
                }
            }

            return MattMedicalEmployees;
        }

        public List<mattPlayerStats> ReturnMattPlayerStats()
        {
            List<mattPlayerStats> MattPlayerStats = new List<mattPlayerStats>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattPlayerStats", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattPlayerStats mps = new()
                        {
                            PlayerStatsID = reader.GetInt32(0),
                            PointsPerGame = reader.GetString(1),
                            Assists = reader.GetString(2),
                            Rebounds = reader.GetString(3),
                            Steals = reader.GetString(4),
                            Blocks = reader.GetString(5),
                            PlayerID = reader.GetInt32(6),
                        };

                        MattPlayerStats.Add(mps);
                    }
                }
            }

            return MattPlayerStats;
        }

        public List<mattPlayers> ReturnMattPlayers()
        {
            List<mattPlayers> MattPlayers = new List<mattPlayers>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattPlayers", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattPlayers mp = new()
                        {
                            PlayerID = reader.GetInt32(0),
                            PlayerName = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Position = reader.IsDBNull(2) ? null : reader.GetString(2),
                            College = reader.IsDBNull(3) ? null : reader.GetString(3),
                            ContractLengthRem = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                            SalaryPerYear = reader.IsDBNull(5) ? (SqlMoney?)null : reader.GetSqlMoney(5),
                            RoleOnTeam = reader.IsDBNull(6) ? null : reader.GetString(6),
                            TeamID = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7),
                        };

                        MattPlayers.Add(mp);
                    }
                }
            }

            return MattPlayers;
        }

        public List<mattRecoveryPlan> ReturnMattRecoveryPlan()
        {
            List<mattRecoveryPlan> MattRecoveryPlan = new List<mattRecoveryPlan>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattRecoveryPlan", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattRecoveryPlan mrp = new()
                        {
                            RecoveryPlanID = reader.GetInt32(0),
                            StartDate = reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1),
                            EndDate = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                            RecoveryStatus = reader.IsDBNull(3) ? null : reader.GetString(3),
                            NextSteps = reader.IsDBNull(4) ? null : reader.GetString(4),
                            InjuryTypeID = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                        };

                        MattRecoveryPlan.Add(mrp);
                    }
                }
            }

            return MattRecoveryPlan;
        }

        public List<mattTeam> ReturnMattTeam()
        {
            List<mattTeam> MattTeam = new List<mattTeam>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM mattTeam", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mattTeam mt = new()
                        {
                            TeamID = reader.GetInt32(0),
                            TeamLocationCity = reader.GetString(1),
                            TeamLocationState = reader.GetString(2),
                            TeamName = reader.GetString(3),
                            IndustryID = reader.GetInt32(4),
                        };

                        MattTeam.Add(mt);
                    }
                }
            }

            return MattTeam;
        }

    }
}
