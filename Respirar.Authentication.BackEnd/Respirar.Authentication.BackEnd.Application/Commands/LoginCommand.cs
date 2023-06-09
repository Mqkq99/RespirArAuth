using MediatR;
using Respirar.Authentication.BackEnd.Application.DTOs;

namespace Respirar.Authentication.BackEnd.Application.Commands
{
    public class LoginCommand : IRequest<ValueResult<LoginResult>>
    {
        public string name { get; set; }
        public string password { get; set; }
        public string grant_type => "password";
    }
}
