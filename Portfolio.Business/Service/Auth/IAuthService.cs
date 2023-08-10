using DTOs;

namespace Portfolio.Business.Service.Auth
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
    }
}
