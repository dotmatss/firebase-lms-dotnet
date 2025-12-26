using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        private readonly List<Enrollment> _enrollments = new();
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

        public Student(string id, string name, string email)
        {
            Id = id;
            SetName(name);
            SetEmail(email);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            Name = name;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new ArgumentException("Invalid email address.");
            }
            Email = email;
        }

        public void EnrollInCourse(Course course)
        {
            if (_enrollments.Any(e => e.CourseId == course.Id))
            {
                throw new InvalidOperationException("Student is already enrolled in this course.");
            }

            var enrollment = new Enrollment(this, course);
            _enrollments.Add(enrollment);
        }
    }
}
