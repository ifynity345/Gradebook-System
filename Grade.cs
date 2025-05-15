using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook_System
{
    public class Grade
    {
        public required string CourseName { get; set; }
        public double Score { get; set; } // Assume 0-100

        public double GPAValue()
        {
            if (Score >= 90) return 4.0;
            else if (Score >= 80) return 3.0;
            else if (Score >= 70) return 2.0;
            else if (Score >= 60) return 1.0;
            else return 0.0;
        }
    }
}
