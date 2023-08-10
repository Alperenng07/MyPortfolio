using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Service.Token
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest request);
    }
}
