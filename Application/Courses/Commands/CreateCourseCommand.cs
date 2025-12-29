using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Commands
{
    public record CreateCourseCommand(
        string Title,
        string Description
    ) : IRequest<string>;
 }
