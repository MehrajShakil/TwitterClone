using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class JwtTokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private JsonWebTokenHandler _jwtHandler = new JsonWebTokenHandler();

        public JwtTokenService(
            JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public (string, DateTime) GetToken(UserDto user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),

                ///
            };

            var expiryTime = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryTimeInMinutes);

            var signedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var descriptor = new SecurityTokenDescriptor()
            {
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = expiryTime,
                SigningCredentials = new SigningCredentials(signedKey, SecurityAlgorithms.HmacSha256)
            };

            return (_jwtHandler.CreateToken(descriptor), expiryTime);
        }
    }
}
