using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Commands
{
    public record CreateCourseCommand : IRequest<string>
    {
        public string Title { get; init; }
        public string Description { get; init; }
    }
 }
