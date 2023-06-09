using MediatR;
using Respirar.Authentication.BackEnd.Application.ApiClient;
using Respirar.Authentication.BackEnd.Application.Commands;
using Respirar.Authentication.BackEnd.Application.DTOs;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ValueResult<LoginResult>>
    {
        private readonly IKeyrockApiClient _keyrockApiClient;

        public LoginCommandHandler(IKeyrockApiClient keyrockApiClient)
        {
            _keyrockApiClient = keyrockApiClient ?? throw new ArgumentNullException(nameof(keyrockApiClient)); ;
        }
        public async Task<ValueResult<LoginResult>> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            return await _keyrockApiClient.Login(command, cancellationToken);
        }
    }
}
