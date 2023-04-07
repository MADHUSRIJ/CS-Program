using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

namespace College_Sports_Management_System
{
    public class College
    {
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        public class Program
        {
            static void Main(string[] args)
            {
                SqlConnection conn = new SqlConnection("Data Source=5CG9441HWP;Initial Catalog=CollegeSportsManagementSystem;Encrypt=False;Integrated Security=True;");
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                int choice = 0;
                do
                {
                    Console.WriteLine("Welcome Director! Choose What you want to Do \n" +
                        "1 - Add College\n" +
                        "2 - Remove College\n" +
                        "3 - Add sports\n" +
                        "4 - Add Scoreboard\n" +
                        "5 - Add Tournament\n" +
                        "6 - Remove Sports\n" +
                        "7 - Edit Scoreboard\n" +
                        "8 - Add Players\n" +
                        "9 - Remove players\n" +
                        "10 - Remove Tournament\n" +
                        "11 - Registration Individual\n" +
                        "12 - Registration Group\n" +
                        "13 - Payment\n" +
                        "14 - View ScoreBoard\n" +
                        "Enter your choice : ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Program program = new Program();
                    switch (choice)
                    {
                        case 1:
                            program.AddCollege(cmd);
                            break;
                        case 2:
                            program.RemoveCollege(cmd);
                            break;
                        case 3:
                            program.AddSports(cmd);
                            break;
                        case 4:
                            program.AddScoreBoard(cmd);
                            break;
                        case 5:
                            program.AddTournament(cmd);
                            break;
                        case 6:
                            program.RemoveSports(cmd);
                            break;
                        case 7:
                            program.EditScoreBoard(cmd);
                            break;
                        case 8:
                            program.AddPlayer(cmd);
                            break;
                        case 9:
                            program.RemovePlayer(cmd);
                            break;
                        case 10:
                            program.RemoveTournament(cmd);
                            break;
                        case 11:
                            program.RegistrationIndividual(cmd);
                            break;
                        case 12:
                            program.RegistrationGroup(cmd);
                            break;
                        case 13:
                            program.Payment();
                            break;
                        case 14:
                            program.ViewScoreBoard(cmd);
                            break;
                        default:
                            break;
                    }
                }
                while (choice < 15 && choice > 0);

                conn.Close();
            }

            //COLLEGE
            public void AddCollege(SqlCommand cmd)
            {
                DisplayCollege(cmd);
                //Get the college id and college name and add it in college table
                Console.Write("Enter College Id:");
                int collegeId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter College Name:");
                string collegeName = Console.ReadLine();

                cmd.CommandText = $"INSERT INTO COLLEGE VALUES({collegeId},'{collegeName}')";
                cmd.ExecuteNonQuery();

                Console.WriteLine("College Registered Successfully!");
            }
            public void DisplayCollege(SqlCommand cmd)
            {
                //Display College List
                Console.WriteLine("College List");

                cmd.CommandText = $"SELECT * FROM COLLEGE";
                SqlDataReader reader = cmd.ExecuteReader();

                List<College> colleges = new List<College>();

                while (reader.Read())
                {
                    College college = new College();
                    college.CollegeId = (int)reader["collegeId"];
                    college.CollegeName = (string)reader["collegeName"];
                    colleges.Add(college);
                }



                foreach (College collage in colleges)
                {
                    Console.WriteLine(collage.CollegeId + " " + collage.CollegeName);
                }

                Console.WriteLine();

                reader.Close();
            }
            public void RemoveCollege(SqlCommand cmd)
            {
                DisplayCollege(cmd);

                //Get college id - Delete college including tournament assigned and players in the college
                using (SqlConnection connect = new SqlConnection("Data Source=5CG9441HWP;Initial Catalog=CollegeSportsManagementSystem;Encrypt=False;Integrated Security=True;"))
                {
                    connect.Open();
                    Console.WriteLine("\n Enter the College Id to be deleted: ");
                    int collegeId = Convert.ToInt32(Console.ReadLine());

                    using (SqlCommand command = new SqlCommand("removeCollege", connect))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add("@collegeId", System.Data.SqlDbType.Int).Value = collegeId;
                        command.ExecuteNonQuery();

                        Console.WriteLine("College Deleted Successfully!");
                    }
                    connect.Close();
                }


            }

            //SPORT
            public void AddSports(SqlCommand cmd) 
            {
                DisplaySport(cmd);

                //Insert new sports
                Console.Write("Enter Sports Id:");
                int sportsId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Sports Name:");
                string sportsName = Console.ReadLine();
                Console.Write("Enter Type of Sport (Individual/ Team):");
                string type = Console.ReadLine();

                cmd.CommandText = $"INSERT INTO SPORTS VALUES({sportsId},'{sportsName}','{type}')";
                cmd.ExecuteNonQuery();

                Console.WriteLine("Sports Registered Successfully!");
            }
            public void DisplaySport(SqlCommand cmd)
            {
                //Display sport List
                Console.WriteLine("Sports List");

                cmd.CommandText = $"SELECT * FROM SPORTS";
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(reader["sportsId"] + " " + reader["sportsName"]);
                }

                Console.WriteLine();
                reader.Close();
            }
            public void RemoveSports(SqlCommand cmd)
            {
                DisplaySport(cmd);

                using (SqlConnection connect = new SqlConnection("Data Source=5CG9441HWP;Initial Catalog=CollegeSportsManagementSystem;Encrypt=False;Integrated Security=True;"))
                {
                    connect.Open();
                    Console.WriteLine("\nEnter the Sports Id to be deleted: ");
                    int sportsId = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        using (SqlCommand command = new SqlCommand("removeSports", connect))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.Parameters.Add("@sportsId", System.Data.SqlDbType.Int).Value = sportsId;
                            command.ExecuteNonQuery();

                            Console.WriteLine("Sports Deleted Successfully!");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error - "+ex.Message);
                    }
                    connect.Close();
                }
            }

