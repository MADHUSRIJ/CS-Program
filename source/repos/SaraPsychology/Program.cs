namespace SaraPsychology
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program sp = new Program();
        }

        public void calendar_man()
        {
            Console.WriteLine("Give DOB in dd/mm/yyyy");
            String dob = Console.ReadLine();
            int dd = Convert.ToInt32(dob.Substring(0, 2));
            int mm = Convert.ToInt32(dob.Substring(3, 5));
            int yy = Convert.ToInt32(dob.Substring(6, dob.Length));
            var today = DateTime.Now;
            var date = new DateTime(yy, mm, dd);
            var thisdate = new DateTime(DateTime.Now.Year, mm, dd);

            var diffOfDates = today - thisdate;
            var age = DateTime.Now.Year - yy;
            Console.WriteLine("Difference "+ diffOfDates);
            Console.WriteLine("Age " + age);


        }
    }
}