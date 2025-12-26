using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Commands
{
    public record UpdateCourseCommand : IRequest
    {
        public string CourseId { get; set; }
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
