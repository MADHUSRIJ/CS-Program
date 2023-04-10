using Microsoft.Data.SqlClient;

namespace SqlAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=5CG9441HWP;Initial Catalog=PracticeDatabase;Integrated Security=True;Encrypt=False;");
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();


        }

        public void InserEmployees(SqlCommand cmd)
        {
            Console.WriteLine("Enter Details:");
            Console.Write("Employee Id:");
            int empId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Employee Name:");
            string empName = Console.ReadLine();
            Console.Write("Job:");
            string job = Console.ReadLine();
            Console.Write("Manager Id:");
            int manager = Convert.ToInt32(Console.ReadLine());
            Console.Write("Hire Date:");
            DateTime hireDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Salary:");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Commission:");
            int commission = Convert.ToInt32(Console.ReadLine());
            Console.Write("Department Id:");
            int deptId = Convert.ToInt32(Console.ReadLine());

            cmd.CommandText = $"INSERT INTO EMPLOYEE VALUES ({empId}, '{empName}', '{job}', {manager}, '{hireDate}', {salary}, {commission}, {deptId});";

            try
            {
                cmd.ExecuteNonQuery();

                Console.WriteLine("\nData Entered into employee Table\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CountEmployees(SqlCommand cmd)
        {

        }
    }
}