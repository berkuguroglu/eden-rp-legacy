using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Shared.Math;
using GrandTheftMultiplayer.Shared;

namespace eden_rp.vehicle.events
{
    class Vevents : Script
    {

        public static List<Vehicle> listofvehs;
        
        public Vevents()
        {
            
        }
        public static void LoadVehicles()
        {
            listofvehs = new List<Vehicle>();
            MySqlConnection connectionvehicle = EdenCore.EdenDatabaseHandler.con;
            if (connectionvehicle.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand command = new MySqlCommand("SELECT *from erp_vehicles", connectionvehicle);
                MySqlDataReader rtd = command.ExecuteReader();
                while (rtd.Read())
                {
                    listofvehs.Add(new Vehicle((VehicleHash)rtd.GetInt32("modelhash"), rtd.GetInt32("vehid"), EdenCore.EdenDatabaseHandler.api.createVehicle((VehicleHash)rtd.GetInt32("modelhash"), new Vector3(rtd.GetFloat("x"), rtd.GetFloat("y"), rtd.GetFloat("z")), new Vector3(0, 0, 0), rtd.GetInt32("c1"), rtd.GetInt32("c2")), rtd.GetInt32("ownerclientid"), rtd.GetInt32("c1"), rtd.GetInt32("c2"), rtd.GetString("ownername"), new Vector3(rtd.GetFloat("x"), rtd.GetFloat("y"), rtd.GetFloat("z")), false));
                }
                rtd.Close();
            }
            
        }

    }

}
