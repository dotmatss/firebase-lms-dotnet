using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enrollment
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string StudentId { get; private set; }
        public string CourseId { get; private set; }
        public Student Student { get; private set; }
        public Course Course { get; private set; }
        public DateTime EnrolledOn { get; private set; } = DateTime.UtcNow;

        public Enrollment(Student student, Course course)
        {
            Student = student ?? throw new ArgumentNullException(nameof(student));
            Course = course ?? throw new ArgumentNullException(nameof(course));
            StudentId = student.Id;
            CourseId = course.Id;
        }

    }
}
