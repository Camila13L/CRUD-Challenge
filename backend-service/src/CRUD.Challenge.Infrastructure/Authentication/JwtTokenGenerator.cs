using System;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;

namespace CRUD.Challenge.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public async Task<string> GenerateToken(Guid userIdm, string firstName, string lastName)
        {
            //var claims = new[]
            //{
            ////    new Claim(JWTRegisteredClaimNames.Sub, firstName+ " " + lastName),
            ////    new Claim(JWTRegisteredClaimNames.),
            ////    new Claim()

            //};
            return null;

        }
    }
}

