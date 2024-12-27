using BookService.DTO.Response;
using BookService.Services.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BookService.Services.Concrete
{
    public class TokenGenerator: ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<LoginResponseDTO> CreateToken(int minute, string userName, List<string> roles)
        {
            LoginResponseDTO LoginResponseDTO = new();

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            LoginResponseDTO.Expiration=DateTime.UtcNow.AddMinutes(minute);

            var claims = new List<Claim>();

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.Add(new Claim(ClaimTypes.Name, userName));

            JwtSecurityToken securityToken = new
            (
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                signingCredentials: signingCredentials,
                notBefore: DateTime.UtcNow,
                expires: LoginResponseDTO.Expiration,
                claims: claims
            );

            return await Task.FromResult(new LoginResponseDTO
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = LoginResponseDTO.Expiration
            });
        }
    }
}
