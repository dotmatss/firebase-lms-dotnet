using Application.Courses.Commands;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Handlers
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand>
    {

        private readonly ICourseRepository _courseRepository;

        public DeleteCourseHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);
            if (course == null)
                throw new Exception("Course not found");

            await _courseRepository.DeleteAsync(request.CourseId);
        }
    }
}
