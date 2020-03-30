using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.Admin.Interfaces;
using Factorys.AccountFactorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Admin;
using Models.Admin.Json.Outputs;
using Models.Admin.Settings;

namespace BLL.AccountsBLL
{
    public class TokenGeradorBLL : ITokenGeradorBLL
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        private readonly JWTAppSettings _jwtAppSettings;        

        public TokenGeradorBLL(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IOptions<JWTAppSettings> jwtAppSettings                                                   
                            )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;            
            this._jwtAppSettings = jwtAppSettings.Value;            
        }

       /// <summary>
       /// Gera o Token do usuário com base no Email
       /// </summary>
       /// <param name="email"></param>
       /// <param name="claimsPersonalizadas"></param>
       /// <returns></returns>
        public async Task<UserTokenResult> GetTokenByEmail(string email,IList<Claim> claimsPersonalizadas=null)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var identityClaims = new ClaimsIdentity();

            //recupera as Claims do usuário 
            identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));

            //Claims personalizadas 
            if (claimsPersonalizadas != null)
            {
                identityClaims.AddClaims(claimsPersonalizadas);
            }
            
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtAppSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,                
                Issuer = _jwtAppSettings.Emissor,
                Audience = _jwtAppSettings.ValidoEm,                
                Expires = DateTime.UtcNow.AddHours(_jwtAppSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var claims = UserClaimFactory.TransformInClaimByList(identityClaims.Claims as List<Claim>,true);
           

            UserToken token = new UserToken()
            {
                Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
                Expiration = tokenDescriptor.Expires,
                Audience = _jwtAppSettings.ValidoEm,
                Issuer = _jwtAppSettings.Emissor
            };

            UserTokenResult result = new UserTokenResult()
            {
                Token = token,
                UserClaims = claims
            };
            
            return result;
        }

       
    }
}
