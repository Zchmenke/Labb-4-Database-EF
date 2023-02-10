using Labb4v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Labb4v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Runs method to start my program
            Run();
        }
        public static void Run()
        {
            // Simple Menue with switch that takes you to each method related to each interaction
             
            SchoolDbContextv7 dbCon = new SchoolDbContextv7();
            bool loopBool = true;
            while (loopBool)
            {
                Console.Clear();
                Console.WriteLine(
                        "\t     --- Chooose action ---\n" +
                        "\n\t[1] Show Teachers and departments" +
                        "\n\t[2] Show Student Information" +
                        "\n\t[3] Show All Active Courses" +
                        "\n\t[4] Show Student Grades" +
                        "\n\t[5] Update Student information" +
                        "\n\t[6] Close Data Base");
                if (!int.TryParse(Console.ReadLine(), out int userInput))
                {
                    Console.WriteLine("Wrong input, try again!");
                    Console.ReadLine();
                    continue;
                }

                switch (userInput)
                {

                    case 1:
                        PrintTeachers();
                        break;
                    case 2:
                        PrintStudent();
                        break;
                    case 3:
                        ActiveCourses();
                        break;
                    case 4:
                        PrintGrades();
                        break;
                    case 5:
                        UpdateStudent();
                        break;
                    case 6:
                        loopBool = false;
                        break;                 
                    default:
                        Console.WriteLine("Wrong input,try again!");
                        continue;
                }

            }
        }
        // Simple method to print all teachers from respective department with foreachloop, decididing department withe " where " functions
        public static void PrintTeachers()
        {
            SchoolDbContextv7 dbCon = new SchoolDbContextv7();
            var personelList = dbCon.Personels.ToList();
            Console.Clear();
            Console.WriteLine("\t--Pre school Teachers--");
            foreach (var Emplooyee in personelList
                .Where(Employee => Employee.DepId == 1)
                .Where(Employee => Employee.EmployeeRole == 2))

            {
                Console.WriteLine($"\t{Emplooyee.FirstName} {Emplooyee.LastName}");
            }

            Console.WriteLine("");
            Console.WriteLine("\t--Middle School Teachers--");
            foreach (var Employee in personelList
                .Where(Employee => Employee.DepId == 2)
                .Where(Employee => Employee.EmployeeRole == 2))

            {
                Console.WriteLine($"\t{Employee.FirstName} {Employee.LastName}");
            }
            Console.WriteLine("");
            Console.WriteLine("\t--High School Teachers--");
            foreach (var Employee in personelList
                .Where(Employee => Employee.DepId == 3)
                .Where(Employee => Employee.EmployeeRole == 2))

            {
                Console.WriteLine($"\t{Employee.FirstName} {Employee.LastName}");
            }
            Console.WriteLine("");
            Console.WriteLine("\t--Senior Teachers--");
            foreach (var Employee in personelList
                .Where(Employee => Employee.DepId == 4)
                .Where(Employee => Employee.EmployeeRole == 2))

            {
                Console.WriteLine($"\t{Employee.FirstName} {Employee.LastName}");
            }
            Console.ReadLine();
        }
        //Prints students and relevant information.
        public static void PrintStudent()
        {
            SchoolDbContextv7 dbCon = new SchoolDbContextv7();
            var studentList = dbCon.Students.ToList();


            foreach (var student in studentList)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName}" +
                    $"\n\tStudent identification number :{student.StudentId}" +
                    $"\n\tSocial Secutiry Number:{student.PersonalNumber}" +
                    $"\n\t________________________________________________" +
                    $"\n");
            }
            Console.ReadLine();
        }
        // shows active courses, where if a bool is true then its active.
        public static void ActiveCourses()
        {
            Console.Clear();
            Console.WriteLine("\t--- Active Courses ---");
            SchoolDbContextv7 dbCon = new SchoolDbContextv7();
            foreach (var course in dbCon.Courses.Where(Courses => Courses.IsActive == true))
            {
                Console.WriteLine($"\t{course.Subject}");
            }
            Console.WriteLine("");
            Console.WriteLine("\t--- Courses That Are Not Active ---");
            foreach (var course in dbCon.Courses.Where(Courses => Courses.IsActive == false))
            {
                Console.WriteLine($"\t{course.Subject}");
            }

            Console.ReadLine();
        }
        // lets you choose a specific students and print out their grades. Using a list of studens that also includes their grades.
        public static void PrintGrades()
        {


            SchoolDbContextv7 dbCon = new SchoolDbContextv7();
            var studentList = dbCon.Students.Include("Grades").ToList();

            Console.WriteLine("\t--- Choose Student by Student identification ---");
            foreach (var student in studentList)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName}" +
                    $"\n\tIdentification number : {student.StudentId}\n" +
                    $"------------------------------------------------------------");
            }
            if (!int.TryParse(Console.ReadLine(), out int chooseStudent))
            {
                Console.WriteLine("\tWrong input, try again!");
                Console.ReadLine();
            }
            Console.WriteLine($"\tSelected students grades :");

            foreach (var student in studentList)
            {
                if (student.StudentId == chooseStudent)
                {
                    foreach (var grade in student.Grades)
                    {
                        Console.WriteLine($"\t{grade.GradeSub} : {grade.Grade1}");
                    }
                }
            }
            Console.ReadLine();
        }
        // a method that lets you update a students information and save it to the table. 
        public static void UpdateStudent()
        {
            SchoolDbContextv7 dbCon = new SchoolDbContextv7();
           
            Console.WriteLine("\t--- Choose Student by Student identification ---");
            foreach (var student in dbCon.Students)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName} {student.StudentId}");
            }
            if (!int.TryParse(Console.ReadLine(), out int StudentChoose))
            {
                Console.WriteLine("\tWrong input, try again!");
                Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("\tupdate students first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("\tupdate students Last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("\tupdate students social security number:");
            string socialSec  = Console.ReadLine();

            Console.WriteLine("\tupdate students class ID:");
            int ClassId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            foreach (var student in dbCon.Students.
                Where(s=>s.StudentId == StudentChoose))
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.PersonalNumber = socialSec;
                student.ClassIdstudent = ClassId;
            }

            foreach (var student in dbCon.Students)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName}" +
                     $"\n\tStudent identification number :{student.StudentId}" +
                     $"\n\tSocial Secutiry Number:{student.PersonalNumber}'" +
                     $"\n\t________________________________________________" +
                     $"\n");
            }
            Console.ReadLine();
            
           dbCon.SaveChanges();


          
            


        }
      
    }
}


