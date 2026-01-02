using Application.Students.Commands;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _repo;
        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _repo = studentRepository;
        }
        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByIdAsync(request.StudentId)
                          ?? throw new Exception("Student not found");

            // update student details
            student.SetEmail(request.Email);
            student.SetName(request.FullName);

            await _repo.UpdateAsync(student);
        }
    }
}
