using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EnrollmentDto
    {
        public string Id { get; set; }
        public StudentDto Student { get; set; }
        public CourseDto Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
