using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLab
{
    public class CourseManager
    {
        private string _connectionString;
        public CourseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Adding CRUD to the program

        // Create
        public void AddCourse (Course course)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "INSERT INTO courses (courseID ,name, credit) VALUES (@CourseId, @Name, @Credit)";

                using (var command = new MySqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@CourseId", course.CourseId);
                    command.Parameters.AddWithValue("@Name", course.Name);
                    command.Parameters.AddWithValue("@Credit", course.Credit);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Read
        public List<Course> GetCourses() 
        {
            List<Course> courseList = new List<Course>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM courses";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int courseId = reader.GetInt32("courseId");
                            string name = reader.GetString("name");
                            int credit = reader.GetInt32("credit");

                            Course newCourse = new Course(courseId, name, credit);

                            courseList.Add(newCourse);
                        }
                    }
                }
            }

            return courseList;
        }

        // Update
        public void UpdateCourse (Course course)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE courses SET name = @Name, credit = @Credit WHERE courseId = @CourseId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", course.CourseId);
                    command.Parameters.AddWithValue("@Name", course.Name);
                    command.Parameters.AddWithValue("@Credit", course.Credit);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete
        public void DeleteCourse (Course course)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM courses WHERE courseId = @CourseId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", course.CourseId);
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
