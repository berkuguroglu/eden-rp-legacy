using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using MySql.Data.MySqlClient;
using Eden.Vehicle;
using GrandTheftMultiplayer.Server.Constant;

namespace Eden.Core
{
    public class DatabaseHandler
    {
        internal static MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=edenrp;UID=root;PASSWORD=''");

        public static bool OpenConnection()
        {
            try
            {
                con.Open();
                EdenCore.api.consoleOutput("[i] Veritabani baglantisi kuruldu"); // make logger do this
                return true;
            }
            catch (MySqlException ex)
            {
                EdenCore.api.consoleOutput("[!] Veritabani baglantisi kurulamadi"); // make logger do this
                EdenCore.api.consoleOutput("[!] MySQL ERR: " + ex.ToString()); // make logger do this
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
                EdenCore.api.consoleOutput("[!] Veritabani baglantisi kapatilirken bir hata olustu"); // make logger do this
                EdenCore.api.consoleOutput("[!] MySQL ERR: " + ex.ToString()); // make logger do this
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
        public static void UplaodVehicles()
        {

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE erp_vehicles SET ownerclientid=@ownerclientid, ownername=@ownername, modelhash=@modelhash, c1=@c1, c2=@c2, x=@x, y=@y, z=@z WHERE vehid = @zehid", con);
                    cmd.Parameters.AddWithValue("@zehid", EdenCore.VehicleList[i].Vehid);
                    cmd.Parameters.AddWithValue("@ownerclientid", EdenCore.VehicleList[i].Owc);
                    cmd.Parameters.AddWithValue("@ownername", EdenCore.VehicleList[i].Ownername);
                    cmd.Parameters.AddWithValue("@modelhash", (int)EdenCore.VehicleList[i].Modelhash);
                    cmd.Parameters.AddWithValue("@c1", EdenCore.VehicleList[i].Color1);
                    cmd.Parameters.AddWithValue("@c2", EdenCore.VehicleList[i].Color2);
                    cmd.Parameters.AddWithValue("@x", EdenCore.VehicleList[i].Parkposition.X);
                    cmd.Parameters.AddWithValue("@y", EdenCore.VehicleList[i].Parkposition.Y);
                    cmd.Parameters.AddWithValue("@z", EdenCore.VehicleList[i].Parkposition.Z);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    EdenCore.api.consoleOutput("[!] MYSQL exception on updating vehicle data: " + ex.StackTrace + ex.ToString()); // make logger do this
                }
            }
        }