            //TOURNAMENT
            public void AddTournament(SqlCommand cmd) 
            {
                DisplayTournament(cmd);

                //Add new tournament
                Console.Write("Enter Tournament Id:");
                int tournamentId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Tournament Name:");
                string tournamentName = Console.ReadLine();
                Console.Write("Enter College Id of College Conducting the Tournament:");
                int collegeId = Convert.ToInt32(Console.ReadLine());

                try
                {
                    cmd.CommandText = $"INSERT INTO TOURNAMENTS VALUES({tournamentId},'{tournamentName}',{collegeId})";
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Sports Registered Successfully!");
                }
                catch(SqlException error)
                {
                    Console.WriteLine("Data Error" + error.Message);
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error" + error.Message);
                }

                
            }
            public void DisplayTournament(SqlCommand cmd)
            {
                Console.WriteLine("Tournament List");

                cmd.CommandText = $"SELECT * FROM TOURNAMENTS";
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(reader["tournamentId"] + " " + reader["tournamentName"] + " " + reader["collegeId"]);
                }

                Console.WriteLine();
                reader.Close();
            }
            public void RemoveTournament(SqlCommand cmd)
            {
                DisplayTournament(cmd);

                using (SqlConnection connect = new SqlConnection("Data Source=5CG9441HWP;Initial Catalog=CollegeSportsManagementSystem;Encrypt=False;Integrated Security=True;"))
                {
                    connect.Open();
                    Console.WriteLine("\nEnter the Tournament Id to be deleted: ");
                    int tournamentId = Convert.ToInt32(Console.ReadLine());

                    using (SqlCommand command = new SqlCommand("removeTournament", connect))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add("@tournamentId", System.Data.SqlDbType.Int).Value = tournamentId;
                        command.ExecuteNonQuery();

                        Console.WriteLine("Tournament Deleted Successfully!");
                    }
                    connect.Close();
                }
            }

            //PLAYER
            public void AddPlayer(SqlCommand cmd) 
            {
                DisplayPlayerList(cmd);

                //Add new player
                Console.Write("Enter Player Id:");
                int playerId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Player Name:");
                string playerName = Console.ReadLine();
                Console.Write("Enter College Id of Player:");
                int collegeId = Convert.ToInt32(Console.ReadLine());

                try
                {
                    cmd.CommandText = $"INSERT INTO PLAYER VALUES({playerId},'{playerName}',{collegeId})";
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Sports Registered Successfully!");
                }
                catch (SqlException error)
                {
                    Console.WriteLine("Data Error" + error.Message);
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error" + error.Message);
                }
            }
            public void DisplayPlayerList(SqlCommand cmd)
            {
                Console.WriteLine("Player List");

                cmd.CommandText = $"SELECT * FROM PLAYERS";
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(reader["playerId"] + " " + reader["playerName"] + " " + reader["collegeId"]);
                }

                Console.WriteLine();
                reader.Close();
            }
            public void RemovePlayer(SqlCommand cmd) 
            {
                DisplayPlayerList(cmd);

                //Remove player from player list
                using (SqlConnection connect = new SqlConnection("Data Source=5CG9441HWP;Initial Catalog=CollegeSportsManagementSystem;Encrypt=False;Integrated Security=True;"))
                {
                    connect.Open();
                    Console.WriteLine("\n Enter the Player Id to be deleted: ");
                    int playerId = Convert.ToInt32(Console.ReadLine());

                    using (SqlCommand command = new SqlCommand("removePlayer", connect))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add("@playerId", System.Data.SqlDbType.Int).Value = playerId;
                        command.ExecuteNonQuery();

                        Console.WriteLine("Player Deleted Successfully!");
                    }
                    connect.Close();
                }
            }

            //SCOREBOARD
            public void EditScoreBoard(SqlCommand cmd) 
            {
                Console.Write("Enter Player Id:");
                int playerId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Tournament Id:");
                int tournamentId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Sports Id:");
                int sportsId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Score:");
                int score = Convert.ToInt32(Console.ReadLine());

                cmd.CommandText = $"SELECT * FROM SCOREBOARD WHERE playerId = {playerId} AND sportsId = {sportsId} AND tournamentId = {tournamentId}";
                int count = (int)cmd.ExecuteScalar();

                if(count > 0)
                {
                    cmd.CommandText = $"UPDATE SCOREBOARD SET score = {score} WHERE playerId = {playerId} AND sportsId = {sportsId} AND tournamentId = {tournamentId};";
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("ScoreBoard Updated Successfully!");
                }
                else
                {
                    AddScoreBoard(cmd);
                }

                
            }
            public void ViewScoreBoard(SqlCommand cmd)
            {
                Console.Write("Enter Tournament Id:");
                int tournamentId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Sports Id:");
                int sportsId = Convert.ToInt32(Console.ReadLine());

                cmd.CommandText = $"SELECT * FROM SCOREBOARD WHERE tournamentId = {tournamentId} AND sportsId = {sportsId} ORDER BY SCORE DESC";
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"ScoreBoard of Sport {sportsId} in the Tournament {tournamentId}\n");

                while (reader.Read()) 
                {
                    Console.WriteLine(reader["playerId"]+" "+reader["score"]);
                }
                reader.Close();
            }
            public void AddScoreBoard(SqlCommand cmd)
            {
                //Add new score board
                Console.Write("Enter Player Id:");
                int playerId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Tournament Id:");
                int tournamentId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Sports Id:");
                int sportsId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Score:");
                int score = Convert.ToInt32(Console.ReadLine());

                cmd.CommandText = $"INSERT INTO SCOREBOARD VALUES({playerId},{score},{tournamentId},{sportsId})";
                cmd.ExecuteNonQuery();

                Console.WriteLine("ScoreBoard Added Successfully!");
            }


            public void AddTeam(SqlCommand cmd)
            {
                Console.Write("Enter Team Id:");
                int playerId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Team Name:");
                string playerName = Console.ReadLine();

                DisplayPlayerList(cmd);
            }
            public void RegistrationIndividual(SqlCommand cmd) 
            {
                //Display Sports and Tournament
                DisplaySport(cmd);
                DisplayTournament(cmd);

                Console.Write("Enter Player Id:");
                int playerId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Tournament Id:");
                int tournamentId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Sports Id:");
                int sportsId = Convert.ToInt32(Console.ReadLine());
                int count = 0;
                int tournamentCount = 0;
                int sportsCount = 0;
                try
                {
                    cmd.CommandText = $"SELECT * FROM PLAYERS WHERE playerId = {playerId}";
                    count = (int)cmd.ExecuteScalar();

                    cmd.CommandText = $"SELECT * FROM TOURNAMENTS WHERE tournamentId = {tournamentId}";
                    tournamentCount = (int)cmd.ExecuteScalar();

                    cmd.CommandText = $"SELECT * FROM SPORTS WHERE sportsId = {sportsId}";
                    sportsCount = (int)cmd.ExecuteScalar();
                }
                catch(Exception error)
                {
                    Console.WriteLine("Error - "+error.Message);
                }

                if(tournamentCount == 0 || sportsCount == 0)
                {
                    Console.WriteLine("The tournament Id or sports Id is not present");
                }
                else if (count < 0)
                {

                    Console.WriteLine("The player Id is not present. If you like to add, Enter 1 or 0");
                    int playerEnter = Convert.ToInt32(Console.ReadLine());
                    if (playerEnter == 1)
                    {
                        AddPlayer(cmd);
                        RegistrationIndividual(cmd);

                    }
                    else
                    {

                    }
                }
                else
                {
                    cmd.CommandText = $"INSERT INTO REGISTEREDINDIVIDUALS VALUES({playerId},{tournamentId},{sportsId})";
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Registration Successfully!");
                }


            }

            public void RegisterTeam(SqlCommand cmd)
            {
                DisplaySport(cmd);
                DisplayTournament(cmd);

                Console.Write("Enter Team Id:");
                int teamId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Tournament Id:");
                int tournamentId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Sports Id:");
                int sportsId = Convert.ToInt32(Console.ReadLine());
                int count = 0;
                int tournamentCount = 0;
                int sportsCount = 0;
                try
                {
                    
                    cmd.CommandText = $"SELECT * FROM TOURNAMENTS WHERE tournamentId = {tournamentId}";
                    tournamentCount = (int)cmd.ExecuteScalar();

                    cmd.CommandText = $"SELECT * FROM SPORTS WHERE sportsId = {sportsId}";
                    sportsCount = (int)cmd.ExecuteScalar();
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error - " + error.Message);
                }

                if (tournamentCount == 0 || sportsCount == 0)
                {
                    Console.WriteLine("The tournament Id or sports Id is not present");
                 
                }
                else
                {
                    cmd.CommandText = $"INSERT INTO REGISTEREDTEAMS VALUES({teamId},{tournamentId},{sportsId})";
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Registration Successfully!");
                }
            }
            public void RegistrationGroup(SqlCommand cmd) 
            {
                Console.WriteLine("Team List");

                cmd.CommandText = $"SELECT * FROM TEAMS";
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(reader["teamId"] + " " + reader["teamName"]);
                }

                Console.WriteLine();
                reader.Close();

                Console.WriteLine("To Create new team, press 1 else Register existing team press 2 else 0");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeam(cmd);
                        break;
                    case 2:
                        RegisterTeam(cmd);
                        break;
                    default:
                        break;
                }
            }
            public void Payment() { }
        }
    }
}