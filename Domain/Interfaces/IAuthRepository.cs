using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    internal interface IAuthRepository
    {
        Task<bool> RegisterUserAsync(string username, string password);
        Task<string> LoginUserAsync(string username, string password);
    }
}
