using Application.Enrollments.Commands;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enrollments.Handlers
{
    public class EnrollStudentHandler : IRequestHandler<EnrollStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollStudentHandler(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.StudentId)
                          ?? throw new Exception("Student not found");
            var course = await _courseRepository.GetByIdAsync(request.CourseId)
                          ?? throw new Exception("Course not found");

            student.EnrollInCourse(course);

            await _enrollmentRepository.AddAsync(student.Enrollments.Last());
        }
    }
}
