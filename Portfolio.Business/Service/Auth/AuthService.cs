using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Service.Auth
{
    public class AuthService : IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.UserName == "onur" && request.Password == "123456")
            {
                response.AccessTokenExpireDate = DateTime.UtcNow;
                response.AuthenticateResult = true;
                response.AuthToken = string.Empty;
            }

            return Task.FromResult(response);
        }
    }
}
