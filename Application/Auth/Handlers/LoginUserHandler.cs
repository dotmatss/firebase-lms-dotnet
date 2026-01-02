using Application.Auth.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        public LoginUserHandler() {

        }

        Task<string> IRequestHandler<LoginUserCommand, string>.Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
