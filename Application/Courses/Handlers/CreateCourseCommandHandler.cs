using Application.Courses.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Handlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, string>
    {
        private readonly ICourseRepository _repo;

        public CreateCourseCommandHandler(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(CreateCourseCommand request, CancellationToken ct)
        {
            var course = new Course(Guid.NewGuid().ToString(), request.Title, request.Description);
            await _repo.AddAsync(course);
            return course.Id;
        }
    }
}
