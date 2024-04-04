using DatabaseLab;
using MySqlConnector;

namespace DatabaseDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {


            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "password",
                Database = "StudentDB"
            };

            CourseManager courseManager = new CourseManager (builder.ConnectionString);


            // Read Existing Courses
            Console.WriteLine("Reading Courses \n");
            foreach (Course course in  courseManager.GetCourses())
            {
                Console.WriteLine($"{course.CourseId}. {course.Name}");
            }
            Console.WriteLine("\nFinished Reading Courses \n");

            // Add New Course
            Console.WriteLine("Adding new Course \n");
            Course newCourse = new Course (1006, "User Experience Design", 2);

            courseManager.AddCourse (newCourse);

            foreach (Course course in courseManager.GetCourses())
            {
                Console.WriteLine($"{course.CourseId}. {course.Name}");
            }
            Console.WriteLine("\nFinished Adding new Course \n");

            // Update Course
            Console.WriteLine("Updating new Course \n");
            newCourse.Name = "UX Design and Planning";
            newCourse.Credit = 3;

            courseManager.UpdateCourse(newCourse);

            foreach (Course course in courseManager.GetCourses())
            {
                Console.WriteLine($"{course.CourseId}. {course.Name}");
            }
            Console.WriteLine("\nFinished Updating new Course \n");

            // Delete Course
            Console.WriteLine("Deleting new Course \n");

            courseManager.DeleteCourse (newCourse);

            foreach (Course course in courseManager.GetCourses())
            {
                Console.WriteLine($"{course.CourseId}. {course.Name}");
            }

            Console.WriteLine("\nFinished Deleting new Course \n");
        }
    }
}