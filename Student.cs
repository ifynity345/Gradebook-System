using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook_System
{
    public class Student
    {
        public required string Name { get; set; }
        public List<Grade> Grades { get; set; } = new();
        public double CalculateGPA()
        {
            if (Grades.Count == 0) return 0.0;
            return Grades.Average(g => g.GPAValue());
        }

        public override string ToString()
        {
            return $"{Name} - GPA: {CalculateGPA():0.00}";
        }
    }
}
