using IndividualDatabaseProject.Models;
using System.Threading.Tasks.Dataflow;

namespace IndividualDatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IndividualDbContext context = new IndividualDbContext();
            MainMenu(context);
        }
        static void MainMenu(IndividualDbContext context)
        {
            while (true)
            {
                int choice;
                Console.WriteLine("1. How many teachers in departments\n2. Show information on all students\n3. Show all active Courses");
                if (int.TryParse(Console.ReadLine(),out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GetDepartmentTeacher(context);
                            break;
                        case 2:
                            ShowStudentInfo(context);
                            break;
                        case 3:
                            ActiveCourses(context);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        static void GetDepartmentTeacher(IndividualDbContext context)
        {
            var teacherNumber = (from a in context.DbDepartmentConnections
                                 join c in context.DbDepartments on a.DepartmentId equals c.Id
                                 join e in context.DbEmployees on a.TeacherId equals e.Id
                                 where (e.EmploymentId == 3)
                                 select new {c.DepartmentName,e.EmploymentId} into x
                                 group x by new {x.DepartmentName} into g
                                 select new
                                 {
                                     Name=g.Key.DepartmentName,
                                     Count=g.Select(x=>x.EmploymentId).Count()
                                 }).ToList();

            Console.WriteLine("\nNumber of teachers in each department\n");
            foreach(var department in teacherNumber)
            {
                Console.WriteLine(department.Name+" "+department.Count);
            }
            Console.WriteLine("");
        }
        
        static void ShowStudentInfo(IndividualDbContext context)
        {
            var studentInfo = (from a in context.DbStudents
                               join c in context.DbClasses on a.ClassId equals c.Id
                               select new
                               {
                                   a.Fname,
                                   a.Lname,
                                   c.ClassName,
                                   a.Personnummer
                               }).ToList();
            Console.WriteLine("\nList of students\n");
            foreach(var student in studentInfo)
            {
                Console.WriteLine(student.Fname+" "+student.Lname+" Class:"+student.ClassName+" | Personnummer:"+student.Personnummer);
            }
            Console.WriteLine("");
        }
        static void ActiveCourses(IndividualDbContext context)
        {
            var CourseList = context.DbCourses
                .Where(x => x.CourseEnd == null).ToList();
            Console.WriteLine("\nList of courses\n");
            foreach(var course in CourseList)
            {
                Console.WriteLine(course.CourseName+" | Course start date:"+course.CourseStart);
            }
            Console.WriteLine("");
        }
    }
}