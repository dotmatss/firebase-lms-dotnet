using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enrollments.Commands
{
    public record EnrollStudentCommand(string StudentId, string CourseId) : IRequest;
}
