using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

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
                            program.RemoveSports();
                            break;
                        case 7:
                            program.EditScoreBoard(cmd);
                            break;
                        case 8:
                            program.AddPlayer(cmd);
                            break;
                        case 9:
                            program.RemovePlayer();
                            break;
                        case 10:
                            program.RemoveTournament();
                            break;
                        case 11:
                            program.RegistrationIndividual();
                            break;
                        case 12:
                            program.RegistrationGroup();
                            break;
                        case 13:
                            program.Payment();
                            break;
                        default:
                            break;
                    }
                }
                while (choice < 14 && choice > 0);

                conn.Close();
            }

            public void AddCollege(SqlCommand cmd)
            {
                Console.Write("Enter College Id:");
                int collegeId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter College Name:");
                string collegeName = Console.ReadLine();

                cmd.CommandText = $"INSERT INTO COLLEGE VALUES({collegeId},'{collegeName}')";
                cmd.ExecuteNonQuery();

                Console.WriteLine("College Registered Successfully!");
            }
            public void RemoveCollege(SqlCommand cmd)
            {
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
            public void AddSports(SqlCommand cmd) 
            {
                Console.Write("Enter Sports Id:");
                int sportsId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Sports Name:");
                string sportsName = Console.ReadLine();

                cmd.CommandText = $"INSERT INTO SPORTS VALUES({sportsId},'{sportsName}')";
                cmd.ExecuteNonQuery();

                Console.WriteLine("Sports Registered Successfully!");
            }
            public void AddScoreBoard(SqlCommand cmd)
            {
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
            public void AddTournament(SqlCommand cmd) 
            {
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
            public void AddPlayer(SqlCommand cmd) 
            {
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
            public void RemovePlayer() 
            {
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
            public void RemoveTournament() 
            {
                using (SqlConnection connect = new SqlConnection("Data Source=5CG9441HWP;Initial Catalog=CollegeSportsManagementSystem;Encrypt=False;Integrated Security=True;"))
                {
                    connect.Open();
                    Console.WriteLine("\n Enter the Tournament Id to be deleted: ");
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
            public void RemoveSports() 
            {
                using (SqlConnection connect = new SqlConnection("Data Source=5CG9441HWP;Initial Catalog=CollegeSportsManagementSystem;Encrypt=False;Integrated Security=True;"))
                {
                    connect.Open();
                    Console.WriteLine("\n Enter the Sports Id to be deleted: ");
                    int sportsId = Convert.ToInt32(Console.ReadLine());

                    using (SqlCommand command = new SqlCommand("removeSports", connect))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add("@sportsId", System.Data.SqlDbType.Int).Value = sportsId;
                        command.ExecuteNonQuery();

                        Console.WriteLine("Sports Deleted Successfully!");
                    }
                    connect.Close();
                }
            }
            public void RegistrationIndividual() { }
            public void RegistrationGroup() { }
            public void Payment() { }
        }
    }
}