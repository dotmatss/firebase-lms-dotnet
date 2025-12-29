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
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _repo;

        public DeleteStudentHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByIdAsync(request.StudentId) ?? throw new Exception("Student not found");

            await _repo.DeleteAsync(request.StudentId);
        }
    }
}
