using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtTokenAuthentication;

namespace AuthService;

public class JwtTokenService
{
    private readonly List<User> _users = new()
    {
        new("admin", "aDm1n", "Administrator", new[] { "product.read" }),
        new("user01", "u$3r01", "User", new[] { "product.read" })
    };

    public AuthToken? GenerateAuthToken(LoginModel loginModel)
    {
        var user = _users.FirstOrDefault(u => u.Username == loginModel.UserName && u.Password == loginModel.Password);

        if (user is null)
        {
            return null;
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var expirationTimeStamp = DateTime.Now.AddMinutes(5);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, user.Username),
            new Claim("role", user.Role),
            new Claim("scope", string.Join(" ", user.Scopes))
        };

        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:5002",
            claims: claims,
            expires: expirationTimeStamp,
            signingCredentials: signingCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new AuthToken(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
    }
}