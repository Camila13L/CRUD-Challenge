using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace CRUD.Challenge.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public async Task<string> GenerateToken(Guid userId, string firstName, string lastName)
    {
        SigningCredentials singingCredentials = new SigningCredentials
            (
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key")),
                SecurityAlgorithms.HmacSha256
            );

        Claim[] claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName.ToString()),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        JwtSecurityToken secutyToken = new JwtSecurityToken
            (
            issuer: "CRUDChallenge",
            expires:DateTime.Now.AddDays(1),
            claims: claims,
            signingCredentials: singingCredentials
            );


        return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(secutyToken));

    }
    

}
