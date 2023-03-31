using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day2
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Dept { get; set; }
        public int Score { get; set; }

    }
    class Students
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }

        public Students(string Name, string department, int Age, int Id)
        {
            Name = Name; Department = department; Age = Age; Id = Id;
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Department} {Id} ";
        }


    }

    internal class LambdaExp
    {
        // delegate int add(int a, int b);

        delegate void Greet(string msg);
        public static void Exp()
        {


            //sum2(num1,num2)=> num1 + num2;
            Greet M = (str) => Console.WriteLine(str);
            var sum = (int num1, int num2) => num1 + num2;
            var sub = (int num1, int num2) => num1 - num2;
            var mul = (int num1, int num2) => num1 * num2;
            Console.WriteLine(mul(2, 30));
            mul += sum;
            foreach (Delegate a in mul.GetInvocationList())
            {
                Console.WriteLine(a.DynamicInvoke(2, 3));
            }
            Console.WriteLine(sum(20, 30));
            Console.WriteLine(sub(34, 24));
            M.Invoke("Hi");
        }

        public static void List()
        {
            List<int> L1 = new List<int>() { 1, 2, 3, 10, 4, 5, 6, 7, 8, 15 };
            List<int> DivisibleBy5 = L1.FindAll(n => n % 5 == 0);
            List<string> S1 = new List<string>() { "abc", "dfg", "asd", "qwe" };

            List<string> ContainsA = S1.OrderBy(s => s).ToList();

            foreach (string s in ContainsA)
            {
                Console.WriteLine(s);
            }
        }

        public static void Dict()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(5, "A");
            dict.Add(1, "B");
            dict.Add(4, "C");
            dict.Add(3, "SDD");
            dict.Add(7, "DED");
            dict.Add(28, "ZZ");
            foreach (var keyValue in dict.OrderByDescending(x => x.Value).ToList())
            {
                Console.WriteLine(keyValue);
            }
        }

        public static void SortedList()
        {
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student() { Id = 1, Name = "Yuvateja", Age = 22, Dept = "CSE", Score = 85 });
            studentList.Add(new Student() { Id = 2, Name = "Harish", Age = 19, Dept = "ECE", Score = 90 });
            studentList.Add(new Student() { Id = 3, Name = "Siva", Age = 17, Dept = "CSE", Score = 85 });
            studentList.Add(new Student() { Id = 4, Name = "Vinay", Age = 21, Dept = "EEE", Score = 95 });

            foreach (var student in studentList)
            {
                Console.WriteLine($"{student.Id} Name: {student.Name}, Dept:{student.Dept}, Score:{student.Score}");
            }
            List<Student> newStudList = studentList.OrderBy(stud => stud.Age >= 20).ToList();
            Console.WriteLine();
            foreach (var student in newStudList)
            {
                Console.WriteLine($"{student.Id} Name: {student.Name}, Age:{student.Age}, Dept:{student.Dept}, Score:{student.Score}");
            }
        }

        public static void CustomDataTypes()
        {
            List<Students> studentsList = new(){new Students("hello","CSE",24,101),
                new Students("helloOne", "IT", 22, 102),
                new Students("helloTwo", "EEE", 23, 103),
             new Students("helloThree", "ECE", 27, 105),
                new Students("helloFour", "EEE", 23, 107),
             new Students("helloFive", "CSE", 22, 109),
                new Students("helloSix", "CIVIL", 23, 1022),
             new Students("helloSeven", "ECE", 21, 1024),
                new Students("helloEight", "EEE", 25, 1032)};

            studentsList.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));

            studentsList.ForEach(student => student.Id -= 10);

            foreach (Students student in studentsList.FindAll(student => student.Department.Equals("ECE") && student.Age < 25))
            {
                Console.WriteLine(student);
            }

            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "yaswanth", Id = 8, Dept = "automobile", Age = 20 });
            students.Add(new Student() { Name = "bhupesh", Id = 7, Dept = "cse", Age = -18 });
            students.Add(new Student() { Name = "varun", Id = 9, Dept = "cse", Age = 23 });
            students.Add(new Student() { Name = "gokul", Id = 10, Dept = "cse", Age = -21 });
            students.Add(new Student() { Name = "gokul", Id = 10, Dept = "cse", Age = 9 });
            students.Add(new Student() { Name = "gokul", Id = 10, Dept = "cse", Age = 23 });

            students.ForEach(student => student.Id += 1);
            students.Sort((s1, s2) => s1.Age - s2.Age);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} {student.Age}");
            }

            Func<int, int, int> Fn = (a, b) => a + b;
            Console.WriteLine(Fn(5, 5));

            // Lambda testObj = new();
            //var worker = (int number) =>  number % 2 == 0;
            //int count = testObj.Count(worker);
            //Console.WriteLine(count);

           

            
        }
        int[] numbers = { 1, 2, 3, 4, 5, 6 };
        public int Count(Func<int, bool> callback)
        {
            return this.numbers.Count(callback);
        }

    }
}
