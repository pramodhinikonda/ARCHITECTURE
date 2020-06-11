using Y_HELPERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_DAL.POCO;
using Dapper;

namespace Y_DAL
{
    public class TokenDA
    {
        private DBHelper db;

        public TokenDA()
        {
            db = DBHelper.GetInstance();
        }

        public void InsertToken(Token accessToken)
        {
            string query = string.Format("INSERT INTO {0} VALUES(@ID,@UserID,@AuthToken,@IssuedOn,@ExpiresOn)", SQLTables.Tokens);
            db.Connection.Execute(query, new { accessToken.ID, accessToken.UserID, accessToken.AuthToken, accessToken.IssuedOn, accessToken.ExpiresOn });
        }

        public Token GetTokenByID(string tokenID)
        {
            var query = string.Format("SELECT [ID],[UserID],[AuthToken],[IssuedOn],[ExpiresOn] FROM {0} WHERE [AuthToken] = @ID", SQLTables.Tokens);
            return db.Connection.Query<Token>(query, new { ID = tokenID }).FirstOrDefault();
        }

        public void UpdateToken(Token token)
        {
            string query = string.Format("UPDATE {0} SET ExpiresOn = @ExpiresOn WHERE ID= @ID", SQLTables.Tokens);
            db.Connection.Execute(query, new { token.ExpiresOn, token.ID });
        }

        public bool DeleteTokenByToken(string AuthToken)
        {
            string query = string.Format("DELETE FROM {0} WHERE AuthToken= @AuthToken", SQLTables.Tokens);
            var result = db.Connection.Execute(query, new { AuthToken });

            return result > 0;
        }

        public bool DeleteTokenByUser(string email)
        {
            string query = string.Format("DELETE TK FROM {0} TK INNER JOIN {1} USR ON USR.ID = TK.UserID WHERE USR.Email= @email", SQLTables.Tokens, SQLTables.User);
            var result = db.Connection.Execute(query, new { email });

            return result > 0;
        }
    }
}
