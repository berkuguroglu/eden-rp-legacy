using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using MySql.Data.MySqlClient;

namespace eden_rp.EdenCore
{
    public static class EdenDatabaseHandler
    {
        public static MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=edenrp;UID=root;PASSWORD=''");
        private static API api = new API();

        public static bool OpenConnection()
        {
            try
            {
                con.Open();
                api.consoleOutput("[i] Veritabani baglantisi kuruldu"); // make logger do this
                return true;
            }
            catch (MySqlException ex)
            {
                api.consoleOutput("[!] Veritabani baglantisi kurulamadi"); // make logger do this
                api.consoleOutput("[!] MySQL ERR: " + ex.ToString()); // make logger do this
                return false;
            }
        }
        public static bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                api.consoleOutput("[!] Veritabani baglantisi kapatilirken bir hata olustu"); // make logger do this
                api.consoleOutput("[!] MySQL ERR: " + ex.ToString()); // make logger do this
                return false;
            }
        }

        public static bool IsUserValid(Client player)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT name FROM erp_users", con);
            cmd.Parameters.AddWithValue("name", player.name);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool valid = reader.HasRows;
            reader.Close();
            if (valid) return true; else return false;
        }

        public static bool IsPasswordValid(Client player, string passwd)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT pwd FROM erp_users WHERE name=@name", con);
            cmd.Parameters.AddWithValue("name", player.name);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool valid = false;
            while (reader.Read())
            {
                if (Crypto.VerifyPassword(passwd, reader.GetString("pwd")))
                {
                    valid = true;
                    break;
                }
            }
            reader.Close();
            return valid;
        }

        public static Vector3 GetLastPosition(Client player)
        {
            Vector3 position = new Vector3();
            MySqlCommand cmd = new MySqlCommand("SELECT posx, posy, posz FROM erp_users WHERE name=@name", con);
            cmd.Parameters.AddWithValue("name", player.name);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                position.X = reader.GetFloat("posx");
                position.Y = reader.GetFloat("posy");
                position.Z = reader.GetFloat("posz");
            }
            reader.Close();
            return position;
        }

        // update as gamemode expands
        public static void Logout(Client player)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE erp_users SET posx=@posx, posy=@posy, posz=@posz WHERE name=@name", con);
                cmd.Parameters.AddWithValue("name", player.name);
                cmd.Parameters.AddWithValue("posx", player.position.X);
                cmd.Parameters.AddWithValue("posy", player.position.Y);
                cmd.Parameters.AddWithValue("posz", player.position.Z);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                api.consoleOutput("[!] MYSQL exception on player logout: " + ex.StackTrace); // make logger do this
            }
        }
    }
}