﻿using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using MySql.Data.MySqlClient;
using Eden.Vehicle;

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

        public static void LogoutPlayer(Client player)
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
                EdenCore.api.consoleOutput("[!] MYSQL exception on player logout: " + ex.StackTrace); // make logger do this
            }
        }

        public static void InitializeCharacter(Player player)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id, posx, posy, posz, firstlogin, money, bankaccount, bankmoney, skin, age, level, experience, adminlevel FROM erp_users WHERE name=@name", con);
                cmd.Parameters.AddWithValue("name", player.Client.name);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        player.Adminlevel = reader.GetInt32("adminlevel");
                        player.Character.Age = reader.GetInt32("age");
                        player.Character.Bankaccount = reader.GetInt32("bankaccount");
                        player.Character.Bankmoney = reader.GetInt32("bankmoney");
                        player.Clientid = reader.GetInt32("id");
                        player.Level = reader.GetInt32("level");
                        player.Experience = reader.GetInt32("experience");
                        player.Firstlogin = reader.GetBoolean("firstlogin");
                        player.Character.Skin = reader.GetInt32("skin");
                        player.Client.position.X = reader.GetFloat("posx");
                        player.Client.position.Y = reader.GetFloat("posy");
                        player.Client.position.Z = reader.GetFloat("posz");
                    }
                }
            }
            catch (MySqlException ex)
            {
                EdenCore.api.consoleOutput("[!] MYSQL exception on player initialization: " + ex.StackTrace); // make logger do this 
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
            }
            catch (MySqlException ex)
            {
                EdenCore.api.consoleOutput("[!] MYSQL exception on vehicle initialization: " + ex.StackTrace); // make logger do this 
            }

            
        }
    }
}