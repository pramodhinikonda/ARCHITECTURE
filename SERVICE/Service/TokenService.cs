using Y_DAL;
using Y_DAL.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y_SERVICE
{
    public class TokenService
    {
        private TokenDA TokenAccess;

        public TokenService()
        {
            TokenAccess = new TokenDA();
        }

        public Token GenerateToken(Guid userID)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.UtcNow;
            DateTime expiredOn = DateTime.UtcNow.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new Token
            {
                ID = Guid.NewGuid(),
                UserID = userID,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            TokenAccess.InsertToken(tokendomain);

            return tokendomain;
        }

        public bool ValidateToken(string tokenId)
        {
            var token = TokenAccess.GetTokenByID(tokenId);
            if (token != null && !(DateTime.UtcNow > token.ExpiresOn))
            {
                token.ExpiresOn = token.ExpiresOn.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                TokenAccess.UpdateToken(token);
                return true;
            }
            else
            {
                if (token != null)
                    TokenAccess.DeleteTokenByToken(token.AuthToken);
            }
            return false;
        }

        public bool DeleteTokenByUser(string email)
        {
            return TokenAccess.DeleteTokenByUser(email);
        }
    }
}
