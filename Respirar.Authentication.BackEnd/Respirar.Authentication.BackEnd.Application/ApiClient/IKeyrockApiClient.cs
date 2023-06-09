using Respirar.Authentication.BackEnd.Application.Commands;
using Respirar.Authentication.BackEnd.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.ApiClient
{
    public interface IKeyrockApiClient
    {
        Task<ValueResult<LoginResult>> Login(LoginCommand command, CancellationToken cancellationToken);

        Task<ValueResult<UserRegisterResult>> UserRegister(UserRegisterCommand command, CancellationToken cancellationToken);

        Task<ValueResult<String>> CreateToken();

    }
}
