namespace Testing
{
    public class Program
    {
        public string grade = "";
        static void Main(string[] args)
        {
            Program pgm = new Program();
            pgm.getMarks();
        }

        public void getMarks()
        {
            int subjectsCount = Convert.ToInt32(Console.ReadLine());
            List<int> marks = new List<int>();
            for (int i = 0; i < subjectsCount; i++)
            {
                marks.Add(Convert.ToInt32(Console.ReadLine()));
            }
            calcCGPA(marks, subjectsCount);

        }

        public void calcCGPA(List<int> marks, int subjectsCount)
        {
            float total = marks.Sum();
            float avg = total / subjectsCount;
            Console.WriteLine("Average " + avg);
            float cgpa = avg / 10.0f;
            AssignGrade(cgpa);
        }
        enum grades
        {
            O, A, B, C, D
        }
        public void AssignGrade(float cgpa)
        {

            if (cgpa > 9f)
            {
                grade = grades.O.ToString();
            }
            else if (cgpa > 8f)
            {
                grade = grades.A.ToString();
            }
            else if (cgpa > 7f)
            {
                grade = grades.B.ToString();
            }
            else if (cgpa > 6f)
            {
                grade = grades.C.ToString();
            }

            Console.WriteLine("CGPA " + cgpa);
            Console.WriteLine("Grade " + grade);
        }
    }
}