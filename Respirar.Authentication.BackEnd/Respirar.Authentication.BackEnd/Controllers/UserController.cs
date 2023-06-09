using MediatR;
using Microsoft.AspNetCore.Mvc;
using Respirar.Authentication.BackEnd.Application.Commands;
using Respirar.Authentication.BackEnd.Application.DTOs;

namespace Respirar.Authentication.BackEnd.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult<ValueResult<LoginResult>>> Login([FromBody] LoginCommand loginCommand)
        {
            var result = await mediator.Send(loginCommand);

            return result;
        }
        [HttpPost]
        [Route("/userregister")]
        public async Task<ActionResult<ValueResult<UserRegisterResult>>> UserRegister([FromBody] UserRegisterCommand userRegisterCommand)
        {
            var result = await mediator.Send(userRegisterCommand);

            return result;
        }
    }
}
