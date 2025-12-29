using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Students.Commands
{
    public class CreateStudentCommand : IRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
