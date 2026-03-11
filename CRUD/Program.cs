using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public char Gender { get; set; }

        public Student(string Id, string Name, byte Age, char Gender)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
        }
    }

    class Functions
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void ShowAllStudents()
        {
            Console.WriteLine("Student Id | Student Name | Student Age | Student Gender");
            foreach(Student student in students)
            {
                Console.WriteLine($"\n{student.Id} | {student.Name} | {student.Age} | {student.Gender}");
            }
        }

        public void UpdateStudent(string Id)
        {
            var student = students.Find(s => s.Id == Id);

            if(student == null)
            {
                Console.WriteLine("Student Id does not exist.");
                return;
            }

            Console.WriteLine($"\n{student.Id} | {student.Name} | {student.Age} | {student.Gender}");

            Console.Write("Enter new name: ");
            string NewName = Console.ReadLine();

            Console.Write("Enter new age: ");
            byte NewAge = Convert.ToByte(Console.ReadLine());

            student.Name = NewName;
            student.Age = NewAge;

            Console.WriteLine($"\n{student.Id} | {student.Name} | {student.Age} | {student.Gender}");
        }

        public void DeleteStudent(string Id)
        {
            var student = students.Find(s => s.Id == Id);

            if (student == null)
            {
                Console.WriteLine("Student Id does not exist.");
                return;
            }

            students.Remove(student);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Functions functions = new Functions();
            bool stop = false;

            do
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Choice: ");
                byte choice = Convert.ToByte(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter your id: ");
                        string Id = Console.ReadLine();

                        Console.Write("Enter your name: ");
                        string Name = Console.ReadLine();

                        Console.Write("Enter your age: ");
                        byte Age = Convert.ToByte(Console.ReadLine());

                        Console.Write("Enter your gender (M/F): ");
                        char Gender = Convert.ToChar(Console.ReadLine().ToUpper());

                        functions.AddStudent(new Student(Id, Name, Age, Gender));
                        break;

                    case 2:
                        functions.ShowAllStudents();
                        break;

                    case 3:
                        Console.Write("Enter student id: ");
                        string studentId = Console.ReadLine();

                        functions.UpdateStudent(studentId);
                        break;

                    case 4:
                        Console.Write("Enter student id: ");
                        string StudentId = Console.ReadLine();

                        functions.DeleteStudent(StudentId);
                        break;

                    case 5:
                        stop = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (!stop);
        }
    }
}
