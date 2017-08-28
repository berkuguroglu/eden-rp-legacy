using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace eden_rp.EdenCore
{
    sealed class Crypto
    {
        private string name, passwd, salt;

        public Crypto(string name, string passwd)
        {
            this.name = name;
            salt = BCrypt.GenerateSalt();
            this.passwd = BCrypt.HashPassword(passwd, salt);
        }

        public Crypto()
        {
            // maybe log "a cryptographic operation is being done"
        }

        public static bool VerifyPassword(string input, string hash)
        {
            if (BCrypt.CheckPassword(input, hash)) return true; else return false;
        }
    }
}