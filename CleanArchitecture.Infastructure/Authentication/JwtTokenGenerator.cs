using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchitecture.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Infastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
  public string GenerateToken(Guid userId, string firstName, string lastName)
  {
    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes("super-secret-key")
      ),
      SecurityAlgorithms.HmacSha256
    );

    var claims = new[] 
    {
      new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
      new Claim(JwtRegisteredClaimNames.GivenName, firstName),
      new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var securityToken = new JwtSecurityToken(
      issuer: "CleanArchitecture",
      expires: DateTime.Now.AddDays(2),
      claims: claims, 
      signingCredentials: signingCredentials
    );

    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}