        public static void LogoutPlayer(Player player)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE erp_users SET id=@id, posx=@posx, posy=@posy, posz=@posz, firstlogin=@fl, money=@money, bankaccount=@bankacc, bankmoney=@bankmoney, skin=@skin, age=@age, level=@level, gender=@gender, experience=@exp, adminlevel=@al WHERE name=@name", con);
                cmd.Parameters.AddWithValue("name", player.Client.name);
                cmd.Parameters.AddWithValue("id", player.Clientid);
                cmd.Parameters.AddWithValue("posx", player.Client.position.X);
                cmd.Parameters.AddWithValue("posy", player.Client.position.Y);
                cmd.Parameters.AddWithValue("posz", player.Client.position.Z);
                cmd.Parameters.AddWithValue("fl", player.Firstlogin);
                cmd.Parameters.AddWithValue("money", player.Character.Money);
                cmd.Parameters.AddWithValue("bankacc", player.Character.BankAccount);
                cmd.Parameters.AddWithValue("bankmoney", player.Character.BankMoney);
                cmd.Parameters.AddWithValue("skin", (int)player.Character.Skin);
                cmd.Parameters.AddWithValue("age", player.Character.Age);
                cmd.Parameters.AddWithValue("level", player.Level);
                cmd.Parameters.AddWithValue("gender", player.Character.Gender);
                cmd.Parameters.AddWithValue("exp", player.Experience);
                cmd.Parameters.AddWithValue("al", player.Adminlevel);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                EdenCore.api.consoleOutput("[!] MYSQL exception on player logout: " + ex.StackTrace); // make logger do this
            }
        }

        public static bool InitializePlayer(Player player)
        {
            bool freemode = false;
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM erp_users usr INNER JOIN erp_facialdata fd ON usr.id = fd.id WHERE name = @name", con);
                cmd.Parameters.AddWithValue("name", player.Client.name);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        player.Clientid = reader.GetInt32("id");
                        player.Adminlevel = reader.GetInt32("adminlevel");
                        player.Character.Age = reader.GetInt32("age");
                        player.Character.BankAccount = reader.GetInt32("bankaccount");
                        player.Character.BankMoney = reader.GetInt32("bankmoney");
                        player.Level = reader.GetInt32("level");
                        player.Experience = reader.GetInt32("experience");
                        player.Firstlogin = reader.GetBoolean("firstlogin");
                        player.Character.Skin = (PedHash)reader.GetInt32("skin");
                        player.Client.position = new Vector3(reader.GetFloat("posx"), reader.GetFloat("posy"), reader.GetFloat("posz"));
                        player.Character.Gender = reader.GetBoolean("gender");
                        player.Faction = reader.GetInt32("factionid");

                        if (!(player.Firstlogin) && (player.Character.Skin == EdenCore.api.pedNameToModel("FreemodeFemale01") || player.Character.Skin == EdenCore.api.pedNameToModel("FreemodeMale01")))
                        {
                            player.Character.Heritage.Mom = reader.GetInt32("mom");
                            player.Character.Heritage.Dad = reader.GetInt32("dad");
                            player.Character.Heritage.ShapeMix = reader.GetFloat("shapemix");
                            player.Character.Heritage.SkinMix = reader.GetInt32("skinmix");
                            player.Character.Face.EyeColor = reader.GetInt32("eyecolor");
                            player.Character.Hair.Style = reader.GetInt32("hairstyle");
                            player.Character.Hair.Color = reader.GetInt32("haircolor");
                            player.Character.Hair.Highlight = reader.GetInt32("highlight");
                            player.Character.Hair.Eyebrow = reader.GetInt32("eyebrow");
                            player.Character.Hair.EyebrowColor = reader.GetInt32("ebcolor");
                            player.Character.Hair.FacialHair = reader.GetInt32("facialhair");
                            player.Character.Hair.FacialHairColor = reader.GetInt32("fhcolor");
                            player.Character.Face.Blemishes = reader.GetInt32("blemishes");
                            player.Character.Face.Ageing = reader.GetInt32("aging");
                            player.Character.Face.Complexion = reader.GetInt32("complexion");
                            player.Character.Face.SunDamage = reader.GetInt32("sundamage");
                            player.Character.Face.Freckles = reader.GetInt32("freckles");
                            EdenCore.api.sendNativeToAllPlayers(0x9414E18B9434C2FE, player.Client, player.Character.Heritage.Mom, player.Character.Heritage.Dad, 0, player.Character.Heritage.Mom, player.Character.Heritage.Dad, 0, player.Character.Heritage.ShapeMix, player.Character.Heritage.SkinMix, 0.0f, false);
                            freemode = true;
                        }
                        else freemode = false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                EdenCore.api.consoleOutput("[!] MYSQL exception on player initialization: " + ex.StackTrace); // make logger do this 
            }
            return freemode;
        }

        public static void SaveCreatedCharacter(Player player)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE erp_facialdata SET mom=@mom, dad=@dad, shapemix=@shape, skinmix=@skin, eyecolor=@eye, hairstyle=@hair, haircolor=@color, highlight=@highlight, eyebrow=@eb, ebcolor=@ebcolor, facialhair=@fh, fhcolor=@fhcolor, blemishes=@blemishes, aging=@aging, complexion=@complexion, sundamage=@sun, freckles=@freckles WHERE id=@id", con);
                cmd.Parameters.AddWithValue("id", player.Clientid);
                cmd.Parameters.AddWithValue("mom", player.Character.Heritage.Mom);
                cmd.Parameters.AddWithValue("dad", player.Character.Heritage.Dad);
                cmd.Parameters.AddWithValue("shape", player.Character.Heritage.ShapeMix);
                cmd.Parameters.AddWithValue("skin", player.Character.Heritage.SkinMix);
                cmd.Parameters.AddWithValue("eye", player.Character.Face.EyeColor);
                cmd.Parameters.AddWithValue("hair", player.Character.Hair.Style);
                cmd.Parameters.AddWithValue("color", player.Character.Hair.Color);
                cmd.Parameters.AddWithValue("highlight", player.Character.Hair.Highlight);
                cmd.Parameters.AddWithValue("eb", player.Character.Hair.Eyebrow);
                cmd.Parameters.AddWithValue("ebcolor", player.Character.Hair.EyebrowColor);
                cmd.Parameters.AddWithValue("fh", player.Character.Hair.FacialHair);
                cmd.Parameters.AddWithValue("fhcolor", player.Character.Hair.FacialHairColor);
                cmd.Parameters.AddWithValue("blemishes", player.Character.Face.Blemishes);
                cmd.Parameters.AddWithValue("aging", player.Character.Face.Ageing);
                cmd.Parameters.AddWithValue("complexion", player.Character.Face.Complexion);
                cmd.Parameters.AddWithValue("sun", player.Character.Face.SunDamage);
                cmd.Parameters.AddWithValue("freckles", player.Character.Face.Freckles);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                EdenCore.api.consoleOutput("[!] MYSQL exception on character facial data update: " + ex.StackTrace); // make logger do this
            }
        }

        public static void AddVehicle(EdenVehicle veh)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO erp_vehicles (vehid, ownerclientid, ownername, modelhash, c1, c2, x, y, z) VALUES(@id, @ownercid, @ownname, @model, @colorone, @colortwo, @px, @py, @pz)", con);
                command.Parameters.AddWithValue("@id", veh.Vehid);
                command.Parameters.AddWithValue("@ownercid", veh.Owc);
                command.Parameters.AddWithValue("@ownname", veh.Ownername);
                command.Parameters.AddWithValue("@model", (int)veh.Modelhash);
                command.Parameters.AddWithValue("@colorone", veh.Color1);
                command.Parameters.AddWithValue("@colortwo", veh.Color2);
                command.Parameters.AddWithValue("@px", veh.Parkposition.X);
                command.Parameters.AddWithValue("@py", veh.Parkposition.Y);
                command.Parameters.AddWithValue("@pz", veh.Parkposition.Z);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                EdenCore.api.consoleOutput("[!] MYSQL exception on vehicle insertion: " + ex.StackTrace); // make logger do this 
            }
        }

        public static void LoadVehicles()
        {
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM erp_vehicles", con);
                MySqlDataReader rtd = command.ExecuteReader();
                while (rtd.Read())
                {
                    EdenCore.VehicleList.Add(new EdenVehicle((VehicleHash)rtd.GetInt32("modelhash"), rtd.GetInt32("vehid"), EdenCore.api.createVehicle((VehicleHash)rtd.GetInt32("modelhash"), new Vector3(rtd.GetFloat("x"), rtd.GetFloat("y"), rtd.GetFloat("z")), new Vector3(0, 0, 0), rtd.GetInt32("c1"), rtd.GetInt32("c2")), rtd.GetInt32("ownerclientid"), rtd.GetInt32("c1"), rtd.GetInt32("c2"), rtd.GetString("ownername"), new Vector3(rtd.GetFloat("x"), rtd.GetFloat("y"), rtd.GetFloat("z")), false));
                }
                rtd.Close();
            }
            catch (MySqlException ex)
            {
                EdenCore.api.consoleOutput("[!] MYSQL exception on vehicle initialization: " + ex.StackTrace); // make logger do this 
            }


        }
    }
}