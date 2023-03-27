using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Overload
    {
        
    }

    public class Student
    {
        string name;
        int age;
        int rollno;
        int dept_id;
        Marks mark;
        public Student()
        {

        }

        public Student(string name,int age,int rollno,int dept_id,Marks mark)
        {
            this.name = name;
            this.age = age;
            this.rollno = rollno;
            this.dept_id = dept_id;
            this.mark = mark;
        }

        public void Display()
        {
            mark.Perce();
            Console.WriteLine(" Name - "+name+
                "\n Age - "+age+
                "\n Roll no. - "+rollno+
                "\n Dept Id - "+dept_id+
                "\n Percentage - "+mark.percentage);
        }
    }

    public class Marks
    {
        int total_marks;
        public float percentage;
        string grade;
        int no_sub;

        public Marks() { }

        public Marks(int total_marks,int no_sub)
        {
            this.total_marks = total_marks;
            this.no_sub = no_sub;
        }

        public void Perce()
        {
            percentage = total_marks / no_sub;
            //Console.WriteLine(percentage);

        }
    }
}
