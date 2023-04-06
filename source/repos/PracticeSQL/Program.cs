using Microsoft.Data.SqlClient;

namespace PracticeSQL
{
    public class MyProjectData
    {
        public int projectId { get; set; }
        public string position { get; set; }
        public string duration { get; set; }
    }

    public class MyEmployeeData
    {
        public int empId { get; set; }
        public string empName { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Data Source=5CG9441HWP;Integrated Security=True;Encrypt=False;Initial Catalog=PracticeDatabase;");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlDataReader reader;


            //Get details from projectDetails table
            cmd.CommandText = "SELECT * FROM employeeDetails";

            reader = cmd.ExecuteReader();
            List<MyEmployeeData> dataList = new List<MyEmployeeData>();

            while (reader.Read())
            {
                MyEmployeeData data = new MyEmployeeData();
                data.empId = (int)reader["empId"];
                data.empName = (string)reader["empName"];

                dataList.Add(data);
                //Console.WriteLine(reader.GetInt32(0)+" "+ reader.GetString(1) + " " + reader.GetString(2));
            }

            foreach (MyEmployeeData data in dataList)
            {
                Console.WriteLine(data.empId + " " + data.empName);
            }

            reader.Close();

            /*
            //Insert Value into projectDetails table and Display
            Console.WriteLine("Enter the Project Details");
            Console.Write("Project Id : ");
            int projectId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Position : ");
            string position = Console.ReadLine();
            Console.Write("Duration : ");
            string duration = Console.ReadLine();


            cmd.CommandText = $"INSERT INTO projectDetails VALUES ({projectId},'{position}','{duration}') ";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT * FROM projectDetails";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
            }

            reader.Close();

            //Get specific data from projectDetails table using projectId and Display
            Console.Write("Enter Project Id : ");
            int projectId = Convert.ToInt32(Console.ReadLine());

            cmd.CommandText = $"SELECT * FROM projectDetails WHERE projectId = {projectId}";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
            }

            reader.Close();

            //Delete specific data from projectDetails using projectID
            Console.Write("Enter Project Id : ");
            int projectId = Convert.ToInt32(Console.ReadLine());

            try
            {
                cmd.CommandText = $"SELECT * FROM projectDetails WHERE projectId = {projectId}";
                int count = (int)cmd.ExecuteScalar();

                cmd.CommandText = $"DELETE FROM projectDetails WHERE projectId = {projectId}";
                cmd.ExecuteNonQuery();

                Console.WriteLine($"Deleted data with ProjectId - {projectId}");
            }
            catch (SqlException error)
            {
                Console.WriteLine("SQL Error - " + error.Message);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error - " + error.Message);

            }

            //Update specific data from projectDetails using projectID
            Console.Write("Enter Project Id : ");
            int projectId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Updated Duration : ");
            string duration = Console.ReadLine();

            try
            {
                cmd.CommandText = $"SELECT * FROM projectDetails WHERE projectId = {projectId}";
                int count = (int)cmd.ExecuteScalar();

                cmd.CommandText = $"UPDATE projectDetails SET duration = '{duration}' WHERE projectId = {projectId}";
                cmd.ExecuteNonQuery();

                Console.WriteLine($"Updated duration with ProjectId - {projectId}");
            }
            catch (SqlException error)
            {
                Console.WriteLine("SQL Error - " + error.Message);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error - " + error.Message);

            }
            */

            conn.Close();

            //Using stored Procedures
            using (SqlConnection connect = new SqlConnection("Data Source=5CG9441HWP;Integrated Security=True;Encrypt=False;Initial Catalog=PracticeDatabase;"))
            {
                connect.Open();
                Console.Write("Enter Project Id : ");
                int projectId = Convert.ToInt32(Console.ReadLine());

                using (SqlCommand command = new SqlCommand("FetchEmployeeBasedOnProjectId", connect))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = projectId;
                    //command.ExecuteNonQuery();

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetValue(0));
                    }
                }
                connect.Close();
            }


        }
    }
}