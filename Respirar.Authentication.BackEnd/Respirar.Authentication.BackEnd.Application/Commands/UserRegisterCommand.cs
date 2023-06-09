using MediatR;
using Respirar.Authentication.BackEnd.Application.DTOs;

namespace Respirar.Authentication.BackEnd.Application.Commands
{
    public class UserRegisterCommand : IRequest<ValueResult<UserRegisterResult>>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
