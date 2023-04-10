using Microsoft.Data.SqlClient;

namespace SqlProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=5CG9441HWP;Initial Catalog=Library;Integrated Security=True;Encrypt=False;");
            connection.Open();
            SqlCommand command = connection.CreateCommand();

            

        }
    }
}