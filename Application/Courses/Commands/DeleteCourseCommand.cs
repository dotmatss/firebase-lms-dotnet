using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Commands
{
    public record DeleteCourseCommand : IRequest
    {
        public string CourseId { get; init; }
    }
}
