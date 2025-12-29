using Application.Students.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly IStudentRepository _repo;

        public CreateStudentCommandHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(Guid.NewGuid().ToString(), request.FullName, request.Email);
            await _repo.AddAsync(student);
        }
    }
}
