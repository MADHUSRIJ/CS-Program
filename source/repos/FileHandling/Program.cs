using System.Text;

namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Handling");
            FileStream file = new FileStream("C:\\Users\\Hp\\Desktop\\Notes\\Files\\file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            /*string strText = "This is a String that needs to be convert in stream";
            byte[] byteArray = Encoding.UTF8.GetBytes(strText);
            file.Write(byteArray);
            file.Close();
            var path = "C:\\Users\\Hp\\Desktop\\Notes\\Files\\file1.txt";
            File.AppendAllText(path, "\nThis is Madhu");*/

            /*StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("File is created");
            writer.Close();
            file.Close();*/

            /*StreamReader streamReader = new StreamReader(file);
            string content = streamReader.ReadToEnd();
            Console.WriteLine(content);
            streamReader.Close();
            file.Close();*/

            using(TextWriter writer = File.CreateText("C:\\Users\\Hp\\Desktop\\Notes\\Files\\file2.txt"))
            {
                writer.WriteLine("File 2 created");
            }



        }
    }
}