using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Auth.Commands
{
    public record RegisterUserCommand(
        string Email,
        string Password,
        string PasswordConfirmation,
        string FullName
    ) : IRequest<string>;

}
