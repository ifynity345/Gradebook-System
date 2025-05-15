using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook_System
{
    public class GradebookApp
    {
        private List<Student> students = new();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- Gradebook System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade");
                Console.WriteLine("3. View All Students");
                Console.WriteLine("4. View Top Students");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": AddStudent(); break;
                    case "2": AddGrade(); break;
                    case "3": DisplayAllStudents(); break;
                    case "4": DisplayTopStudents(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        private void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            students.Add(new Student { Name = name });
            Console.WriteLine("Student added.");
        }

        private void AddGrade()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter course name: ");
            string course = Console.ReadLine();
            Console.Write("Enter score (0-100): ");
            if (double.TryParse(Console.ReadLine(), out double score))
            {
                student.Grades.Add(new Grade { CourseName = course, Score = score });
                Console.WriteLine("Grade added.");
            }
            else
            {
                Console.WriteLine("Invalid score.");
            }
        }

        private void DisplayAllStudents()
        {
            Console.WriteLine("\nAll Students:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        private void DisplayTopStudents()
        {
            Console.Write("Enter GPA threshold: ");
            if (double.TryParse(Console.ReadLine(), out double threshold))
            {
                var topStudents = students.Where(s => s.CalculateGPA() >= threshold);
                Console.WriteLine($"\nStudents with GPA >= {threshold}:");
                foreach (var student in topStudents)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("Invalid GPA.");
            }
        }
    }
}
