using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Commands
{
    public class UpdateStudentCommand : IRequest
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
